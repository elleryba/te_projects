using System;
using System.ComponentModel.DataAnnotations;

namespace HotelListing.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public Hotel Hotel { get; set; }

        [Required(ErrorMessage = "Please provide a name for this reservation")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Please enter a valid checkin date")]
        public DateTime? CheckinDate { get; set; }

        [Required(ErrorMessage = "Please enter a valid checkout date")]
        public DateTime? CheckoutDate { get; set; }

        [Range(1, 5, ErrorMessage = "The number of guests must be between 1 and 5")]
        public int Guests { get; set; }

        public string Email { get; set; }

        public Reservation(int id, Hotel hotel, string name, DateTime? checkin, DateTime? checkout, int guests, string email)
        {
            Id = id;
            Hotel = hotel;
            FullName = name;
            CheckinDate = checkin;
            CheckoutDate = checkout;
            Guests = guests;
            Email = email;
        }
    }
}
