package com.techelevator.model.campground;

import java.util.List;

public interface CampgroundDAO {
	
	public List<Campground> getCampgroundByParkName(String parkName);
	
	public List<Campground> getCampgroundById(Long campgroundId);
	
	public List<Campground> getCampgroundsByParkId(Long parkId);
	
	public List<Campground> getCampgroundsByName(String name);
	

}
