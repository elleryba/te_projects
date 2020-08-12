package com.techelevator.model;

public class ReviewDto {
	
	private String beerName;
	private Review aReview;
	
	/**
	 * @return the beerName
	 */
	public String getBeerName() {
		return beerName;
	}
	/**
	 * @param beerName the beerName to set
	 */
	public void setBeerName(String beerName) {
		this.beerName = beerName;
	}
	/**
	 * @return the aReview
	 */
	public Review getaReview() {
		return aReview;
	}
	/**
	 * @param aReview the aReview to set
	 */
	public void setaReview(Review aReview) {
		this.aReview = aReview;
	}
	@Override
	public String toString() {
		return "ReviewDto [beerName=" + beerName + ", aReview=" + aReview + "]";
	}
	
	
	

}
