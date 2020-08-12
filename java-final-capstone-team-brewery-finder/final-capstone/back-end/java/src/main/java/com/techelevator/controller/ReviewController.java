package com.techelevator.controller;

import java.util.List;

import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.techelevator.dao.ReviewDAO;
import com.techelevator.model.Review;
import com.techelevator.model.ReviewDto;

@RestController
@CrossOrigin
public class ReviewController {
	
	private ReviewDAO reviewDAO;
	public ReviewController(ReviewDAO reviewDAO) {
		this.reviewDAO = reviewDAO;
	}

	
	@RequestMapping(value = "/beers/{name}/reviews", method = RequestMethod.GET)
	public List<Review> getAllReviews(@PathVariable String name) {
		return reviewDAO.getAllReviews(name);
		
	}
	
	@RequestMapping(value = "/beers/addreview", method = RequestMethod.POST)
	public void addReview(@RequestBody ReviewDto reviewDto) {
		reviewDAO.addReview(reviewDto);
	}
}
