package com.techelevator.model;

public class Brewery {
	
	private Long id;
	private String brewery_name;
	private String history;
	private String open_from;
	private String open_to;
	private String days_open;
	private String address;
	
	@Override
	public String toString() {
		return "Brewery id=" + id + ", name=" + brewery_name + ", history=" + history + ", openFrom=" + open_from + ", openTo="
				+ open_to + ", daysOpen=" + days_open + ", address=" + address;
	}
	
	
	
	
	public Brewery(Long id, String brewery_name, String history, String open_from, String open_to, String days_open,
			String address) {
		
		this.id = id;
		this.brewery_name = brewery_name;
		this.history = history;
		this.open_from = open_from;
		this.open_to = open_to;
		this.days_open = days_open;
		this.address = address;
	}




	public Brewery() {
		
	}




	public Long getId() {
		return id;
	}
	public String getName() {
		return brewery_name;
	}
	public String getHistory() {
		return history;
	}
	public String getOpenFrom() {
		return open_from;
	}
	public String getOpenTo() {
		return open_to;
	}
	public String getDaysOpen() {
		return days_open;
	}
	public String getAddress() {
		return address;
	}
	public void setId(Long id) {
		this.id = id;
	}
	public void setName(String name) {
		this.brewery_name = name;
	}
	public void setHistory(String history) {
		this.history = history;
	}
	public void setOpenFrom(String openFrom) {
		this.open_from = openFrom;
	}
	public void setOpenTo(String openTo) {
		this.open_to = openTo;
	}
	public void setDaysOpen(String daysOpen) {
		this.days_open = daysOpen;
	}
	public void setAddress(String address) {
		this.address = address;
	}
	
	
	
}
