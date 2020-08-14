using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HotelListing.Models
{
    public class Address
    {
        public string Id { get; private set; }

        [JsonProperty("address")]
        [Required(ErrorMessage = "Please enter street address.")]
        public string StreetAddress { get; set; }

        [JsonProperty("address2")]
        public string StreetAddress2 { get; set; }

        [Required(ErrorMessage = "Please enter city.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state.")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please enter a zip code.")]
        public string Zip { get; set; }

        public Address(string streetAddress, string streetAddress2, string city, string state, string zip)
        {
            SetId();
            this.StreetAddress = streetAddress;
            this.StreetAddress2 = streetAddress2;
            this.City = city;
            this.State = state;
            this.Zip = zip;
        }

        private void SetId()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }

}
