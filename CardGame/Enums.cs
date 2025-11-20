using System;
using System.Collections.Generic;
using System.Text;

namespace CardGame
{
    /// <summary>
    /// Represents the type of a character in a card string.
    /// </summary>
    public enum CharType
    {
        /// <summary>
        /// Character is invalid (not a letter or digit).
        /// </summary>
        Invalid = 0,

        /// <summary>
        /// Character is a numeric digit (2-9).
        /// </summary>
        Number = 1,

        /// <summary>
        /// Character is a letter (T, J, Q, K, A, or suit letters).
        /// </summary>
        Letter = 2
    }

    /// <summary>
    /// Represents the face value of a card.
    /// </summary>
    public enum Value
    {
        /// <summary>
        /// Joker card value.
        /// </summary>
        Joker = 0,

        /// <summary>Card value 2.</summary>
        Two = 2,

        /// <summary>Card value 3.</summary>
        Three = 3,

        /// <summary>Card value 4.</summary>
        Four = 4,

        /// <summary>Card value 5.</summary>
        Five = 5,

        /// <summary>Card value 6.</summary>
        Six = 6,

        /// <summary>Card value 7.</summary>
        Seven = 7,

        /// <summary>Card value 8.</summary>
        Eight = 8,

        /// <summary>Card value 9.</summary>
        Nine = 9,

        /// <summary>Card value 10 (T).</summary>
        T = 10,

        /// <summary>Jack card value.</summary>
        J = 11,

        /// <summary>Queen card value.</summary>
        Q = 12,

        /// <summary>King card value.</summary>
        K = 13,

        /// <summary>Ace card value.</summary>
        A = 14
    }

    /// <summary>
    /// Represents the suit of a card.
    /// </summary>
    public enum Suit
    {
        /// <summary>Joker suit.</summary>
        Joker = 0,

        /// <summary>Clubs suit.</summary>
        C = 1,

        /// <summary>Diamonds suit.</summary>
        D = 2,

        /// <summary>Hearts suit.</summary>
        H = 3,

        /// <summary>Spades suit.</summary>
        S = 4
    }

}
