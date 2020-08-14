package com.techelevator.hotellisting.controller;

import com.techelevator.hotellisting.exception.HotelNotFoundException;
import org.junit.Before;
import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.*;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import com.techelevator.hotellisting.controllers.ReservationController;
import com.techelevator.hotellisting.dao.ReservationDAO;
import com.techelevator.hotellisting.exception.ReservationNotFoundException;
import com.techelevator.hotellisting.models.Address;
import com.techelevator.hotellisting.models.Hotel;
import com.techelevator.hotellisting.models.Reservation;
import com.techelevator.hotellisting.service.ReservationNotificationService;

public class ReservationControllerTest {

    private ReservationController controller;
    private List<Hotel> hotels;
    private List<Reservation> reservations;
    private ReservationDAO dao;
    private ReservationNotificationService notificationService;

    /*
     * Creates an instance of the ReservationController and calls methods to setup hotel and reservation data.
     * This method should run once before all of the tests and:
     *   create a new instance of the Reservation Controller
     *   call createHotels()
     *   call createReservations()
     */
    @Before
    public void setup() {

        hotels = new ArrayList<>();
        reservations = new ArrayList<>();
        dao = mock(ReservationDAO.class);
        notificationService = mock(ReservationNotificationService.class);
        controller = new ReservationController(dao, notificationService);
        createHotels();
        createReservations();
    }

    /*
     * Creates test data for hotels
     */
    private void createHotels() {
        hotels.add(new Hotel("ABCD1234", "TEST HOTEL", new Address("1234 Main St", "", "Cleveland", "OH", "44113"), 3, 15, 99, ""));
        hotels.add(new Hotel("EFGH5678", "ANOTHER HOTEL", new Address("4321 Main St", "", "Cleveland", "OH", "44113"), 3, 15, 99, ""));
    }

    /*
     * Creates test data for reservations
     */
    private void createReservations() {
        LocalDate now = LocalDate.now();
        reservations.add(new Reservation(1, hotels.get(0), "John Smith", now, now.plusDays(3), 2, "johnsmith@gmail.com"));
        reservations.add(new Reservation(2, hotels.get(0), "Anna Blair", now, now.plusDays(1), 1, "annablair@gmail.com"));
        reservations.add(new Reservation(3, hotels.get(1), "Sam Smith", now, now.plusDays(7), 1, "samsmith@gmail.com"));
    }

    /*
     * Does the return of the DAO method match what is getting returned by the controller?
     */
    @Test
    public void testFindAllReservationsReturnsAllReservations() {
        // Arrange
        when(dao.findAll()).thenReturn(reservations);

        // Act
        List<Reservation> allReservations = controller.findAll();

        // Assert
        assertEquals("The return value of the DAO does not match what is being returned by the controller's findAll method. ", reservations, allReservations);
    }

    /*
     * Does the return of the DAO method match what is getting returned by the controller?
     */
    @Test
    public void testListReturnsReservationsByHotelMatchesDaoReturn() {
        // Arrange
        List<Reservation> reservationsByHotel = new ArrayList<>();
        reservationsByHotel.add(reservations.get(0));
        reservationsByHotel.add(reservations.get(1));
        when(dao.list("ABCD1234")).thenReturn(reservationsByHotel);

        // Act
        List<Reservation> allReservations = controller.list("ABCD1234");

        // Assert
        assertEquals("The return value of the DAO does not match what is being returned by the controller's list method.'", reservationsByHotel, allReservations);
    }

    /*
     * Does the id given to the controller method get passed to the DAO?
     */
    @Test
    public void testListShouldPassHotelIdToDAO() {
        // Arrange
        List<Reservation> reservationsByHotel = new ArrayList<>();
        reservationsByHotel.add(reservations.get(0));
        reservationsByHotel.add(reservations.get(1));
        when(dao.list("ABCD1234")).thenReturn(reservationsByHotel);

        // Act
        List<Reservation> allReservations = controller.list("ABCD1234");

        // Assert
        verify(dao).list("ABCD1234");
    }

