package com.techelevator.model;

public class BeerDTO {
	
	private String breweryName;
	private Beer aBeer;
	/**
	 * @return the breweryName
	 */
	public String getBreweryName() {
		return breweryName;
	}
	/**
	 * @param breweryName the breweryName to set
	 */
	public void setBreweryName(String breweryName) {
		this.breweryName = breweryName;
	}
	/**
	 * @return the aBeer
	 */
	public Beer getaBeer() {
		return aBeer;
	}
	/**
	 * @param aBeer the aBeer to set
	 */
	public void setaBeer(Beer aBeer) {
		this.aBeer = aBeer;
	}
	
	@Override
	public String toString() {
		return "BeerDTO breweryName = " + breweryName + ", aBeer = " + aBeer.toString();
	}

	

}
