package com.techelevator.dao;

import java.util.List;

import com.techelevator.model.Brewery;
import com.techelevator.model.BreweryDTO;

public interface BreweryDAO  {
	
	// Add Brewery / POST
	// Update Brewery / PUT
	// Delete Brewery / DELETE
	// Find Brewery by id / SELECT
	// Find Brewery by name / SELECT
	
	public void addBrewery(BreweryDTO breweryDTO); 

	public List<Brewery> getAllBreweries();
	
	public Brewery getBreweryByName(BreweryDTO breweryDTO);
	
	public void updateBrewery(Long id,BreweryDTO breweryDTO);

}
