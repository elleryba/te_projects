namespace HotelStats.Dao
{
    // Interface defining all of the methods any stats dao should implement
    public interface IStatsDao
    {
        // Get all of the ratings (1-5) as int array
        int[] GetAllRatings();

        // Get all of the hotel cost per night as double array
        double[] GetAllPrices();
    }
}
