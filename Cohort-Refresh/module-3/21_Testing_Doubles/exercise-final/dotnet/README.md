# Testing Doubles Exercise

In this exercise, you'll take a hotel reservations system from a previous exercise and add some unit tests to it.

## Project Overview

If you have a chance, spend some time looking through the project and getting familiar with the code. Most of this should look pretty familiar to you. The only new items are the two classes in the `Services` folder in the `HotelListing` project.

The main focus of this exercise is the `ReservationsController`. The controller has two dependencies: `IReservationDao` and `IReservationNotificationService`.

## Reservation Controller Test

If you look at the `ReservationsControllerTests` class in `HotelListing.Tests`, you'll see the starting code that you'll work with. Notice that there are some sample hotels and reservations created for you that you can use in your tests.

```csharp
/*
    * Creates an instance of the ReservationsController and calls methods to set up hotel and reservation data.
    * This method should run once before all of the tests and:
    *   create a new instance of the Reservation Controller
    *   call CreateHotels()
    *   call CreateReservations()
    */
public void Setup() {

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
```

Your first task is to create an instance of the `ReservationsController` and assign it to the variable `_controller`. The `ReservationsController`s constructor takes two arguments, so you need to figure out how to satisfy those. This should be done in the `Setup` method and run once *before* all other tests.

```csharp
public class ReservationsControllerTests
{
    private ReservationsController _controller;
    private List<Hotel> hotels;
    private List<Reservation> reservations;

    /*
        * Creates an instance of the ReservationsController and calls methods to set up hotel and reservation data.
        * This method should run once before all of the tests and:
        *   create a new instance of the Reservation Controller
        *   call CreateHotels()
        *   call CreateReservations()
        */
    public void Setup() {

    }

    // ...

}
```

Once that works and your code compiles, you can move on to writing each of the unit tests.

## Exercise Instructions

The `ReservationsControllerTests` class has 12 tests that you need to write. Some of the test method signatures have been written for you; others might be missing an annotation or have no method body at all. Each test method starts with a description that describes what the test should test. Remember to write tests that are very discrete and only test one piece of functionality. When completed, you should end up with a total of 12 tests.

## Completed Exercise

When you have completed this exercise, you should end up with 12 unit tests. Your code should compile without errors, and all tests should pass.
