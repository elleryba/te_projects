namespace HotelStats.Dao
{
    /// <summary>
    /// This class represents a DAO that will retrieve stats from out Sql Database.
    /// This is just an example and is not actually connecting to a database but this
    /// represents one type of DAO that could retrieve data.
    /// </summary>
    public class SqlStatsDao : IStatsDao
    {

        /// <summary>
        /// Returns an array of all the reviews in our system.
        /// </summary>
        public int[] GetAllRatings()
        {
            return new int[] { 1, 3, 5, 3, 4, 2, 4, 3, 2, 1, 2, 5, 1, 1, 2, 5 };
        }

        /// <summary>
        /// Returns an array of all the hotels cost per night in our system.
        /// </summary>
        public double[] GetAllPrices()
        {
            return new double[] { 99.99, 149.00, 49.00, 89.99, 199.99, 205.00, 299.99, 249.99, 175.00, 309.99, 83.00 };
        }

    }
}
