using System.Collections.Generic;
using HotelListing.Models;

namespace HotelListing.Dao
{
    public interface IReservationDao
    {
        List<Reservation> FindAll();

        List<Reservation> List(string hotelID);

        Reservation Get(string hotelID, int reservationID);

        void Create(Reservation reservation, string hotelID);

        void Update(Reservation reservation, string hotelID, int reservationID);

        void Delete(string hotelID, int reservationID);
    }
}
