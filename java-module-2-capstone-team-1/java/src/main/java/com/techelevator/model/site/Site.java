package com.techelevator.model.site;

public class Site {
	
	private long site_id;
	private long campground_id;
	private int site_number;
	private int max_occupancy;
	private boolean isAccessible;
	private int max_rv_length;
	private boolean hasUtilities;
	
	
	public Long getSite_id() {
		return site_id;
	}
	public Long getCampground_id() {
		return campground_id;
	}
	public int getSite_number() {
		return site_number;
	}
	public int getMax_occupency() {
		return max_occupancy;
	}
	public boolean isAccessible() {
		return isAccessible;
	}
	public int getMax_rv_length() {
		return max_rv_length;
	}
	public boolean isHasUtilities() {
		return hasUtilities;
	}
	public void setSite_id(Long site_id) {
		this.site_id = site_id;
	}
	public void setCampground_id(Long campground_id) {
		this.campground_id = campground_id;
	}
	public void setSite_number(int site_number) {
		this.site_number = site_number;
	}
	public void setMax_occupency(int max_occupency) {
		this.max_occupancy = max_occupency;
	}
	public void setAccessible(boolean isAccessible) {
		this.isAccessible = isAccessible;
	}
	public void setMax_rv_length(int max_rv_length) {
		this.max_rv_length = max_rv_length;
	}
	public void setHasUtilities(boolean hasUtilities) {
		this.hasUtilities = hasUtilities;
	}
	@Override
	public String toString() {
		return "Site ID: " + site_id + ", Campground ID: " + campground_id + ", Site Number: " + site_number
				+ ", Max Occupancy: " + max_occupancy + ", Handicap Accessible: " + isAccessible + ", Max RV Length: "
				+ max_rv_length + ", Has Utilities: " + hasUtilities;
	}

}
