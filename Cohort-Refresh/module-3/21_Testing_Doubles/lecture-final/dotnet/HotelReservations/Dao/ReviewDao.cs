using System;
using System.Collections.Generic;
using HotelReservations.Models;

namespace HotelReservations.Dao
{
    public class ReviewDao : IReviewDao
    {
        private List<Review> Reviews { get; set; }

        public ReviewDao()
        {
            if (Reviews == null)
            {
                Reviews = new List<Review>
                {
                    new Review(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "What a great hotel!", "I thought this was a really great hotel and would stay again!", "John Smith", 4),
                    new Review(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "Peaceful night sleep", "I had a really good night sleep and would stay again", "Kerry Gold", 3),
                    new Review(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "Fancy!!!", "This place was super fancy", "Mike Unger", 4),
                    new Review(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "Enjoyed my time here", "All around great hotel, no complaints here", "Frank Customer", 3),
                    new Review(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), "Great customer service", "The whole staff was amazing!", "Michelle Star", 5)
                };
            }

        }

        public List<Review> List(string hotelID)
        {
            List<Review> reviewsByHotel = new List<Review>();

            foreach (Review review in Reviews)
            {
                if (review.HotelID.Equals(hotelID))
                {
                    reviewsByHotel.Add(review);
                }
            }

            return reviewsByHotel;
        }

        public void Create(Review review, string hotelID)
        {
            review.Id = Guid.NewGuid().ToString();
            Reviews.Add(review);
        }

        public void Update(Review review)
        {
            for (int i = 0; i < Reviews.Count; i++)
            {
                if (Reviews[i].Id.Equals(review.Id))
                {
                    Reviews[i] = review;
                    return;
                }
            }
        }

        public void Delete(string reviewId)
        {
            for (int i = 0; i < Reviews.Count; i++)
            {
                if (Reviews[i].Id.Equals(reviewId))
                {
                    Reviews.RemoveAt(i);
                    return;
                }
            }
        }

    }
}
