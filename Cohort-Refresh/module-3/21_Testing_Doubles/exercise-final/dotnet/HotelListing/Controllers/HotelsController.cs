using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using HotelListing.Models;
using HotelListing.Dao;

namespace HotelListing.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly IHotelDao _dao;

        public HotelsController()
        {
            _dao = new HotelDao();
        }

        [HttpGet]
        public List<Hotel> List()
        {
            return _dao.List();
        }

        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(string id)
        {
            Hotel hotel = _dao.Get(id);

            if (hotel != null)
            {
                return hotel;
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            _dao.Create(hotel);
            return Created("hotels", hotel);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Hotel hotel, string id)
        {
            Hotel existingHotel = _dao.Get(id);

            if (existingHotel != null)
            {
                _dao.Update(hotel, id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Hotel existingHotel = _dao.Get(id);

            if (existingHotel != null)
            {
                _dao.Delete(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("filter")]
        public List<Hotel> FilterByStateAndCity(string state, string city)
        {
            List<Hotel> filteredHotels = new List<Hotel>();

            List<Hotel> hotels = List();
            // return hotels that match state
            foreach (Hotel hotel in hotels)
            {
                if (city != null)
                {
                    // if city was passed we don't care about the state filter
                    if (hotel.Address.City.ToLower().Equals(city.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
                else
                {
                    if (hotel.Address.State.ToLower().Equals(state.ToLower()))
                    {
                        filteredHotels.Add(hotel);
                    }
                }
            }

            return filteredHotels;
        }

        /// <summary>
        /// Will return a sorted set (doesn't need to be sorted) of state names
        /// </summary>
        [HttpGet("distinct-states")]
        public HashSet<string> GetDistinctStates()
        {
            HashSet<string> distinctStates = new HashSet<string>();
            List<Hotel> hotels = List();

            foreach (Hotel hotel in hotels)
            {
                distinctStates.Add(hotel.Address.State);
            }

            return distinctStates;
        }

        [HttpGet("cities-by-state")]
        public HashSet<string> GetCitiesByState(string state)
        {
            HashSet<string> distinctCities = new HashSet<string>();
            List<Hotel> hotels = List();

            foreach (Hotel hotel in hotels)
            {
                if (hotel.Address.State.ToLower().Equals(state.ToLower()))
                {
                    distinctCities.Add(hotel.Address.City);
                }
            }
            return distinctCities;
        }

    }

}
