package com.techelevator.model.park;

import java.time.LocalDate;

public class Park {
	
	private Long parkId;
	private String name;
	private String location;
	private LocalDate establishDate;
	private int area;
	private int visitors;
	private String description;
	
	/**
	 * @return the park_id
	 */
	public Long getPark_id() {
		return parkId;
	}
	/**
	 * @param park_id the park_id to set
	 */
	public void setPark_id(Long park_id) {
		this.parkId = park_id;
	}
	/**
	 * @return the name
	 */
	public String getName() {
		return name;
	}
	/**
	 * @param name the name to set
	 */
	public void setName(String name) {
		this.name = name;
	}
	/**
	 * @return the location
	 */
	public String getLocation() {
		return location;
	}
	/**
	 * @param location the location to set
	 */
	public void setLocation(String location) {
		this.location = location;
	}
	/**
	 * @return the establish_date
	 */
	public LocalDate getEstablish_date() {
		return establishDate;
	}
	/**
	 * @param establish_date the establish_date to set
	 */
	public void setEstablish_date(LocalDate establish_date) {
		this.establishDate = establish_date;
	}
	/**
	 * @return the area
	 */
	public int getArea() {
		return area;
	}
	/**
	 * @param area the area to set
	 */
	public void setArea(int area) {
		this.area = area;
	}
	/**
	 * @return the visitors
	 */
	public int getVisitors() {
		return visitors;
	}
	/**
	 * @param visitors the visitors to set
	 */
	public void setVisitors(int visitors) {
		this.visitors = visitors;
	}
	/**
	 * @return the description
	 */
	public String getDescription() {
		return description;
	}
	/**
	 * @param description the description to set
	 */
	public void setDescription(String description) {
		this.description = description;
	}
	@Override
	public String toString() {
		return name + "\nLocation: " + location + "\nEstablished: " + establishDate
				+ "\nArea: " + area + " sq km" + "\nAnnual Visitors: " + visitors
				+ "\n\n" + description;
	}

}
