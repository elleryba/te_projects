using System.Collections.Generic;
using System;
using HotelListing.Models;

namespace HotelListing.Services
{
    public class ReservationEmailNotificationService : IReservationNotificationService
    {

        public void SendWelcomeNotification(Reservation reservation)
        {
            Console.WriteLine("Sending welcome email to: " + reservation.Email);
        }

        public void SendReservationUpdateNotification(Reservation reservation)
        {
            Console.WriteLine("Sending reservation update email to " + reservation.Email);
        }

        public void SendLateReservationNotification(Reservation reservation)
        {
            Console.WriteLine("Sending late reservation email to administrator");
        }
    }
}
