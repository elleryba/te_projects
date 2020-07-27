package com.techelevator.model.site;


import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public interface SiteDAO {

	public List<Site> getAvailableSites(Long campground_id, LocalDate from_date, LocalDate to_date);
	
	public Site getCampsiteWithSiteId(Long site_id);
	
	public double getTotalBill(Long campground_id, LocalDate from_date, LocalDate to_date);
	
}
