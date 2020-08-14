using System;
using System.Collections.Generic;
using DeckOfCards.Classes;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Card> cards = new List<Card>();

            while (true)
            {
                Console.WriteLine("What do you want to do? ");
                Console.WriteLine("1. Create a new card.");
                Console.WriteLine("2. Display all of the cards.");
                Console.WriteLine("3. Flip all of the cards.");
                Console.WriteLine("Q. Quit");

                string input = Console.ReadLine();

                if (input == "1")
                {
                    // Get the value for the new card
                    Console.Write("What is the value of the card (1-13): ");
                    int value = int.Parse(Console.ReadLine());

                    // Get the suit for the new card
                    Console.Write("What suit does the card have (Hearts, Diamonds, Clubs, Spades): ");
                    string suit = Console.ReadLine();

                    // Is the card face up or face down
                    Console.Write("Is the card face up (True/False): ");
                    bool isFaceUp = bool.Parse(Console.ReadLine());

                    // Create the card and add to the list
                    Card card = new Card(value, suit, isFaceUp);
                    cards.Add(card);

                    Console.WriteLine($"There (is/are) now {cards.Count} cards in the list.");
                }
                else if (input == "2")
                {
                    Console.WriteLine("Displaying all of the cards.");

                    // Loop through each of the cards
                    foreach (Card card in cards)
                    {
                        if (card.IsFaceUp)
                        {
                            Console.WriteLine($"CARD: {card.Value} of {card.Suit}");
                        }
                        else
                        {
                            Console.WriteLine($"CARD: XXXX");
                        }
                    }
                }
                else if (input == "3")
                {
                    Console.WriteLine($"Flipping the cards.");
                    
                    // Loop through each of the cards and flip them
                    foreach (Card card in cards)
                    {
                        if (card.IsFaceUp)
                        {
                            Console.WriteLine($"Flipping {card.Value} of {card.Suit} down.");
                        }
                        else
                        {
                            Console.WriteLine($"Flipping {card.Value} of {card.Suit} up.");
                        }

                        card.Flip();
                    }
                }
                else if (input == "Q")
                {
                    break;
                }

                // Wait for user to press enter and clear screen.
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
