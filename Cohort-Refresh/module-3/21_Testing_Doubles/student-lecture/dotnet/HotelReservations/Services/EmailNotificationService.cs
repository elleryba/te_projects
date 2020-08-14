using System;
using HotelReservations.Models;

namespace HotelReservations.Services
{
    public class EmailNotificationService
    {
        public virtual void Send(Review review)
        {
            Console.WriteLine("Sending Email Notification for 5 star review off to the marketing department.");
        }
    }
}
