using System;
using HotelStats.Dao;

namespace HotelStats
{
    class Program
    {
        static void Main(string[] args)
        {
            IStatsDao dao = new SqlStatsDao();
            HotelStats hotelStats = new HotelStats(dao);

            double meanRating = hotelStats.GetRatingMean();
            Console.WriteLine("Average Rating: " + meanRating);

            double medianPrice = hotelStats.GetHotelPriceMedian();
            Console.WriteLine("Median Price: " + medianPrice);
        }
    }
}
