using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    /// <summary>
    /// Represents a playing card in the card game.
    /// </summary>
    public class Card
    {
        /// <summary>
        /// Gets or sets the face value of the card (2-9, T, J, Q, K, A, or Joker).
        /// </summary>
        public Value Value { get; set; }

        /// <summary>
        /// Gets or sets the suit of the card (Clubs, Diamonds, Hearts, Spades, or Joker).
        /// </summary>
        public Suit Suit { get; set; }

        /// <summary>
        /// Indicates whether this card is a Joker. Defaults to false.
        /// </summary>
        public bool IsJoker { get; set; } = false;
    }
}
