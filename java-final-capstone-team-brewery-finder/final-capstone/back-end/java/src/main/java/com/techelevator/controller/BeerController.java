package com.techelevator.controller;

import java.util.List;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.techelevator.dao.BeerDAO;
import com.techelevator.model.Beer;
import com.techelevator.model.BeerDTO;


@RestController
@CrossOrigin
public class BeerController {

private BeerDAO beerDAO;
	// Comment to push
	public BeerController(BeerDAO beerDAO) {
		this.beerDAO = beerDAO;
	}
	
	@RequestMapping(value = "/beers/{name}", method = RequestMethod.GET)
	public List<Beer> getAllBeerByBreweryName(@PathVariable String name) {
		return beerDAO.getAllBeerByBreweryName(name);
		
	}
	
	@RequestMapping(value = "/beers", method = RequestMethod.GET)
	public List<Beer> getAllBeers() {
		return beerDAO.getAllBeers();
		
	}
	@RequestMapping(value = "/addbeer", method = RequestMethod.POST)
	public void addABeerToBrewery(@RequestBody BeerDTO beerDto) {
		System.out.println("BeerDTO brewery name = " + beerDto.getBreweryName() + " BeerDTO beer name = " + beerDto.getaBeer().getName());
		beerDAO.addABeerToBrewery(beerDto);
	}
	@RequestMapping(value = "/addbeertest", method = RequestMethod.POST)
	public void addABeer(@RequestBody Beer aBeer ) {
		beerDAO.addABeer(aBeer);
	}
	
	@RequestMapping(value = "/delete", method = RequestMethod.DELETE)
	public void deleteABeer(@RequestBody BeerDTO beerDto) {
		System.out.println("BeerDTO brewery name (for delete) = " + beerDto.getBreweryName() + " BeerDTO beer name (for delete)= " + beerDto.getaBeer().getName());
		beerDAO.deleteABeer(beerDto);
		}
}