    /*
     * Does the return of the DAO method match what is getting returned by the controller?
     */
    @Test
    public void testGetReturnsReservationMatchesDaoReturn() throws ReservationNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        String hotelID = "ABCD1234";
        int reservationID = 1;
        when(dao.get(hotelID, reservationID)).thenReturn(testReservation);

        // Act
        Reservation reservation = controller.get(hotelID, reservationID);

        // Assert
        assertEquals("The return value of the DAO does not match what is returned by the controller's get method.", testReservation, reservation);
    }

    /**
     * Does the hotelID & registrationID given to the controller method get passed to the DAO?
     */
    @Test
    public void testGetShouldPassHotelAndReservationIdToDAO() throws ReservationNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        String hotelID = "ABCD1234";
        int reservationID = 1;
        when(dao.get(hotelID, reservationID)).thenReturn(testReservation);

        // Act
        Reservation reservation = controller.get(hotelID, reservationID);

        // Assert
        verify(dao).get(hotelID, reservationID);
    }

    /*
     * Does the create method send a welcome notification to user?
     */
    @Test
    public void testCreateCallsNotificationServiceSendWelcomeNotification() throws HotelNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(0);
        String hotelID = "ABCD1234";

        // Act
        controller.create(testReservation, hotelID);

        // Assert
        verify(notificationService, times(1)).sendWelcomeNotification(testReservation);
    }

    /*
     * If reservation is within 2 days does the create method send late reservation notification to administrator?
     */
    @Test
    public void testCreateReservationWithinTwoDaysSendsLateReservationNotification() throws HotelNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        String hotelID = "ABCD1234";

        // Act
        controller.create(testReservation, hotelID);

        // Assert
        verify(notificationService, times(1)).sendLateReservationNotification(testReservation);
    }

    /*
     * Does the reservation object and hotelID get passed to DAO?
     */
    @Test
    public void testCreateShouldPassReservationAndHotelIdToDAO() throws HotelNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        String hotelID = "ABCD1234";

        // Act
        controller.create(testReservation, hotelID);

        // Assert
        verify(dao).create(testReservation, hotelID);
    }

    /*
     * Does the update method send a reservation update notification to the user?
     */
    @Test
    public void testUpdateCallsNotificationServiceSendsReservationUpdateNotification() throws HotelNotFoundException, ReservationNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(0);
        testReservation.setGuests(4); // changing the number of guests on the reservation
        String hotelID = "ABCD1234";

        // Act
        controller.update(testReservation,hotelID,testReservation.getId());

        // Assert
        verify(notificationService, times(1)).sendReservationUpdateNotification(testReservation);
    }

    /*
     * If reservation is within 2 days does the update method send late reservation notification to administrator?
     */
    @Test
    public void testUpdateReservationWithinTwoDaysSendsLateReservationNotification() throws HotelNotFoundException, ReservationNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        testReservation.setCheckinDate(LocalDate.now().plusDays(1));
        String hotelID = "ABCD1234";

        // Act
        controller.update(testReservation, hotelID,testReservation.getId());

        // Assert
        verify(notificationService, times(1)).sendLateReservationNotification(testReservation);
    }

    /*
     * Does the reservation object passed to the controller go to the DAO?
     */
    @Test
    public void testUpdateShouldPassReservationAndHotelIdAndReservationIdToDAO() throws HotelNotFoundException, ReservationNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        String hotelID = "ABCD1234";
        int reservationID = testReservation.getId();

        // Act
        controller.update(testReservation, hotelID, reservationID);

        // Assert
        verify(dao).update(testReservation, hotelID, reservationID);
    }

    /*
     * Does the hotelID & reservationID given to the controller method get passed to the DAO?
     */
    @Test
    public void testDeleteShouldPassHotelAndReservationIdToDAO() throws ReservationNotFoundException {
        // Arrange
        Reservation testReservation = reservations.get(1);
        String hotelID = "ABCD1234";
        int reservationID = testReservation.getId();

        // Act
        controller.delete(hotelID, reservationID);

        // Assert
        verify(dao).delete(hotelID, reservationID);
    }

}
