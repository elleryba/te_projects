using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using FluentAssertions;

namespace AuctionApp.Tests
{
    [TestClass]
    public class APIServiceTests
    {
        APIService api = new APIService();

        [TestMethod]
        public void GetAllAuctions_ExpectList()
        {
            List<Auction> expected = new List<Auction>
            {
                new Auction() { Id = 1, Title = "Bell Computer Monitor", Description = "4K LCD monitor from Bell Computers, HDMI & DisplayPort", User = "Queenie34", CurrentBid = 100.39 },
                new Auction() { Id = 2, Title = "Pineapple Smart Watch", Description = "Pears with Pineapple ePhone", User = "Miller.Fahey", CurrentBid = 377.44 },
                new Auction() { Id = 3, Title = "Mad-dog Sneakers", Description = "Soles check. Laces check.", User = "Cierra_Pagac", CurrentBid = 125.23 },
                new Auction() { Id = 4, Title = "Annie Sunglasses", Description = "Keep the sun from blinding you", User = "Sallie_Kerluke4", CurrentBid = 69.67 },
                new Auction() { Id = 5, Title = "Byson Vacuum", Description = "Clean your house with a spherical vacuum", User = "Lisette_Crist", CurrentBid = 287.73 },
                new Auction() { Id = 6, Title = "Fony Headphones", Description = "Listen to music, movies, games and not bother people around you!", User = "Chester67", CurrentBid = 267.38 },
                new Auction() { Id = 7, Title = "Molex Gold Watch", Description = "Definitely not fake gold watch", User = "Stuart27", CurrentBid = 188.39 }
            };

            List<Auction> actual = api.GetAllAuctions();

            //object comparison done by 3rd party library FluentAssertions
            expected.Should().BeEquivalentTo(actual);
        }

        [TestMethod]
        public void GetDetailsForAuction_ExpectSpecificItems()
        {
            Auction expectedOne = 
                new Auction() { Id = 1, Title = "Bell Computer Monitor", Description = "4K LCD monitor from Bell Computers, HDMI & DisplayPort", User = "Queenie34", CurrentBid = 100.39 };

            Auction expectedFour =
                new Auction() { Id = 4, Title = "Annie Sunglasses", Description = "Keep the sun from blinding you", User = "Sallie_Kerluke4", CurrentBid = 69.67 };

            Auction expectedSeven = 
                new Auction() { Id = 7, Title = "Molex Gold Watch", Description = "Definitely not fake gold watch", User = "Stuart27", CurrentBid = 188.39 };

            Auction actualOne = api.GetDetailsForAuction(1);
            Auction actualFour = api.GetDetailsForAuction(4);
            Auction actualSeven = api.GetDetailsForAuction(7);

            //object comparison done by 3rd party library FluentAssertions
            expectedOne.Should().BeEquivalentTo(actualOne);
            expectedFour.Should().BeEquivalentTo(actualFour);
            expectedSeven.Should().BeEquivalentTo(actualSeven);
        }

        [TestMethod]
        public void GetAuctionsSearchTitle_ExpectTwo()
        {
            List<Auction> expected = new List<Auction>
            {
                new Auction() { Id = 2, Title = "Pineapple Smart Watch", Description = "Pears with Pineapple ePhone", User = "Miller.Fahey", CurrentBid = 377.44 },
                new Auction() { Id = 7, Title = "Molex Gold Watch", Description = "Definitely not fake gold watch", User = "Stuart27", CurrentBid = 188.39 }
            };

            List<Auction> actual = api.GetAuctionsSearchTitle("watch");

            //object comparison done by 3rd party library FluentAssertions
            expected.Should().BeEquivalentTo(actual);
        }

        [TestMethod]
        public void GetAuctionsSearchTitle_ExpectNone()
        {
            List<Auction> actual = api.GetAuctionsSearchTitle("asdgsdfgdfg");

            //object comparison done by 3rd party library FluentAssertions
            actual.Should().BeEmpty();
        }

        [TestMethod]
        public void GetAuctionsSearchPrice_ExpectThree()
        {
            List<Auction> expected = new List<Auction>
            {
                new Auction() { Id = 1, Title = "Bell Computer Monitor", Description = "4K LCD monitor from Bell Computers, HDMI & DisplayPort", User = "Queenie34", CurrentBid = 100.39 },
                new Auction() { Id = 3, Title = "Mad-dog Sneakers", Description = "Soles check. Laces check.", User = "Cierra_Pagac", CurrentBid = 125.23 },
                new Auction() { Id = 4, Title = "Annie Sunglasses", Description = "Keep the sun from blinding you", User = "Sallie_Kerluke4", CurrentBid = 69.67 }
            };

            List<Auction> actual = api.GetAuctionsSearchPrice(150);

            expected.Should().BeEquivalentTo(actual);
        }

        [TestMethod]
        public void GetAuctionsSearchPrice_ExpectOne()
        {
            List<Auction> expected = new List<Auction>
            {
                new Auction() { Id = 4, Title = "Annie Sunglasses", Description = "Keep the sun from blinding you", User = "Sallie_Kerluke4", CurrentBid = 69.67 }
            };

            List<Auction> actual = api.GetAuctionsSearchPrice(75);

            expected.Should().BeEquivalentTo(actual);
        }
    }
}
