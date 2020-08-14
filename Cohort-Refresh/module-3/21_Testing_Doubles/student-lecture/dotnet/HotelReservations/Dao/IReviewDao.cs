using System.Collections.Generic;
using HotelReservations.Models;

namespace HotelReservations.Dao
{
    public interface IReviewDao
    {
        List<Review> List(string hotelID);

        void Create(Review review, string hotelID);

        void Update(Review review);

        void Delete(string reviewID);
    }
}
