using System;

namespace HotelReservations.Models
{

    public class Hotel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public int Stars { get; set; }
        public int RoomsAvailable { get; set; }
        public Decimal CostPerNight { get; set; }
        public string CoverImage { get; set; }

        public Hotel(string id, string name, Address address, int stars, int rooms, Decimal cost, string image)
        {
            Id = id;
            Name = name;
            Address = address;
            Stars = stars;
            RoomsAvailable = rooms;
            CostPerNight = cost;
            CoverImage = image;
        }

    }



}
