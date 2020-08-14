using HotelStats.Dao;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HotelStats.Tests
{
    [TestClass]
    public class HotelStatsTest
    {

        private HotelStats _stats;
        private Mock<IStatsDao> _mock;

        [TestInitialize]
        public void BeforeTest()
        {
            _mock = new Mock<IStatsDao>();
            _stats = new HotelStats(_mock.Object);
        }

        [TestMethod]
        public void TestRatingMeanIsZeroWithEmptyDataSet()
        {
            // Arrange
            int[] dataSet = new int[] { };

            // Act
            _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

            // Assert
            Assert.AreEqual(0.00, _stats.GetRatingMean());
        }

        [TestMethod]
        public void TestRatingMeanIsCorrectWithAllTheSameNumbers()
        {
            // Arrange
            int[] dataSet = new int[] { 2, 2, 2, 2, 2 };

            // Act
            _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

            // Assert
            Assert.AreEqual(2.00, _stats.GetRatingMean());
        }

        [TestMethod]
        public void TestRatingMeanIsCorrectWhenDataSetContainsDifferentNumbers()
        {
            // Arrange
            int[] dataSet = new int[] { 1, 2, 2, 3, 5, 3, 4, 4, 2, 1 };

            // Act
            _mock.Setup(dao => dao.GetAllRatings()).Returns(dataSet);

            // Assert
            Assert.AreEqual(2.7, _stats.GetRatingMean());
        }

        [TestMethod]
        public void TestPriceMedianIsZeroWithEmptyDataSet()
        {
            // Arrange
            double[] dataSet = new double[] { };

            // Act
            _mock.Setup(dao => dao.GetAllPrices()).Returns(dataSet);

            // Assert
            Assert.AreEqual(0.00, _stats.GetHotelPriceMedian());
        }

        [TestMethod]
        public void TestPriceMedianWithDataSetLengthOdd()
        {
            // Arrange
            double[] dataSet = new double[] { 99.99, 149.99, 89.99, 129.99, 199.99 };

            // Act
            _mock.Setup(dao => dao.GetAllPrices()).Returns(dataSet);

            // Assert
            Assert.AreEqual(129.99, _stats.GetHotelPriceMedian());
        }

        [TestMethod]
        public void TestPriceMedianWithDataSetLengthEven()
        {
            // Arrange
            double[] dataSet =
                    new double[] { 99.99, 149.99, 89.99, 129.99, 199.99, 179.99 };

            // Act
            _mock.Setup(dao => dao.GetAllPrices()).Returns(dataSet);

            // Assert
            Assert.AreEqual(139.99, _stats.GetHotelPriceMedian());
        }

    }
}
