using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using HotelReservations.Models;
using HotelReservations.Dao;

namespace HotelReservations.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {

        private readonly IHotelDao _dao;

        public HotelsController(IHotelDao hotelDao)
        {
            _dao = hotelDao;
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

        [HttpPost]
        public IActionResult Create(Hotel hotel)
        {
            _dao.Create(hotel);
            return Created("hotels", hotel);
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
