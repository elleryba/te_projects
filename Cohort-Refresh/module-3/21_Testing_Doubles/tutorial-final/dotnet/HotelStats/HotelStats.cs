using System;
using System.Linq;
using HotelStats.Dao;

namespace HotelStats
{
    public class HotelStats
    {

        private IStatsDao _statsDao;

        public HotelStats(IStatsDao dao)
        {
            _statsDao = dao;
        }

        /// <summary>
        /// Gets the mean for all the review ratings in our system
        /// </summary>
        public double GetRatingMean()
        {
            int[] stars = _statsDao.GetAllRatings();
            double total = 0.0;
            double mean = 0.0;

            if (stars.Length > 0)
            {
                for (int i = 0; i < stars.Length; i++)
                {
                    total += stars[i];
                }

                mean = total / (double)stars.Length;
            }

            return mean;
        }

        /// <summary>
        /// Gets the median for all the hotel prices in our system
        /// </summary>
        public double GetHotelPriceMedian()
        {
            double[] prices = _statsDao.GetAllPrices();
            double median = 0.0;

            if (prices.Length > 0)
            {
                Array.Sort(prices);

                if (prices.Length % 2 != 0)
                {
                    median = prices[prices.Length / 2];
                }
                else
                {
                    median = (prices[prices.Length / 2] + prices[(prices.Length / 2) - 1]) / 2.0;
                }
            }

            return median;
        }

    }
}
