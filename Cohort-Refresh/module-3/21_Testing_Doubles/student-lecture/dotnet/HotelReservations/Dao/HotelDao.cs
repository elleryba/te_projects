using System;
using System.Collections.Generic;
using HotelReservations.Models;

namespace HotelReservations.Dao
{
    public class HotelDao : IHotelDao
    {
        private List<Hotel> Hotels { get; set; }

        public HotelDao()
        {
            if (Hotels == null)
            {
                Hotels = new List<Hotel>
                {
                    new Hotel(Guid.NewGuid().ToString(), "Aloft Cleveland", new Address("1111 W 10th St", "", "Cleveland", "Ohio", "44113"), 3, 48, 274, "aloft-cleveland.webp"),
                    new Hotel(Guid.NewGuid().ToString(), "Hilton Cleveland Downtown", new Address("100 Lakeside Ave", "", "Cleveland", "Ohio", "44114"), 4, 12, 287, "hilton-cleveland.webp"),
                    new Hotel(Guid.NewGuid().ToString(), "Metropolitan at the 9", new Address("2017 E 9th St", "", "Cleveland", "Ohio", "44115"), 4, 22, 319, "metropolitan-cleveland.webp"),
                    new Hotel(Guid.NewGuid().ToString(), "The Westin Pittsburgh", new Address("1000 Penn Ave", "", "Pittsburgh", "Pennsylvania", "15222"), 4, 60, 131, "westin-pittsburgh.webp"),
                    new Hotel(Guid.NewGuid().ToString(), "Hilton Columbus Downtown", new Address("401 N High St", "", "Columbus", "Ohio", "43215"), 4, 43, 190, "hilton-columbus.webp"),
                    new Hotel(Guid.NewGuid().ToString(), "The Summit A Dolce Hotel", new Address("5345 Medpace Way", "", "Cincinnati", "Ohio", "43215"), 4, 43, 218, "summit-cincinnati.webp"),
                    new Hotel(Guid.NewGuid().ToString(), "Greektown Detroit", new Address("1200 St Antoine St", "", "Detroit", "Michigan", "48226"), 4, 75, 185, "greektown-detroit.webp")
                };
            }

        }

        public List<Hotel> List()
        {
            return Hotels;
        }

        public Hotel Get(string id)
        {
            foreach (var hotel in Hotels)
            {
                if (hotel.Id.Equals(id))
                {
                    return hotel;
                }
            }

            return null;
        }

        public void Create(Hotel hotel)
        {
            hotel.Id = Guid.NewGuid().ToString();
            Hotels.Add(hotel);
        }

    }
}
