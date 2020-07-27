package com.techelevator.model.reservation;

import java.time.LocalDate;

public class Reservation {
	
	private long reservation_id;
	private int site_id;
	private String name;
	private LocalDate from_date;
	private LocalDate to_date;
	private LocalDate create_date;
	
	
	public long getReservation_id() {
		return reservation_id;
	}
	public int getSite_id() {
		return site_id;
	}
	public String getName() {
		return name;
	}
	public LocalDate getFrom_date() {
		return from_date;
	}
	public LocalDate getTo_date() {
		return to_date;
	}
	public LocalDate getCreate_date() {
		return create_date;
	}
	public void setReservation_id(long reservation_id) {
		this.reservation_id = reservation_id;
	}
	public void setSite_id(long site_id2) {
		this.site_id = (int) site_id2;
	}
	public void setName(String name) {
		this.name = name;
	}
	public void setFrom_date(LocalDate from_date) {
		this.from_date = from_date;
	}
	public void setTo_date(LocalDate to_date) {
		this.to_date = to_date;
	}
	public void setCreate_date(LocalDate create_date) {
		this.create_date = create_date;
	}
	
	public String toString() {
		String reservationConfirmation = "The reservation has been made "
				+ "and the confirmation number is: " + reservation_id + ".";
		return reservationConfirmation;
	}

}
