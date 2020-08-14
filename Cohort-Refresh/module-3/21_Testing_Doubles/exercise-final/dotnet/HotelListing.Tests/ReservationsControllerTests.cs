using System.Linq;
using System.Net;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using HotelListing.Models;
using HotelListing.Controllers;
using HotelListing.Dao;
using HotelListing.Services;
using Moq;

namespace HotelListing.Tests
{
    [TestClass]
    public class ReservationsControllerTests
    {
        private ReservationsController _controller;
        private List<Hotel> hotels;
        private List<Reservation> reservations;
        private Mock<IReservationDao> _dao;
        private Mock<IReservationNotificationService> _notificationService;

        /*
         * Creates an instance of the ReservationsController and calls methods to setup hotel and reservation data.
         * This method should run once before all of the tests and:
         *   create a new instance of the Reservation Controller
         *   call CreateHotels()
         *   call CreateReservations()
         */
        [TestInitialize]
        public void Setup()
        {

            hotels = new List<Hotel>();
            reservations = new List<Reservation>();
            _dao = new Mock<IReservationDao>();
            _notificationService = new Mock<IReservationNotificationService>();
            _controller = new ReservationsController(_dao.Object, _notificationService.Object);
            CreateHotels();
            CreateReservations();
        }

        /*
         * Creates test data for hotels
         */
        private void CreateHotels()
        {
            hotels.Add(new Hotel("ABCD1234", "TEST HOTEL", new Address("1234 Main St", "", "Cleveland", "OH", "44113"), 3, 15, 99, ""));
            hotels.Add(new Hotel("EFGH5678", "ANOTHER HOTEL", new Address("4321 Main St", "", "Cleveland", "OH", "44113"), 3, 15, 99, ""));
        }

        /*
         * Creates test data for reservations
         */
        private void CreateReservations()
        {
            DateTime now = DateTime.Now;
            reservations.Add(new Reservation(1, hotels[0], "John Smith", now, now.AddDays(3), 2, "johnsmith@gmail.com"));
            reservations.Add(new Reservation(2, hotels[0], "Anna Blair", now, now.AddDays(1), 1, "annablair@gmail.com"));
            reservations.Add(new Reservation(3, hotels[1], "Sam Smith", now, now.AddDays(7), 1, "samsmith@gmail.com"));
        }

        /*
         * Does the return of the DAO method match what is getting returned by the controller?
         */
        [TestMethod]
        public void TestFindAllReservationsReturnsAllReservations()
        {
            // Arrange
            _dao.Setup(dao => dao.FindAll()).Returns(reservations);

            // Act
            List<Reservation> allReservations = _controller.FindAll();

            // Assert
            CollectionAssert.AreEqual(reservations, allReservations, "The return value of the DAO does not match what is being returned by the controller's findAll method. ");
        }

        /*
         * Does the return of the DAO method match what is getting returned by the controller?
         */
        [TestMethod]
        public void TestListReturnsReservationsByHotelMatchesDaoReturn()
        {
            // Arrange
            List<Reservation> reservationsByHotel = new List<Reservation>();
            reservationsByHotel.Add(reservations[0]);
            reservationsByHotel.Add(reservations[1]);
            _dao.Setup(dao => dao.List("ABCD1234")).Returns(reservationsByHotel);

            // Act
            List<Reservation> allReservations = _controller.List("ABCD1234");

            // Assert
            CollectionAssert.AreEqual(reservationsByHotel, allReservations, "The return value of the DAO does not match what is being returned by the controller's list method.'");
        }

        /*
         * Does the id given to the controller method get passed to the DAO?
         */
        [TestMethod]
        public void TestListShouldPassHotelIdToDAO()
        {
            // Arrange
            List<Reservation> reservationsByHotel = new List<Reservation>();
            reservationsByHotel.Add(reservations[0]);
            reservationsByHotel.Add(reservations[1]);
            _dao.Setup(dao => dao.List("ABCD1234")).Returns(reservationsByHotel);

            // Act
            List<Reservation> allReservations = _controller.List("ABCD1234");

            // Assert
            _dao.Verify(dao => dao.List("ABCD1234"));
        }

        /*
         * Does the return of the DAO method match what is getting returned by the controller?
         */
        [TestMethod]
        public void TestGetReturnsReservationMatchesDaoReturn()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            String hotelID = "ABCD1234";
            int reservationID = 1;
            _dao.Setup(dao => dao.Get(hotelID, reservationID)).Returns(testReservation);

