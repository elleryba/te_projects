package com.techelevator.model.reservation;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import javax.sql.DataSource;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;

import com.techelevator.model.campground.Campground;
import com.techelevator.model.park.Park;


public class JdbcReservationDAO implements ReservationDAO {
	
	private JdbcTemplate jdbcTemplate;
	
	
	public JdbcReservationDAO(DataSource dataSource) {
		this.jdbcTemplate = new JdbcTemplate(dataSource);
	}
	
//	public long makeReservation(Long site_id, String name, LocalDate from_date, LocalDate to_date) {
//		//long reservationId = 0l;
//		//List<Reservation> aReservation = new ArrayList<Reservation>();
//		LocalDate todaysDate = LocalDate.now();
//		String makeNewReservationSQL = "INSERT into reservation (site_id, name, from_date,"
//										+ "	to_date, create_date) VALUES (?, ?, ?, ?, ?) "
//										+ "RETURNING reservation_id;";
////		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(makeNewReservationSQL, Long.class, site_id, name,
////							from_date, to_date, todaysDate);
////	
////		while(resultFromSql.next()) {
////			
////			Reservation newReservation = MapRowToReservation(resultFromSql);
////			aReservation.add(newReservation);
////		}
//	
//		long reservationId = jdbcTemplate.queryForObject(makeNewReservationSQL, Long.class, site_id, name,
//				from_date, to_date, todaysDate);
//		
////		while (resultFromSql.next()) {
////		reservationId = resultFromSql.getLong("reservation_id");
////		}
//		return reservationId;
//	
//	}
	
	@Override 
	public void makeNewReservation(Long site_id, String name, LocalDate from_date, LocalDate to_date) {
		
		LocalDate todaysDate = LocalDate.now();
		
		String makeNewReservationSQL = "INSERT into reservation (site_id, name, from_date,"
				+ "	to_date, create_date) VALUES (?, ?, ?, ?, ?)";
		
		jdbcTemplate.update(makeNewReservationSQL, site_id, name, from_date, to_date, todaysDate);
	
	}

	@Override 
	public Reservation getReservationByReservationId(Long reservationId) {
		
		String getReservation = "SELECT * FROM reservation WHERE reservation_id = ?";
		
		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getReservation, reservationId);

		Reservation currentReservation = MapRowToReservation(resultFromSql);
		
		return currentReservation;
	}
	
	@Override 
	public Long getLatestResId() {
		List<Reservation> latestReservation = new ArrayList<Reservation>();
		String getLatestResId = "SELECT * FROM reservation ORDER BY reservation_id DESC LIMIT 1";
		
		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet(getLatestResId);
		
		while (resultFromSql.next()) {
			Reservation aReservation = MapRowToReservation(resultFromSql);
			latestReservation.add(aReservation);
		}
		
		Long latestRes = latestReservation.get(0).getReservation_id();
		return latestRes;
		
	}
	@Override 
	public Reservation createReservation(Reservation newReservation) {
		String sqlInsertDepartment = "INSERT into reservation(site_id, name, to_date, from_date, create_date)" +
										"values(?, ?, ?, ?, ?)";
			newReservation.setReservation_id(getNextResId());
			jdbcTemplate.update(sqlInsertDepartment, newReservation.getSite_id(),
					newReservation.getName(),
					newReservation.getTo_date(),
					newReservation.getFrom_date(),
					newReservation.getCreate_date());
			return newReservation;
	}

	private long getNextResId() {
		
		SqlRowSet resultFromSql = jdbcTemplate.queryForRowSet("SELECT nextval('reservation_reservation_id_seq');");
		
		if(resultFromSql.next()) {
			return resultFromSql.getLong(1);
		}
		else {
			throw new RuntimeException("Something went wrong while getting an id for the new city");
		}
	}

	private Reservation MapRowToReservation(SqlRowSet aRow) {
		
		Reservation aReservation = new Reservation();
		
		aReservation.setReservation_id(aRow.getLong("reservation_id"));
		aReservation.setSite_id(aRow.getInt("site_id"));
		aReservation.setName(aRow.getString("name"));
		aReservation.setFrom_date(aRow.getDate("from_date").toLocalDate());
		aReservation.setTo_date(aRow.getDate("to_date").toLocalDate());
		aReservation.setCreate_date(aRow.getDate("create_date").toLocalDate());
	
		return aReservation;
	}
}
