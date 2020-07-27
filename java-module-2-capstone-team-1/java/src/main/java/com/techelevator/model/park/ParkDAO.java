package com.techelevator.model.park;

import java.util.List;

public interface ParkDAO {

	/**
	 * Get all parks from the database
	 * @return all parks as Park objects in a List
	 */
	public List<Park> getAllParks();
	
	/**
	 * Get park info from the database
	 * @param park_id
	 * @return park info in a String
	 */
	public List<Park> getParkByName(String name);
	
	/**
	 * Get park info from the database
	 * @param parkId
	 * @return
	 */
	public List<Park> getParkById(Long parkId);
	
}
