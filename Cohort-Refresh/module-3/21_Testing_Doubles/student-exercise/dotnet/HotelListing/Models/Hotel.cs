using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace HotelListing.Models
{
    public class Hotel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
        public Address Address { get; set; }
        public int Rating { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a positive number of rooms available.")]
        public int RoomsAvailable { get; set; }
        [Range(1.0, double.MaxValue, ErrorMessage = "Please enter a number greater than 0 for cost per night.")]
        public decimal CostPerNight { get; set; }
        public string CoverImage { get; set; }

        public Hotel(string name, Address address, int rating, int numberOfRooms, decimal costPerNight, string cover)
        {
            Id = Guid.NewGuid().ToString();
            Name = name;
            Address = address;
            Rating = rating;
            RoomsAvailable = numberOfRooms;
            CostPerNight = costPerNight;
            CoverImage = cover;
        }

        public Hotel(string id, string name, Address address, int rating, int numberOfRooms, decimal costPerNight, string cover)
        {
            Id = id;
            Name = name;
            Address = address;
            Rating = rating;
            RoomsAvailable = numberOfRooms;
            CostPerNight = costPerNight;
            CoverImage = cover;
        }
    }
}
