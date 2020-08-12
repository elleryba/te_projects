package com.techelevator.controller;

import java.security.Principal;
import java.util.List;

import org.springframework.security.access.prepost.PreAuthorize;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.techelevator.dao.BreweryDAO;
import com.techelevator.model.Brewery;
import com.techelevator.model.BreweryDTO;
@CrossOrigin

@RestController

public class BreweryController {
	
	private BreweryDAO breweryDAO;
	
	public BreweryController(BreweryDAO breweryDAO) {
		this.breweryDAO = breweryDAO;
	}
	
	@RequestMapping(value = "/add", method = RequestMethod.POST)
	public void addBrewery(@RequestBody BreweryDTO breweryDTO) {
		breweryDAO.addBrewery(breweryDTO);
	}
	
	@RequestMapping(value = "/home", method = RequestMethod.GET)
	public List<Brewery> getAllBreweries() {
		return breweryDAO.getAllBreweries();
			
	}
	
	@RequestMapping(value = "/get", method = RequestMethod.GET)
	public Brewery getBrewery(@RequestBody BreweryDTO breweryDTO) {
		return breweryDAO.getBreweryByName(breweryDTO);
		
	}
	
	@RequestMapping(value = "/update/{id}", method = RequestMethod.PUT)
	public void updateBrewery(@RequestBody BreweryDTO breweryDTO, @PathVariable Long id) {
		breweryDAO.updateBrewery(id, breweryDTO);
	}

}
