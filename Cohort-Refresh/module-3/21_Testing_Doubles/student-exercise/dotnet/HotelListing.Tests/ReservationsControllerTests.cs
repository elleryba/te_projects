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

        /*
         * Creates an instance of the ReservationsController and calls methods to setup hotel and reservation data.
         * This method should run once before all of the tests and:
         *   create a new instance of the Reservation Controller
         *   call CreateHotels()
         *   call CreateReservations()
         */
        public void Setup()
        {
            hotels = new List<Hotel>();
            reservations = new List<Reservation>();
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

            // Act

            // Assert
        }

        /*
         * Does the return of the DAO method match what is getting returned by the controller?
         */
        [TestMethod]
        public void TestListReturnsReservationsByHotelMatchesDaoReturn()
        {
            // Arrange

            // Act

            // Assert
        }

        /*
         * Does the id given to the controller method get passed to the DAO?
         */
        [TestMethod]
        public void TestListShouldPassHotelIdToDAO()
        {
            // Arrange

            // Act

            // Assert
        }

        /*
         * Does the return of the DAO method match what is getting returned by the controller?
         */
        public void TestGetReturnsReservationMatchesDaoReturn()
        {
            // Arrange

            // Act

            // Assert
        }

        /**
         * Does the hotelID & registrationID given to the controller method get passed to the DAO?
         */
        public void TestGetShouldPassHotelAndReservationIdToDAO()
        {
            // Arrange

            // Act

            // Assert
        }

        /*
         * Does the create method send a welcome notification to user?
         */
        public void TestCreateCallsNotificationServiceSendWelcomeNotification()
        {
            // Arrange

            // Act

            // Assert
        }

        /*
         * If reservation is within 2 days does the create method send late reservation notification to administrator?
         */
        public void TestCreateReservationWithinTwoDaysSendsLateReservationNotification()
        {

        }

        /*
         * Does the reservation object and hotelID get passed to DAO?
         */
        public void TestCreateShouldPassReservationAndHotelIdToDAO()
        {

        }

        /*
         * Does the update method send a reservation update notification to the user?
         */
        public void TestUpdateCallsNotificationServiceSendsReservationUpdateNotification()
        {

        }

        /*
         * If reservation is within 2 days does the update method send late reservation notification to administrator?
         */

        /*
         * Does the reservation object passed to the controller go to the DAO?
         */

        /*
         * Does the hotelID & reservationID given to the controller method get passed to the DAO?
         */

    }
}
