using System.Collections.Generic;
using HotelReservations.Controllers;
using HotelReservations.Dao;
using HotelReservations.Models;
using HotelReservations.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HotelReservations.Tests
{
    [TestClass]
    public class ReviewsControllerTest
    {
        private ReviewsController controllerUnderTest;
        private Mock<IReviewDao> mockDao;
        private Mock<EmailNotificationService> mockEmailService;
        private Mock<SmsNotificationService> mockSmsService;

        [TestInitialize]
        public void CreateMocksAndController()
        {
            mockDao = new Mock<IReviewDao>();
            mockEmailService = new Mock<EmailNotificationService>();
            mockSmsService = new Mock<SmsNotificationService>();
            controllerUnderTest = new ReviewsController(mockDao.Object, mockEmailService.Object, mockSmsService.Object);
        }

        [TestMethod]
        public void TestListWithReviews()
        {
            // Arrange
            List<Review> expected = CreateTestReviews();
            mockDao.Setup(dao => dao.List("ABC123")).Returns(expected);

            // Act
            List<Review> returnedReviews = controllerUnderTest.List("ABC123");

            // Assert
            // Review needs an equal method for this to work!
            CollectionAssert.AreEqual(expected, returnedReviews, "The value returned from the DAO does not match what is being returned by the controller's List method.");
        }

        [TestMethod]
        public void TestListWithNoReviews()
        {
            // Arrange
            mockDao.Setup(dao => dao.List("ABC123")).Returns(new List<Review>());

            // Act
            List<Review> returnedReviews = controllerUnderTest.List("ABC123");

            // Assert
            Assert.IsNotNull(returnedReviews); // Hotel with no reviews should return a valid list
            Assert.AreEqual(0, returnedReviews.Count, "The DAO returned zero reviews but the return from the controller's List method did not match.");
        }

        [TestMethod]
        public void TestUpdateShouldSetIds()
        {
            // Arrange
            Review testReview = new Review();
            // No need to mock the method because it doesn't return anything

            // Act
            controllerUnderTest.Update(testReview, "ABC123", "DEF456");

            // Assert
            Assert.AreEqual("DEF456", testReview.Id, "The controller's update method did not set the review ID correctly.");
            Assert.AreEqual("ABC123", testReview.HotelID, "The controller's update method did not set the Hotel ID correctly.");
        }

        [TestMethod]
        public void TestUpdateCallsDao()
        {
            // Arrange
            Review testReview = new Review();
            // No need to mock the method because it doesn't return anything

            // Act
            controllerUnderTest.Update(testReview, "ABC123", "DEF456");

            // Assert
            mockDao.Verify(dao => dao.Update(testReview));
        }

        [TestMethod]
        public void TestDeleteCallsDao()
        {
            // Act
            controllerUnderTest.Delete("ABC123");

            // Assert
            mockDao.Verify(dao => dao.Delete("ABC123"));
        }

        [TestMethod]
        public void TestCreateSetsHotelId()
        {
            // Arrange
            Review testReview = new Review();

            // Act
            controllerUnderTest.Create(testReview, "ABC123");

            // Assert
            Assert.AreEqual("ABC123", testReview.HotelID, "The controller's Create method is not setting the Hotel ID properly.");
        }

        [TestMethod]
        public void TestCreateCallsDao()
        {
            // Arrange
            Review testReview = new Review();

            // Act
            controllerUnderTest.Create(testReview, "ABC123");

            // Assert
            mockDao.Verify(dao => dao.Create(testReview, "ABC123"));
        }

        [TestMethod]
        public void TestCreateSendsSmsIfStarsIsOne()
        {
            // Arrange
            Review testReview = new Review();
            testReview.Stars = 1;

            // Act
            controllerUnderTest.Create(testReview, "ABC123");

            // Assert
            mockSmsService.Verify(sms => sms.Send(testReview));
        }

        [TestMethod]
        public void TestCreateSendsEmailIfStarsIsFive()
        {
            // Arrange
            Review testReview = new Review();
            testReview.Stars = 5;

            // Act
            controllerUnderTest.Create(testReview, "ABC123");

            // Assert
            mockEmailService.Verify(email => email.Send(testReview));
        }

        private List<Review> CreateTestReviews()
        {
            List<Review> reviews = new List<Review>();
            reviews.Add(new Review("DEF456", "ABC123", "TEST ONE", "TEST REVIEW", "TEST AUTHOR", 1));
            reviews.Add(new Review("GHI789", "ABC123", "TEST ONE", "TEST REVIEW", "TEST AUTHOR", 2));
            reviews.Add(new Review("JKL123", "ABC123", "TEST ONE", "TEST REVIEW", "TEST AUTHOR", 3));
            reviews.Add(new Review("MNO456", "ABC123", "TEST ONE", "TEST REVIEW", "TEST AUTHOR", 4));
            reviews.Add(new Review("PQR789", "ABC123", "TEST ONE", "TEST REVIEW", "TEST AUTHOR", 5));
            return reviews;
        }
    }
}
