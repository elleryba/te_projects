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
        /// Constructor to create face down card.
        /// </summary>
        /// <param name="value">the value the card represents</param>
        /// <param name="suit">the suit the card represents</param>
        public Card(int value, string suit)
        {
            Suit = suit;
            Value = value;
        }

        /// <summary>
        /// Constructor to create a face down card.
        /// </summary>
        /// <param name="value">the value the card represents</param>
        /// <param name="suit">the suit the card represents</param>
        /// <param name="isFaceUp">if the card is face up or face down</param>
        public Card(int value, string suit, bool isFaceUp)
        {
            Suit = suit;
            Value = value;
            IsFaceUp = isFaceUp;
        }

        /// <summary>
        /// The card suit.
        /// </summary>
        public string Suit { get; }

        /// <summary>
        /// The numeric value for the card.
        /// </summary>
        public int Value { get; }

        /// <summary>
        /// A derived property determined by the suit.
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
        /// If the card is currently face up.
        /// </summary>
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
    }
}