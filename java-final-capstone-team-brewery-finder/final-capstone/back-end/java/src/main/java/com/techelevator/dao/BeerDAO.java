package com.techelevator.dao;

import java.util.List;

import com.techelevator.model.Beer;
import com.techelevator.model.BeerDTO;

public interface BeerDAO {
	
	public List<Beer> getAllBeerByBreweryName(String name);
	
	public List<Beer> getAllBeers();
	
	public void addABeerToBrewery(BeerDTO beerDto);
	
	public Long getBreweryById(String name);
	
	public void addABeer(Beer aBeer);
	
	public void deleteABeer(BeerDTO beerDto);

}
