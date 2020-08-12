package com.techelevator.model;

public class Review {
	
	Long reviewId;
	Long rating;
	String review;
	
	public Review() {}
	
	public Review(Long reviewId, Long rating, String review) {
		this.reviewId = reviewId;
		this.rating = rating;
		this.review = review;
	}
	
	@Override
	public String toString() {
		return "Review [reviewId=" + reviewId + ", rating=" + rating + ", review=" + review + "]";
	}

	public Long getReviewId() {
		return reviewId;
	}
	public void setReviewId(Long reviewId) {
		this.reviewId = reviewId;
	}
	public Long getRating() {
		return rating;
	}
	public void setRating(Long rating) {
		this.rating = rating;
	}
	public String getReview() {
		return review;
	}
	public void setReview(String review) {
		this.review = review;
	}

}
