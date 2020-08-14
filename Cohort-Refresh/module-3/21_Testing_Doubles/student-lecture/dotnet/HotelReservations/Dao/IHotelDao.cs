using System.Collections.Generic;
using HotelReservations.Models;

namespace HotelReservations.Dao
{
    public interface IHotelDao
    {
        List<Hotel> List();

        Hotel Get(string id);

        void Create(Hotel hotel);
    }
}
