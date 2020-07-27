package com.techelevator.model.site;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import com.techelevator.model.park.Park;

public class JdbcSiteDAO implements SiteDAO {

	private JdbcTemplate jdbcTemplate;

	public JdbcSiteDAO(DataSource dataSource) {
		this.jdbcTemplate = new JdbcTemplate(dataSource);
	}

	@Override 
	public List<Site> getAvailableSites(Long campground_id, LocalDate from_date, LocalDate to_date) {
		List<Site> availableSites = new ArrayList<Site>();
		Site aSite = new Site();

		int fromMonth = from_date.getMonthValue();
		int toMonth = to_date.getMonthValue();

		String getAvailableSitesFromSql = "select *"+ 
				"   from site" + 
				"   where site_id in (select site.site_id" + 
				"                       from site " + 
				"                      where site.site_id not in " + 
				"                           (select reservation.site_id" + 
				"                              from reservation " + 
				"                              where ? < to_date " + 
				"                                and ? > from_date))" + 
				"   and campground_id in (select site.campground_id " + 
				"                           from site" + 
				"                          where site.campground_id in (select campground_id" + 
				"                                                         from campground" + 
				"                                                        where ? >= cast(open_from_mm as Integer)" + 
				"                                                          and ? <= cast(open_to_mm as Integer)))" + 
				"                                                          and campground_id = ?" + 
				"   limit 5";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getAvailableSitesFromSql, from_date, to_date, fromMonth, toMonth, campground_id);


		while(resultFromSql.next()) {

			aSite = MapRowToSite(resultFromSql);
			availableSites.add(aSite);
		}

		return availableSites;
	}
	
	@Override 
	public Site getCampsiteWithSiteId(Long site_id) {
		Site campsite = new Site();

		String getCampsiteFromSQL = "SELECT campground_id, site_number, max_occupancy, "
				+ "accessible, max_rv_length, utilities FROM site WHERE site.site_id "
				+ "= ?";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getCampsiteFromSQL, site_id);
		campsite = MapRowToSite(resultFromSql);
		return campsite;
	}
	
	
	@Override 
	public double getTotalBill(Long campId, LocalDate from_date, LocalDate to_date) {

		double totalBill = 0;

		String getBillFromSql = "SELECT (daily_fee * (? - ?)) as total_bill" + 
				" from campground" + 
				//" inner join site on site.campground_id = campground.campground_id" + 
				//" inner join reservation on reservation.site_id = site.site_id " + 
				" where campground.campground_id = ?";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getBillFromSql, to_date, from_date, campId);


		if(resultFromSql.next()) {

			totalBill = resultFromSql.getDouble("total_bill");
		}

		return totalBill;
	}

	private Site MapRowToSite(SqlRowSet aRow) {

		Site aSite = new Site();

		aSite.setSite_id(aRow.getLong("site_id"));
		aSite.setCampground_id(aRow.getLong("campground_id"));
		aSite.setSite_number(aRow.getInt("site_number"));
		aSite.setMax_occupency(aRow.getInt("max_occupancy"));
		aSite.setAccessible(aRow.getBoolean("accessible"));
		aSite.setMax_rv_length(aRow.getInt("max_rv_length"));
		aSite.setHasUtilities(aRow.getBoolean("utilities"));

		return aSite;
	}


}
