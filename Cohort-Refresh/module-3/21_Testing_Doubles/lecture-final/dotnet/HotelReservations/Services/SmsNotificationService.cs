using System;
using HotelReservations.Models;

namespace HotelReservations.Services
{
    public class SmsNotificationService
    {
        public virtual void Send(Review review)
        {
            Console.WriteLine("Sending SMS Notification for 1 star review off to the customer service department.");
        }
    }
}
