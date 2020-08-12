package com.techelevator.model;

public class BreweryDTO {
	
	//private Long   id;
	private String brewery_name;
	private String history;
	private String open_from;
	private String open_to;
	private String days_open;
	private String address;
	
	public BreweryDTO(String brewery_name) {
		this.brewery_name = brewery_name;
	}
	
	
	public BreweryDTO(String brewery_name, String history, String open_from, String open_to, String days_open, String address) {
		this.brewery_name = brewery_name;
		this.history = history;
		this.open_from = open_from;
		this.open_to = open_to;
		this.days_open = days_open;
		this.address = address;
	}
	
//	public BreweryDTO(Long id, String brewery_name, String history, String open_from, String open_to, String days_open, String address) {
//		this.id = id;
//		this.brewery_name = brewery_name;
//		this.history = history;
//		this.open_from = open_from;
//		this.open_to = open_to;
//		this.days_open = days_open;
//		this.address = address;
//	}
	
	@Override
	public String toString() {
		return "BreweryDTO [name=" + brewery_name + ", history=" + history + ", openFrom=" + open_from + ", openTo=" + open_to
				+ ", daysOpen=" + days_open + ", address=" + address + "]";
	}

//	/**
//	 * @return the id
//	 */
//	public Long getId() {
//		return id;
//	}
//
//
//	/**
//	 * @param id the id to set
//	 */
//	public void setId(Long id) {
//		this.id = id;
//	}


	/**
	 * @return the name
	 */
	public String getName() {
		return brewery_name;
	}

	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.brewery_name = name;
	}

	/**
	 * @return the history
	 */
	public String getHistory() {
		return history;
	}

	/**
	 * @param history the history to set
	 */
	public void setHistory(String history) {
		this.history = history;
	}

	/**
	 * @return the openFrom
	 */
	public String getOpenFrom() {
		return open_from;
	}

	/**
	 * @param openFrom the openFrom to set
	 */
	public void setOpenFrom(String openFrom) {
		this.open_from = openFrom;
	}

	/**
	 * @return the openTo
	 */
	public String getOpenTo() {
		return open_to;
	}

	/**
	 * @param openTo the openTo to set
	 */
	public void setOpenTo(String openTo) {
		this.open_to = openTo;
	}

	/**
	 * @return the daysOpen
	 */
	public String getDaysOpen() {
		return days_open;
	}

	/**
	 * @param daysOpen the daysOpen to set
	 */
	public void setDaysOpen(String daysOpen) {
		this.days_open = daysOpen;
	}

	/**
	 * @return the address
	 */
	public String getAddress() {
		return address;
	}

	/**
	 * @param address the address to set
	 */
	public void setAddress(String address) {
		this.address = address;
	}
	
	

}
