using System;
using System.Collections.Generic;
using HotelListing.Models;

namespace HotelListing.Dao
{
    public class ReservationDao : IReservationDao
    {

        // each request of the controller creates a new instance of the dao
        // this is to preserve the data on each request until we get to dependency injection
        private static List<Reservation> Reservations { get; set; }

        private readonly IHotelDao hotelDao;

        public ReservationDao()
        {
            hotelDao = new HotelDao();
            DateTime now = DateTime.Now;
            List<Hotel> hotels = hotelDao.List();

            if (Reservations == null)
            {
                Reservations = new List<Reservation>();
                Reservations.Add(new Reservation(GetMaxIdPlusOne(), hotels[0], "John Smith", now, now.AddDays(3), 2, "johnsmilth@gmail.com"));
                Reservations.Add(new Reservation(GetMaxIdPlusOne(), hotels[0], "Anna Blair", now, now.AddDays(1), 1, "annablair@gmail.com"));
                Reservations.Add(new Reservation(GetMaxIdPlusOne(), hotels[1], "Sam Smith", now, now.AddDays(7), 1, "samsmith@protonmail.com"));
            }
        }

        public List<Reservation> FindAll()
        {
            return Reservations;
        }

        public List<Reservation> List(string hotelID)
        {
            List<Reservation> hotelReservations = new List<Reservation>();
            foreach (Reservation r in Reservations)
            {
                if (r.Hotel.Id.Equals(hotelID))
                {
                    hotelReservations.Add(r);
                }
            }
            return hotelReservations;
        }

        public Reservation Get(string hotelID, int reservationID)
        {
            foreach (Reservation res in Reservations)
            {
                if (res.Hotel.Id.Equals(hotelID) && res.Id == reservationID)
                {
                    return res;
                }
            }

            return null;
        }

        public void Create(Reservation reservation, string hotelID)
        {
            reservation.Id = GetMaxIdPlusOne();
            reservation.Hotel = hotelDao.Get(hotelID);
            Reservations.Add(reservation);
        }

        public void Update(Reservation reservation, string hotelID, int reservationID)
        {
            for (int i = 0; i < Reservations.Count; i++)
            {
                if (Reservations[i].Id == reservationID && Reservations[i].Hotel.Id.Equals(hotelID))
                {
                    reservation.Id = reservationID;
                    reservation.Hotel = hotelDao.Get(hotelID);
                    Reservations[i] = reservation;
                    return;
                }
            }
        }

        public void Delete(string hotelID, int reservationID)
        {
            Reservation reservation = Reservations.Find(r => r.Id == reservationID && r.Hotel.Id.Equals(hotelID));

            if (reservation != null)
            {
                Reservations.Remove(reservation);
            }
        }

        private int GetMaxID()
        {
            int maxID = 0;
            foreach (Reservation r in Reservations)
            {
                if (r.Id > maxID)
                {
                    maxID = r.Id;
                }
            }
            return maxID;
        }

        private int GetMaxIdPlusOne()
        {
            return GetMaxID() + 1;
        }

    }
}
