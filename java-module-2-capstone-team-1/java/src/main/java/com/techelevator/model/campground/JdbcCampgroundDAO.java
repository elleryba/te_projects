package com.techelevator.model.campground;

import java.util.ArrayList;
import java.util.List;
import java.text.*;
import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import com.techelevator.model.park.Park;

public class JdbcCampgroundDAO implements CampgroundDAO {

	private JdbcTemplate jdbcTemplate;

	public JdbcCampgroundDAO(DataSource dataSource) {

		this.jdbcTemplate = new JdbcTemplate(dataSource);
	}

	@Override
	public List<Campground> getCampgroundByParkName(String parkName) {

		List<Campground> theCampgrounds = new ArrayList<Campground>();
		String getCampgrounds = "SELECT * " + 
				"FROM campground " + 
				"INNER JOIN park " + 
				"ON campground.park_id = park.park_id " + 
				"WHERE park.name iLike ? "
				+ "ORDER BY campground_id ASC;";

		String likeSearch = "%" + parkName + "%";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getCampgrounds, likeSearch);
		
			while(resultFromSql.next()) {

				Campground aCampground = MapRowToCampground(resultFromSql);
				theCampgrounds.add(aCampground);
			}

		return theCampgrounds;
	}

	@Override
	public List<Campground> getCampgroundById(Long campgroundId) {
		List<Campground> theCamps = new ArrayList<Campground>();

		String getCampSql = "SELECT * FROM campground WHERE campground_id = ?;";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getCampSql, campgroundId);

		while(resultFromSql.next()) {
			
			Campground aCamp = MapRowToCampground(resultFromSql);
			theCamps.add(aCamp);
		}

		return theCamps;
	}
	
	@Override
	public List<Campground> getCampgroundsByParkId(Long parkId) {
		
		List<Campground> theCamps = new ArrayList<Campground>();
		
		String getCampsSql = "SELECT * FROM campground WHERE park_id = ? "
				+ "ORDER BY campground_id ASC;";
		
		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getCampsSql, parkId);
		
		while(resultFromSql.next()) {
			
			Campground aCamp = MapRowToCampground(resultFromSql);
			theCamps.add(aCamp);
		}	
		return theCamps;
	}
	
	

	public List<Campground> getCampgroundsByName(String name) {
		
		List<Campground> theCamps = new ArrayList<Campground>();
		
		String iLikeSearch = "%" + name + "%";
		String getCampFromSql = "SELECT * FROM campground WHERE name iLike ? "
				+ "ORDER BY campground_id ASC;";
		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getCampFromSql, iLikeSearch);
		
		while(resultFromSql.next()) {
			
			Campground aCamp = MapRowToCampground(resultFromSql);
			theCamps.add(aCamp);
			
		}

		return theCamps;
	}
	



	private Campground MapRowToCampground(SqlRowSet aRow) {

		Campground aCampground = new Campground();

		aCampground.setCampgroundId(aRow.getLong("campground_id"));
		aCampground.setParkId(aRow.getInt("park_id"));
		aCampground.setName(aRow.getString("name"));
		aCampground.setOpenFrom(aRow.getString("open_from_mm"));
		aCampground.setOpenTo(aRow.getString("open_to_mm"));
		aCampground.setDailyFee(aRow.getDouble("daily_fee"));

		return aCampground;
	}

}
