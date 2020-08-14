using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckOfCards.Classes
{
    public class Card
    {
        /// <summary>
        /// The card suit.
        /// </summary>
        public string Suit { get; }

        /// <summary>
        /// The numeric value for the card.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// Derived Property that calculates Red or Black based on Suit Property.
        /// </summary>
        public string Color
        {
            get
            {
                if (Suit == "Hearts" || Suit == "Diamonds")
                {
                    return "Red";
                }
                else
                {
                    return "Black";
                }
            }
        }

        /// <summary>
        /// Gets the word for face value.
        /// </summary>
        public string FaceValue
        {
            get
            {
                return faceValues[Value];
            }
        }

        /// <summary>
        /// Gets the symbol for the suit.
        /// </summary>
        public char Symbol
        {
            get
            {
                return suitSymbols[Suit];
            }
        }
        public bool IsFaceUp { get; private set; }

        /// <summary>
        /// Toggles Faceup to face down and facedown to faceup
        /// </summary>
        public void Flip()
        {
            // Toggle IsFaceUp from true -> false or false -> true
            // IsFaceUp = !IsFaceUp
            if (IsFaceUp)
            {
                IsFaceUp = false;
            }
            else
            {
                IsFaceUp = true;
            }
        }

        /// <summary>
        /// Constructor to create a suit
        /// </summary>
        /// <param name="value">the value the card represents</param>
        /// <param name="suit">the suit the card represents</param>
        public Card(int value, string suit)
        {
            this.Suit = suit; //'this' is optional "sometimes"
            Value = value;
            IsFaceUp = false; // not needed since bool defaults to false
        }

        static Dictionary<string, char> suitSymbols = new Dictionary<string, char>()
        {
            {"Spades", '\u2660'},
            {"Diamonds", '\u2666'},
            {"Clubs", '\u2663'},
            {"Hearts", '\u2665'}
        };

        static Dictionary<int, string> faceValues = new Dictionary<int, string>()
                {
                    {1, "Ace" },
                    {2, "Two" },
                    {3, "Three" },
                    {4, "Four" },
                    {5, "Five" },
                    {6, "Six" },
                    {7, "Seven" },
                    {8, "Eight" },
                    {9, "Nine" },
                    {10, "Ten" },
                    {11, "Jack" },
                    {12, "Queen" },
                    {13, "King" }
                };
    }
}
