package com.techelevator.model.park;

import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

public class JdbcParkDAO implements ParkDAO {

	private JdbcTemplate jdbcTemplate;

	public JdbcParkDAO(DataSource dataSource) {
		this.jdbcTemplate = new JdbcTemplate(dataSource);
	}

	@Override
	public List<Park> getAllParks() {

		List<Park> theParks = new ArrayList<Park>();

		String getAllParksSql = "SELECT * FROM park ORDER BY name ASC";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getAllParksSql);

		while(resultFromSql.next()) {

			theParks.add(MapRowToPark(resultFromSql));
		}

		return theParks;
	}

	@Override
	public List<Park> getParkByName(String name) {
		
		List<Park> theParks = new ArrayList<Park>();
		String iLikeSearch = "%" + name + "%";

		String getParkInfoFromSql = "SELECT * FROM park WHERE name iLike ?;";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getParkInfoFromSql, iLikeSearch);
		
		while(resultFromSql.next()) {

			Park aPark = MapRowToPark(resultFromSql);
			theParks.add(aPark);
		}

		return theParks;
	}
//	
	@Override
	public List<Park> getParkById(Long parkId) {
		
		List<Park> theParks = new ArrayList<Park>();

		String getParkInfoFromSql = "SELECT * FROM park WHERE park_id = ?;";

		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getParkInfoFromSql, parkId);
		
		while(resultFromSql.next()) {

			Park aPark = MapRowToPark(resultFromSql);
			theParks.add(aPark);
		}

		return theParks;
	}

	private Park MapRowToPark(SqlRowSet aRow) {

		Park aPark = new Park();

		aPark.setPark_id(aRow.getLong("park_id"));
		aPark.setName(aRow.getString("name"));
		aPark.setLocation(aRow.getString("location"));
		aPark.setEstablish_date(aRow.getDate("establish_date").toLocalDate());
		aPark.setArea(aRow.getInt("area"));
		aPark.setVisitors(aRow.getInt("visitors"));
		aPark.setDescription(aRow.getString("description"));

		return aPark;
	}

}