            // Act
            Reservation reservation = _controller.Get(hotelID, reservationID).Value;

            // Assert
            Assert.AreEqual(testReservation, reservation, "The return value of the DAO does not match what is returned by the controller's get method.");
        }

        /**
         * Does the hotelID & registrationID given to the controller method get passed to the DAO?
         */
        [TestMethod]
        public void TestGetShouldPassHotelAndReservationIdToDAO()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            String hotelID = "ABCD1234";
            int reservationID = 1;
            _dao.Setup(dao => dao.Get(hotelID, reservationID)).Returns(testReservation);

            // Act
            Reservation reservation = _controller.Get(hotelID, reservationID).Value;

            // Assert
            _dao.Verify(dao => dao.Get(hotelID, reservationID));
        }

        /*
         * Does the create method send a welcome notification to user?
         */
        [TestMethod]
        public void TestCreateCallsNotificationServiceSendWelcomeNotification()
        {
            // Arrange
            Reservation testReservation = reservations[0];
            String hotelID = "ABCD1234";

            // Act
            _controller.Create(testReservation, hotelID);

            // Assert
            _notificationService.Verify(service => service.SendWelcomeNotification(testReservation));
        }

        /*
         * If reservation is within 2 days does the create method send late reservation notification to administrator?
         */
        [TestMethod]
        public void TestCreateReservationWithinTwoDaysSendsLateReservationNotification()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            String hotelID = "ABCD1234";

            // Act
            _controller.Create(testReservation, hotelID);

            // Assert
            _notificationService.Verify(service => service.SendLateReservationNotification(testReservation));
        }

        /*
         * Does the reservation object and hotelID get passed to DAO?
         */
        [TestMethod]
        public void TestCreateShouldPassReservationAndHotelIdToDAO()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            String hotelID = "ABCD1234";

            // Act
            _controller.Create(testReservation, hotelID);

            // Assert
            _dao.Verify(dao => dao.Create(testReservation, hotelID));
        }

        /*
         * Does the update method send a reservation update notification to the user?
         */
        [TestMethod]
        public void TestUpdateCallsNotificationServiceSendsReservationUpdateNotification()
        {
            // Arrange
            Reservation testReservation = reservations[0];
            testReservation.Guests = 4; // changing the number of guests on the reservation
            String hotelID = "ABCD1234";
            _dao.Setup(dao => dao.Get(hotelID, testReservation.Id)).Returns(testReservation);

            // Act
            _controller.Update(testReservation, hotelID, testReservation.Id);

            // Assert
            _notificationService.Verify(service => service.SendReservationUpdateNotification(testReservation));
        }

        /*
         * If reservation is within 2 days does the update method send late reservation notification to administrator?
         */
        [TestMethod]
        public void TestUpdateReservationWithinTwoDaysSendsLateReservationNotification()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            testReservation.CheckinDate = DateTime.Now.AddDays(1);
            String hotelID = "ABCD1234";
            _dao.Setup(dao => dao.Get(hotelID, testReservation.Id)).Returns(testReservation);

            // Act
            _controller.Update(testReservation, hotelID, testReservation.Id);

            // Assert
            _notificationService.Verify(service => service.SendLateReservationNotification(testReservation));
        }

        /*
         * Does the reservation object passed to the controller go to the DAO?
         */
        [TestMethod]
        public void TestUpdateShouldPassReservationAndHotelIdAndReservationIdToDAO()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            String hotelID = "ABCD1234";
            int reservationID = testReservation.Id;
            _dao.Setup(dao => dao.Get(hotelID, testReservation.Id)).Returns(testReservation);

            // Act
            _controller.Update(testReservation, hotelID, reservationID);

            // Assert
            _dao.Verify(dao => dao.Update(testReservation, hotelID, reservationID));
        }

        /*
         * Does the hotelID & reservationID given to the controller method get passed to the DAO?
         */
        [TestMethod]
        public void TestDeleteShouldPassHotelAndReservationIdToDAO()
        {
            // Arrange
            Reservation testReservation = reservations[1];
            String hotelID = "ABCD1234";
            int reservationID = testReservation.Id;
            _dao.Setup(dao => dao.Get(hotelID, testReservation.Id)).Returns(testReservation);

            // Act
            _controller.Delete(hotelID, reservationID);

            // Assert
            _dao.Verify(dao => dao.Delete(hotelID, reservationID));
        }

    }
}
