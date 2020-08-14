using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace HotelReservations.Models
{

    public class Review
    {
        public string Id { get; set; }
        public string HotelID { get; set; }
        public string Title { get; set; }
        [JsonProperty("review")]
        public string Content { get; set; }
        [Required(ErrorMessage = "The author cannot be blank")]
        public string Author { get; set; }
        [Range(1, 5, ErrorMessage = "The stars must be between 1 and 5")]
        public int Stars { get; set; }

        public Review() { }

        public Review(string id, string hotelID, string title, string review, string author, int stars)
        {
            Id = id;
            HotelID = hotelID;
            Title = title;
            Content = review;
            Author = author;
            Stars = stars;
        }
    }

}
