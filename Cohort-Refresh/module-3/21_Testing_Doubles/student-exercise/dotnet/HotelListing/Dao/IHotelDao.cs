using System.Collections.Generic;
using HotelListing.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Dao
{
    public interface IHotelDao
    {
        List<Hotel> List();

        Hotel Get(string id);

        void Create(Hotel hotel);

        void Update(Hotel hotel, string id);

        void Delete(string id);
    }
}
