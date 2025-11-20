using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CardGame
{
    public class CardGameService
    {
        /// <summary>
        /// Determines if a character is a letter, number, or invalid.
        /// Used for validating card values and suits.
        /// </summary>
        public static CharType IsLetterOrNumber(char c)
        {
            if (char.IsLetter(c))          // Check if character is A-Z or a-z
            {
                return CharType.Letter;
            }
            else if (char.IsDigit(c))      // Check if character is 0-9
            {
                return CharType.Number;
            }
            else                           // Any other symbol is invalid
            {
                return CharType.Invalid;
            }
        }

        /// <summary>
        /// Parses a character into a card Value enum.
        /// Supports numbers 2-9 and face cards (J, Q, K, A).
        /// Throws exception for invalid values like '0', '1', or unrecognized letters.
        /// </summary>
        public static Value ParseValue(char Value)
        {
            // Handle numeric card values
            if (char.IsDigit(Value))
            {
                int numericValue = int.Parse(Value.ToString());

                // Only 2-9 are valid numeric card values
                if (numericValue < 2 || numericValue > 9)
                    throw new ArgumentException($"Invalid card value character: '{Value}'");

                return (Value)numericValue; // Cast numeric value to enum
            }

            // Convert character to uppercase to accept lowercase letters
            Value = char.ToUpper(Value);

            // Handle face cards (J, Q, K, A) using enum parsing
            if (Enum.TryParse<Value>(Value.ToString(), out var result))
            {
                return result;
            }

            // If character cannot be parsed, throw an exception
            throw new ArgumentException($"Invalid card value character: '{Value}'");
        }

        /// <summary>
        /// Parses a character into a Suit enum.
        /// Throws an exception if the character is not a valid suit (C, D, H, S).
        /// </summary>
        public static Suit ParseSuit(char Suit)
        {
            // Convert character to uppercase to accept lowercase letters
            Suit = char.ToUpper(Suit);

            // Try to parse character directly into Suit enum
            if (Enum.TryParse<Suit>(Suit.ToString(), out var result))
            {
                return result;
            }

            // Throw if parsing fails
            throw new ArgumentException($"Invalid card suit character: '{Suit}'");
        }

        /// <summary>
        /// Parses a 2-character card string into a Card object.
        /// Handles normal cards and Jokers (JR).
        /// Throws exception for invalid formats or characters.
        /// </summary>
        public static Card ParseCard(string Card)
        {
            // Card must be exactly 2 characters (except for Joker "JR")
            if (Card.Length != 2)
            {
                throw new ArgumentException("Card string must be exactly 2 characters long.");
            }

            // Special case: Joker card
            if (Card == "JR")
            {
                return new Card
                {
                    Value = Value.Joker,
                    Suit = Suit.Joker,
                    IsJoker = true
                };
            }

            // Extract value and suit characters
            char value = Card[0];
            char suit = Card[1];

            // Validate value character
            var valueType = IsLetterOrNumber(value);
            if (valueType == CharType.Invalid)
            {
                throw new ArgumentException($"Invalid character in card string: '{value}'");
            }

            // Validate suit character
            var suitType = IsLetterOrNumber(suit);
            if (suitType != CharType.Letter)
            {
                throw new ArgumentException($"Invalid character in card string: '{value}'");
            }

            // Return parsed Card object
            return new Card
            {
                Value = ParseValue(value),
                Suit = ParseSuit(suit)
            };
        }

        /// <summary>
        /// Calculates the score for a single card.
        /// Score = Value * Suit (both as integers).
        /// Jokers should have Value=0 so their score is 0.
        /// </summary>
        public static int CalculateCardScore(Card card)
        {
            return (int)card.Value * (int)card.Suit;
        }

        /// <summary>
        /// Calculates the total score for a hand of cards.
        /// Handles Jokers, duplicates, invalid characters, and invalid formats.
        /// Each Joker doubles the total score (cumulative multiplier).
        /// </summary>
        public static int CalculateHandScore(string hand)
        {
            // Step 1: Reject any characters that are invalid (not letter, number, or comma) but allow whitespace by removing
            hand = hand.Replace(" ", ""); // remove all spaces
            foreach (char ch in hand)
            {
                if (IsLetterOrNumber(ch) == CharType.Invalid && ch != ',')
                    throw new ArgumentException("Invalid input string");
            }

            // Step 2: Split the hand into individual card strings
            var cardStrings = hand.Split(',')
                                  .Select(c => c.Trim())
                                  .ToList();

            // Step 3: Reject empty card strings (e.g., "2C,,3D")
            if (cardStrings.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException("Invalid input string");
            }

            int totalScore = 0;             // Accumulate total score
            int jokerCount = 0;             // Count number of Jokers in the hand
            var seenCardStrings = new HashSet<string>(StringComparer.OrdinalIgnoreCase); // Track duplicates

            // Step 4: Process each card in the hand
            foreach (var cardString in cardStrings)
            {
                Card card;

                // Try to parse the card; throw exception if invalid
                try
                {
                    card = ParseCard(cardString);
                }
                catch
                {
                    throw new ArgumentException("Card not recognised");
                }

                // Step 5: Handle Jokers
                if (card.IsJoker)
                {
                    jokerCount++;

                    // Only two Jokers are allowed
                    if (jokerCount > 2)
                        throw new ArgumentException("A hand cannot contain more than two Jokers");

                    // Jokers do not get added to seen cards
                    continue;
                }

                // Step 6: Handle duplicate non-Joker cards
                if (seenCardStrings.Contains(cardString))
                    throw new ArgumentException("Cards cannot be duplicated");

                seenCardStrings.Add(cardString);

                // Step 7: Calculate score for non-Joker cards
                if (!card.IsJoker)
                {
                    totalScore += CalculateCardScore(card);
                }
            }

            // Step 8: Apply multiplier for each Joker (double the total score per Joker)
            totalScore = totalScore * (int)Math.Pow(2, jokerCount);

            return totalScore; // Return final hand score
        }
    }

}
