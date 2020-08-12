package com.techelevator.dao;

import java.util.List;

import com.techelevator.model.Review;
import com.techelevator.model.ReviewDto;

public interface ReviewDAO {
	

	public void addReview(ReviewDto reviewDto);
	
	public List<Review> getAllReviews(String name);
	
}
