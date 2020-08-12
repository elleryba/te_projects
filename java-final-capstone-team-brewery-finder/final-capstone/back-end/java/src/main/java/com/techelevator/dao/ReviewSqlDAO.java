package com.techelevator.dao;

import java.util.ArrayList;
import java.util.List;

import org.springframework.jdbc.core.JdbcTemplate;
import org.springframework.jdbc.support.rowset.SqlRowSet;
import org.springframework.stereotype.Service;

import com.techelevator.model.Review;
import com.techelevator.model.ReviewDto;

@Service
public class ReviewSqlDAO implements ReviewDAO {


private JdbcTemplate jdbcTemplate;
	
	public ReviewSqlDAO(JdbcTemplate jdbcTemplate) {
        this.jdbcTemplate = jdbcTemplate;
    }
	
	public List<Review> getAllReviews(String name) {
		
		List<Review> reviews = new ArrayList<Review>();
		String getAllReviewsSql = "SELECT * FROM REVIEWS INNER JOIN beersreviews ON reviews.reviewid = beersreviews.reviewid INNER JOIN beers ON beersreviews.beerid = beers.beerid WHERE beers.name = ?";
		
		SqlRowSet reviewSet = jdbcTemplate.queryForRowSet(getAllReviewsSql, name);
		  
		  while(reviewSet.next()) { 
			  Review aReview = MapRowToReview(reviewSet);
			  reviews.add(aReview);
			  
		  } 
		  
		  return reviews;
		
	}
	
	public void addReview(ReviewDto reviewDto) {
		Long reviewId = 0L;
		String addReviewSql = "INSERT INTO reviews (rating, review) VALUES (?,?);";
		
		jdbcTemplate.update(addReviewSql, reviewDto.getaReview().getRating(), reviewDto.getaReview().getReview());
		
		String theReviewIdSql = "SELECT reviewid FROM reviews WHERE review = ?";
	    SqlRowSet thisId = jdbcTemplate.queryForRowSet(theReviewIdSql, reviewDto.getaReview().getReview());
	    
	    while(thisId.next()) {
	    	reviewId = thisId.getLong("reviewid");
	    }
	    
//	    String theBeerIdSql = "SELECT beerid FROM beers WHERE name = ?";
//	    SqlRowSet thisBeerId = jdbcTemplate.queryForRowSet(theBeerIdSql);
//	    Long beerId = thisBeerId.getLong("beerid");
	    
	    String addtoRelatorSql = "INSERT INTO beersreviews (beerid, reviewid) VALUES ((SELECT beerid FROM beers WHERE name = ?),?);";
	    jdbcTemplate.update(addtoRelatorSql, reviewDto.getBeerName(), reviewId);
	}
	
	private Review MapRowToReview(SqlRowSet aRow) {
		
		Review aReview = new Review();
		
		aReview.setReviewId(aRow.getLong("reviewid"));
		aReview.setRating(aRow.getLong("rating"));
		aReview.setReview(aRow.getString("review"));

		return aReview;
	}

}
