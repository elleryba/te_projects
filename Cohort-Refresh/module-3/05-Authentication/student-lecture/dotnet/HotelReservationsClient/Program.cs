using System;
using System.Collections.Generic;

namespace HotelReservationsClient
{
    class Program
    {
        private static readonly APIService apiService = new APIService("https://localhost:44322/");
        private static readonly ConsoleService console = new ConsoleService();

        static void Main(string[] args)
        {
            Run();
        }
        private static void Run()
        {
            Console.WriteLine("Welcome to Online Hotels! Please make a selection:");
            MenuSelection();
        }

        private static void MenuSelection()
        {
            int menuSelection = -1;
            while (menuSelection != 0)
            {
                string logInOut = apiService.LoggedIn ? "Log out" : "Log in";

                Console.WriteLine("");
                Console.WriteLine("Menu:");
                Console.WriteLine("1: List Hotels");
                Console.WriteLine("2: List Reservations for Hotel");
                Console.WriteLine("3: Create new Reservation for Hotel");
                Console.WriteLine("4: Update existing Reservation for Hotel");
                Console.WriteLine("5: Delete Reservation");
                Console.WriteLine("6: " + logInOut);
                Console.WriteLine("0: Exit");
                Console.WriteLine("---------");
                Console.Write("Please choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out menuSelection))
                {
                    Console.WriteLine("Invalid input. Only input a number.");
                }
                else if (menuSelection == 1)
                {
                    List<Hotel> hotels = apiService.GetHotels();
                    if (hotels != null && hotels.Count > 0)
                    {
                        console.PrintHotels(hotels);
                    }
                }
                else if (menuSelection == 2)
                {
                    List<Hotel> hotels = apiService.GetHotels();
                    if (hotels != null && hotels.Count > 0)
                    {
                        int hotelId = console.PromptForHotelID(hotels, "list reservations");
                        if (hotelId != 0)
                        {
                            List<Reservation> reservations = apiService.GetReservations(hotelId);
                            if (reservations != null)
                            {
                                console.PrintReservations(reservations, hotelId);
                            }
                        }
                    }
                }
                else if (menuSelection == 3)
                {
                    // Create new reservation
                    string newReservationString = console.PromptForReservationData();
                    Reservation reservationToAdd = new Reservation(newReservationString);

                    if (reservationToAdd.IsValid)
                    {
                        Reservation addedReservation = apiService.AddReservation(reservationToAdd);
                        if (addedReservation != null)
                        {
                            Console.WriteLine("Reservation successfully added.");
                        }
                        else
                        {
                            Console.WriteLine("Reservation not added.");
                        }
                    }
                }
                else if (menuSelection == 4)
                {
                    // Update an existing reservation
                    List<Reservation> reservations = apiService.GetReservations();
                    if (reservations != null)
                    {
                        int reservationId = console.PromptForReservationID(reservations, "update");
                        Reservation oldReservation = apiService.GetReservation(reservationId);
                        if (oldReservation != null)
                        {
                            string updReservationString = console.PromptForReservationData(oldReservation);
                            Reservation reservationToUpdate = new Reservation(updReservationString);

                            if (reservationToUpdate.IsValid)
                            {
                                Reservation updatedReservation = apiService.UpdateReservation(reservationToUpdate);
                                if (updatedReservation != null)
                                {
                                    Console.WriteLine("Reservation successfully updated.");
                                }
                                else
                                {
                                    Console.WriteLine("Reservation not updated.");
                                }
                            }
                        }
                    }
                }
                else if (menuSelection == 5)
                {
                    // Delete reservation
                    List<Reservation> reservations = apiService.GetReservations();
                    if (reservations != null)
                    {
                        int reservationId = console.PromptForReservationID(reservations, "delete");
                        apiService.DeleteReservation(reservationId);
                    }
                }
                else if (menuSelection == 6)
                {
                    if (apiService.LoggedIn)
                    {
                        apiService.Logout();
                        Console.WriteLine("You are now logged out");
                    }
                    else
                    {
                        Console.Write("Please enter username: ");
                        string username = Console.ReadLine();
                        Console.Write("Please enter password: ");
                        string password = Console.ReadLine();
                        var login = apiService.Login(username, password);
                        if (login)
                        {
                            Console.WriteLine("You are now logged in");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Goodbye!");
                    Environment.Exit(0);
                }
            }
        }
    }
}
