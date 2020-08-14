using System.Collections.Generic;
using System;
using HotelListing.Dao;
using HotelListing.Models;
using HotelListing.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Controllers
{
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationDao _dao;
        private readonly IReservationNotificationService _notificationService;

        public ReservationsController(IReservationDao dao, IReservationNotificationService notificationService)
        {
            _dao = dao;
            _notificationService = notificationService;
        }

        [HttpGet("/reservations")]
        public List<Reservation> FindAll()
        {
            return _dao.FindAll();
        }

        [HttpGet("/hotels/{hotelID}/reservations")]
        public List<Reservation> List(string hotelID)
        {
            return _dao.List(hotelID);
        }

        [HttpGet("/hotels/{hotelID}/reservations/{reservationID}")]
        public ActionResult<Reservation> Get(string hotelID, int reservationID)
        {
            Reservation existingReservation = _dao.Get(hotelID, reservationID);

            if (existingReservation != null)
            {
                return existingReservation;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("/hotels/{hotelID}/reservations")]
        public IActionResult Create(Reservation reservation, string hotelID)
        {
            _dao.Create(reservation, hotelID);
            _notificationService.SendWelcomeNotification(reservation);
            TimeSpan noOfDaysUntilCheckin = reservation.CheckinDate.Value.Subtract(DateTime.Now);
            if (noOfDaysUntilCheckin.TotalDays <= 2)
            {
                _notificationService.SendLateReservationNotification(reservation);
            }
            return Created("reservation", reservation);
        }

        [HttpPut("/hotels/{hotelID}/reservations/{reservationID}")]
        public IActionResult Update(Reservation reservation, string hotelID, int reservationID)
        {
            Reservation existingReservation = _dao.Get(hotelID, reservationID);

            if (existingReservation != null)
            {
                _dao.Update(reservation, hotelID, reservationID);
                _notificationService.SendReservationUpdateNotification(reservation);
                TimeSpan noOfDaysUntilCheckin = reservation.CheckinDate.Value.Subtract(DateTime.Now);
                if (noOfDaysUntilCheckin.TotalDays <= 2)
                {
                    _notificationService.SendLateReservationNotification(reservation);
                }
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }


        [HttpDelete("/hotels/{hotelID}/reservations/{reservationID}")]
        public IActionResult Delete(string hotelID, int reservationID)
        {
            Reservation existingReservation = _dao.Get(hotelID, reservationID);

            if (existingReservation != null)
            {
                _dao.Delete(hotelID, reservationID);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


    }
}
