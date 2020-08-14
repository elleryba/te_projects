using System.Collections.Generic;
using HotelListing.Models;

namespace HotelListing.Services
{
    /**
     * This interface defines all of the notifications you must be able to send
     */
    public interface IReservationNotificationService
    {

        /**
        * Sends welcome notification to user
        * @param reservation the reservation
        */
        void SendWelcomeNotification(Reservation reservation);

        /**
        * Sends reservation update notification to user
        * @param reservation the reservation
        */
        void SendReservationUpdateNotification(Reservation reservation);

        /**
        * Sends a notification to admin that a reservation was created or updated
        * with a checkin date <= 2 days from current date.
        * @param reservation the reservation
        */
        void SendLateReservationNotification(Reservation reservation);

    }

}