using DeckOfCards.Classes;
using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            // Default output encoding (character set) is ASCII
            // Set it to Unicode so we can display card sysbols
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 1; i <= 52; i++)
            {
                Card topCard = deck.DealOne();

                Console.WriteLine($"{topCard.FaceValue} of {topCard.Suit} - {topCard.Symbol}");
            }

            Console.ReadLine();
        }
    }
}
