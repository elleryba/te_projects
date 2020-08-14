using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using HotelReservations.Models;
using HotelReservations.Dao;
using HotelReservations.Services;

namespace HotelReservations.Controllers
{
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewDao _dao;

        private readonly EmailNotificationService _emailNotificationService;

        private readonly SmsNotificationService _smsNotificationService;

        public ReviewsController(IReviewDao reviewDao, EmailNotificationService emailService, SmsNotificationService smsService)
        {
            _dao = reviewDao;
            _emailNotificationService = emailService;
            _smsNotificationService = smsService;
        }

        [HttpGet("/hotels/{hotelID}/reviews")]
        public List<Review> List(string hotelID)
        {
            return _dao.List(hotelID);
        }

        [HttpPost("/hotels/{hotelID}/reviews")]
        public IActionResult Create(Review review, string hotelID)
        {
            review.HotelID = hotelID;

            if (review.Stars == 1)
            {
                _smsNotificationService.Send(review);
            }

            if (review.Stars == 5)
            {
                _emailNotificationService.Send(review);
            }

            _dao.Create(review, hotelID);
            return Created("reviews/hotel/" + hotelID, review);
        }

        [HttpPut("/hotels/{hotelID}/reviews/{reviewID}")]
        public IActionResult Update(Review review, string hotelID, string reviewID)
        {
            review.Id = reviewID;
            review.HotelID = hotelID;
            _dao.Update(review);
            return NoContent();
        }

        [HttpDelete("/hotels/{hotelID}/reviews/{reviewID}")]
        public IActionResult Delete(string reviewID)
        {
            _dao.Delete(reviewID);
            return NoContent();
        }

    }

}
