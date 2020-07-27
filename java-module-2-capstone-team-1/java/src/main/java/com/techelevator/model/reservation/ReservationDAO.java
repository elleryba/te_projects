package com.techelevator.model.reservation;

import java.time.LocalDate;
import java.util.List;

public interface ReservationDAO {

	public void makeNewReservation(Long site_id, String name, LocalDate from_date, LocalDate to_date);
	
	public Reservation getReservationByReservationId(Long reservationId);
	
	public Long getLatestResId(); 

	public Reservation createReservation(Reservation newReservation);
}