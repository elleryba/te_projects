package com.techelevator.hotels;

import com.techelevator.hotels.Dao.SqlStatsDao;
import com.techelevator.hotels.Dao.StatsDao;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

public class HotelStatsTest {

    private HotelStats stats;
    private StatsDao dao = mock(SqlStatsDao.class);

    @Before
    public void setup() {
        stats = new HotelStats(dao);
    }

    @Test
    public void testRatingMeanIsZeroWithEmptyDataSet() {
        // Arrange
        int[] dataSet = new int[] {};

        // Act
        when(dao.getAllRatings()).thenReturn(dataSet);

        // Assert
        assertEquals("Mean of empty array should be 0", 0.00,
                stats.getRatingMean(), 0);
    }

    @Test
    public void TestRatingMeanIsCorrectWithAllTheSameNumbers() {
        // Arrange
        int[] dataSet = new int[] {2, 2, 2, 2, 2};

        // Act
        when(dao.getAllRatings()).thenReturn(dataSet);

        // Assert
        assertEquals("Mean of array of all 2s should be 2", 2.00,
                stats.getRatingMean(), 0);
    }

    @Test
    public void TestRatingMeanIsCorrectWhenDataSetContainsDifferentNumbers() {
        // Arrange
        int[] dataSet = new int[] {1, 2, 2, 3, 5, 3, 4, 4, 2, 1};

        // Act
        when(dao.getAllRatings()).thenReturn(dataSet);

        // Assert
        assertEquals("Mean of array should be average of array", 2.7,
                stats.getRatingMean(), 0);
    }

    @Test
    public void TestPriceMedianIsZeroWithEmptyDataSet() {
        // Arrange
        double[] dataSet = new double[] {};

        // Act
        when(dao.getAllPrices()).thenReturn(dataSet);

        // Assert
        assertEquals("Median of empty array should be 0", 0.00,
                stats.getHotelPriceMedian(), 0);
    }

    @Test
    public void TestPriceMedianWithDataSetLengthOdd() {
        // Arrange
        double[] dataSet = new double[] {99.99, 149.99, 89.99, 129.99, 199.99};

        // Act
        when(dao.getAllPrices()).thenReturn(dataSet);

        // Assert
        assertEquals("Median of odd number array should be middle number",
                129.99, stats.getHotelPriceMedian(), 0);
    }

    @Test
    public void TestPriceMedianWithDataSetLengthEven() {
        // Arrange
        double[] dataSet =
                new double[] {99.99, 149.99, 89.99, 129.99, 199.99, 179.99};

        // Act
        when(dao.getAllPrices()).thenReturn(dataSet);

        // Assert
        assertEquals("Median of even number array is middle two divided by 2",
                139.99, stats.getHotelPriceMedian(), 0);
    }
}
