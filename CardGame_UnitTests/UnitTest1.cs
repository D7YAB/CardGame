using CardGame;

namespace CardGame_UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Tests that numeric and face value characters are correctly identified as Number or Letter.
        /// </summary>
        [TestCase('2', CharType.Number)]
        [TestCase('3', CharType.Number)]
        [TestCase('4', CharType.Number)]
        [TestCase('5', CharType.Number)]
        [TestCase('6', CharType.Number)]
        [TestCase('7', CharType.Number)]
        [TestCase('8', CharType.Number)]
        [TestCase('9', CharType.Number)]
        [TestCase('T', CharType.Letter)]
        [TestCase('J', CharType.Letter)]
        [TestCase('Q', CharType.Letter)]
        [TestCase('K', CharType.Letter)]
        [TestCase('A', CharType.Letter)]
        public void ParseValidValueChars(char value, CharType expected)
        {
            var result = CardGameService.IsLetterOrNumber(value);

            Assert.That(result, Is.EqualTo(expected),
                $"Expected input value '{value}' to be '{expected}' but was '{result}'");
        }

        /// <summary>
        /// Tests that numeric and face value characters are correctly identified as Number or Letter.
        /// </summary>
        [TestCase('C', CharType.Letter)]
        [TestCase('D', CharType.Letter)]
        [TestCase('S', CharType.Letter)]
        [TestCase('H', CharType.Letter)]
        public void ParseValidSuitChars(char value, CharType expected)
        {
            var result = CardGameService.IsLetterOrNumber(value);

            Assert.That(result, Is.EqualTo(expected),
                $"Expected input value '{value}' to be '{expected}' but was '{result}'");
        }

        /// <summary>
        /// Tests that valid value characters are parsed correctly into the Value enum.
        /// </summary>
        [TestCase('2', Value.Two)]
        [TestCase('3', Value.Three)]
        [TestCase('4', Value.Four)]
        [TestCase('5', Value.Five)]
        [TestCase('6', Value.Six)]
        [TestCase('7', Value.Seven)]
        [TestCase('8', Value.Eight)]
        [TestCase('9', Value.Nine)]
        [TestCase('J', Value.J)]
        [TestCase('Q', Value.Q)]
        [TestCase('K', Value.K)]
        [TestCase('A', Value.A)]
        public void ParseValidValueCharsAsValue(char input, Value expected)
        {
            // Act
            var result = CardGameService.ParseValue(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected),
                $"Expected {input} to parse as {expected} but got {result}");
        }

        /// <summary>
        /// Tests that valid suit characters are parsed correctly into the Suit enum.
        /// </summary>
        [TestCase('C', Suit.C)]
        [TestCase('D', Suit.D)]
        [TestCase('H', Suit.H)]
        [TestCase('S', Suit.S)]
        public void ParseValidSuitCharsAsSuit(char input, Suit expected)
        {
            // Act
            var result = CardGameService.ParseSuit(input);

            // Assert
            Assert.That(result, Is.EqualTo(expected),
                $"Expected input '{input}' to parse as {expected} but got {result}");
        }

        /// <summary>
        /// Tests parsing of all valid club cards into the Card object.
        /// </summary>
        // Clubs
        [TestCase("2C", Value.Two, Suit.C)]
        [TestCase("3C", Value.Three, Suit.C)]
        [TestCase("4C", Value.Four, Suit.C)]
        [TestCase("5C", Value.Five, Suit.C)]
        [TestCase("6C", Value.Six, Suit.C)]
        [TestCase("7C", Value.Seven, Suit.C)]
        [TestCase("8C", Value.Eight, Suit.C)]
        [TestCase("9C", Value.Nine, Suit.C)]
        [TestCase("JC", Value.J, Suit.C)]
        [TestCase("QC", Value.Q, Suit.C)]
        [TestCase("KC", Value.K, Suit.C)]
        [TestCase("AC", Value.A, Suit.C)]
        public void ParseValidClubStringsAsCard(string cardString, Value expectedValue, Suit expectedSuit)
        {
            var card = CardGameService.ParseCard(cardString);

            Assert.That(card.Value, Is.EqualTo(expectedValue));
            Assert.That(card.Suit, Is.EqualTo(expectedSuit));
        }

        /// <summary>
        /// Tests parsing of all valid diamond cards into the Card object.
        /// </summary>
        // Diamonds
        [TestCase("2D", Value.Two, Suit.D)]
        [TestCase("3D", Value.Three, Suit.D)]
        [TestCase("4D", Value.Four, Suit.D)]
        [TestCase("5D", Value.Five, Suit.D)]
        [TestCase("6D", Value.Six, Suit.D)]
        [TestCase("7D", Value.Seven, Suit.D)]
        [TestCase("8D", Value.Eight, Suit.D)]
        [TestCase("9D", Value.Nine, Suit.D)]
        [TestCase("JD", Value.J, Suit.D)]
        [TestCase("QD", Value.Q, Suit.D)]
        [TestCase("KD", Value.K, Suit.D)]
        [TestCase("AD", Value.A, Suit.D)]
        public void ParseValidDiamondStringsAsCard(string cardString, Value expectedValue, Suit expectedSuit)
        {
            var card = CardGameService.ParseCard(cardString);

            Assert.That(card.Value, Is.EqualTo(expectedValue));
            Assert.That(card.Suit, Is.EqualTo(expectedSuit));
        }

        /// <summary>
        /// Tests parsing of all valid heart cards into the Card object.
        /// </summary>
        // Hearts
        [TestCase("2H", Value.Two, Suit.H)]
        [TestCase("3H", Value.Three, Suit.H)]
        [TestCase("4H", Value.Four, Suit.H)]
        [TestCase("5H", Value.Five, Suit.H)]
        [TestCase("6H", Value.Six, Suit.H)]
        [TestCase("7H", Value.Seven, Suit.H)]
        [TestCase("8H", Value.Eight, Suit.H)]
        [TestCase("9H", Value.Nine, Suit.H)]
        [TestCase("JH", Value.J, Suit.H)]
        [TestCase("QH", Value.Q, Suit.H)]
        [TestCase("KH", Value.K, Suit.H)]
        [TestCase("AH", Value.A, Suit.H)]
        public void ParseValidHeartStringsAsCard(string cardString, Value expectedValue, Suit expectedSuit)
        {
            var card = CardGameService.ParseCard(cardString);

            Assert.That(card.Value, Is.EqualTo(expectedValue));
            Assert.That(card.Suit, Is.EqualTo(expectedSuit));
        }

        /// <summary>
        /// Tests parsing of all valid spade cards into the Card object.
        /// </summary>
        // Spades
        [TestCase("2S", Value.Two, Suit.S)]
        [TestCase("3S", Value.Three, Suit.S)]
        [TestCase("4S", Value.Four, Suit.S)]
        [TestCase("5S", Value.Five, Suit.S)]
        [TestCase("6S", Value.Six, Suit.S)]
        [TestCase("7S", Value.Seven, Suit.S)]
        [TestCase("8S", Value.Eight, Suit.S)]
        [TestCase("9S", Value.Nine, Suit.S)]
        [TestCase("JS", Value.J, Suit.S)]
        [TestCase("QS", Value.Q, Suit.S)]
        [TestCase("KS", Value.K, Suit.S)]
        [TestCase("AS", Value.A, Suit.S)]
        public void ParseValidSpadeStringsAsCard(string cardString, Value expectedValue, Suit expectedSuit)
        {
            var card = CardGameService.ParseCard(cardString);

            Assert.That(card.Value, Is.EqualTo(expectedValue));
            Assert.That(card.Suit, Is.EqualTo(expectedSuit));
        }

        /// <summary>
        /// Tests that the Joker card is recognized correctly.
        /// </summary>
        [TestCase("JR")]
        public void ParseValidJokerStringAsCard(string cardString)
        {
            var card = CardGameService.ParseCard(cardString);

            Assert.That(card.IsJoker, Is.True);
        }


        /// <summary>
        /// Tests that each card's score is calculated correctly.
        /// </summary>
        [TestCase("2C", 2)]
        [TestCase("3C", 3)]
        [TestCase("4C", 4)]
        [TestCase("5C", 5)]
        [TestCase("6C", 6)]
        [TestCase("7C", 7)]
        [TestCase("8C", 8)]
        [TestCase("9C", 9)]
        [TestCase("JC", 11)]
        [TestCase("QC", 12)]
        [TestCase("KC", 13)]
        [TestCase("AC", 14)]

        [TestCase("2D", 4)]
        [TestCase("3D", 6)]
        [TestCase("4D", 8)]
        [TestCase("5D", 10)]
        [TestCase("6D", 12)]
        [TestCase("7D", 14)]
        [TestCase("8D", 16)]
        [TestCase("9D", 18)]
        [TestCase("JD", 22)]
        [TestCase("QD", 24)]
        [TestCase("KD", 26)]
        [TestCase("AD", 28)]

        [TestCase("2H", 6)]
        [TestCase("3H", 9)]
        [TestCase("4H", 12)]
        [TestCase("5H", 15)]
        [TestCase("6H", 18)]
        [TestCase("7H", 21)]
        [TestCase("8H", 24)]
        [TestCase("9H", 27)]
        [TestCase("JH", 33)]
        [TestCase("QH", 36)]
        [TestCase("KH", 39)]
        [TestCase("AH", 42)]

        [TestCase("2S", 8)]
        [TestCase("3S", 12)]
        [TestCase("4S", 16)]
        [TestCase("5S", 20)]
        [TestCase("6S", 24)]
        [TestCase("7S", 28)]
        [TestCase("8S", 32)]
        [TestCase("9S", 36)]
        [TestCase("JS", 44)]
        [TestCase("QS", 48)]
        [TestCase("KS", 52)]
        [TestCase("AS", 56)]
        public void CalculateAllValidCardScore(string cardString, int expectedScore)
        {
            var card = CardGameService.ParseCard(cardString);

            int score = CardGameService.CalculateCardScore(card);

            Assert.That(score, Is.EqualTo(expectedScore),
                $"Expected score for '{cardString}' to be {expectedScore} but got {score}");
        }

        /// <summary>
        /// Tests that Joker cards have a score of zero.
        /// </summary>
        [TestCase("JR", 0)]
        public void CalculateJokerCardScore(string cardString, int expectedScore)
        {
            var card = CardGameService.ParseCard(cardString);

            int score = CardGameService.CalculateCardScore(card);

            Assert.That(score, Is.EqualTo(expectedScore),
                $"Expected score for '{cardString}' to be {expectedScore} but got {score}");
        }

        /// <summary>
        /// Tests that valid hands with multiple cards calculate the correct total score.
        /// </summary>
        [TestCase("2C,5H,AS", 73)]
        [TestCase("JC,QD,KH,AC", 88)]
        [TestCase("2C,3C,4C,5C,6C,7C,8C,9C,JC,QC,KC,AC", 94)]
        [TestCase("2D,3H,4S", 29)]
        [TestCase("AH,KH,QH,JH,9H", 177)]
        public void CalculateValidHandScore(string hand, int expectedScore)
        {
            int totalScore = CardGameService.CalculateHandScore(hand);

            Assert.That(totalScore, Is.EqualTo(expectedScore),
                $"Expected total score for hand '{hand}' to be {expectedScore} but got {totalScore}");
        }

        /// <summary>
        /// Tests hand scoring for scenario 1 in requirements.
        /// </summary>
        [TestCase("2C", 2)]
        [TestCase("2D", 4)]
        [TestCase("2H", 6)]
        [TestCase("2S", 8)]

        [TestCase("TC", 10)]
        [TestCase("JC", 11)]
        [TestCase("QC", 12)]
        [TestCase("KC", 13)]
        [TestCase("AC", 14)]
        [TestCase("3C,4C", 7)]
        [TestCase("TC,TD,TH,TS", 100)]
        public void CalculateHandScoreScenario1(string hand, int expectedScore)
        {
            int result = CardGameService.CalculateHandScore(hand);
            Assert.That(result, Is.EqualTo(expectedScore));
        }

        /// <summary>
        /// Tests scoring hands that include Joker cards.
        /// </summary>
        [TestCase("JR", 0)]
        [TestCase("JR,JR", 0)]
        [TestCase("2C,JR", 4)]
        [TestCase("JR,2C,JR", 8)]
        [TestCase("TC,TD,JR,TH,TS", 200)]
        [TestCase("TC,TD,JR,TH,TS,JR", 400)]
        public void CalculateHandScoreWithJoker(string hand, int expectedScore)
        {
            int result = CardGameService.CalculateHandScore(hand);
            Assert.That(result, Is.EqualTo(expectedScore));
        }

        /// <summary>
        /// Tests that invalid card values throw a Card not recognised exception.
        /// </summary>
        [TestCase("1S", "Card not recognised")]
        [TestCase("2B", "Card not recognised")]
        [TestCase("2S,1S", "Card not recognised")]
        public void ParseHandInvalidCard(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that duplicate cards throw a Cards cannot be duplicated exception.
        /// </summary>
        [TestCase("3H,3H", "Cards cannot be duplicated")]
        [TestCase("4D,5D,4D", "Cards cannot be duplicated")]
        public void ParseHandDuplicateCards(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that more than two Jokers throw an exception.
        /// </summary>
        [TestCase("JR,JR,JR", "A hand cannot contain more than two Jokers")]
        public void ParseHandTooManyJokers(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that invalid separators in a hand throw an exception.
        /// </summary>
        [TestCase("2S|3D", "Invalid input string")]
        public void ParseHandInvalidFormat(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that empty hand strings throw an Invalid input string exception.
        /// </summary>
        [TestCase("", "Invalid input string")]
        [TestCase("   ", "Invalid input string")]
        public void ParseHandEmptyHand(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that invalid symbols in hand strings throw an exception.
        /// </summary>
        [TestCase("2C$3D", "Invalid input string")]
        [TestCase("5H@7S", "Invalid input string")]
        [TestCase("9C#JD", "Invalid input string")]
        public void ParseHandInvalidSymbols(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that double commas in the hand string throw an exception.
        /// </summary>
        [TestCase("2C,,3D", "Invalid input string")]
        [TestCase("JC,,QC", "Invalid input string")]
        public void ParseHandDoubleComma(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that unknown card values throw an exception.
        /// </summary>
        [TestCase("1C,2D", "Card not recognised")]
        [TestCase("0H,3S", "Card not recognised")]
        [TestCase("XB,JD", "Card not recognised")]
        public void ParseHandUnknownCardValues(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests mixed invalid scenarios for cards, duplicates, and jokers.
        /// </summary>
        [TestCase("2C,JR,1S", "Card not recognised")]
        [TestCase("3H,3H,JR", "Cards cannot be duplicated")]
        [TestCase("JR,JR,JR,4S", "A hand cannot contain more than two Jokers")]
        public void ParseHandMixedInvalidCases(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }

        /// <summary>
        /// Tests that lowercase value characters parse correctly.
        /// </summary>
        [TestCase('t', Value.T)]
        [TestCase('j', Value.J)]
        [TestCase('q', Value.Q)]
        [TestCase('k', Value.K)]
        [TestCase('a', Value.A)]
        public void ParseValueLowercaseOrDigit(char input, Value expected)
        {
            var result = CardGameService.ParseValue(input);

            Assert.That(result, Is.EqualTo(expected),
                $"Expected '{input}' to parse as {expected} but got {result}");
        }

        /// <summary>
        /// Tests that lowercase suit characters parse correctly.
        /// </summary>
        [TestCase('c', Suit.C)]
        [TestCase('d', Suit.D)]
        [TestCase('h', Suit.H)]
        [TestCase('s', Suit.S)]
        public void ParseSuitLowercase(char input, Suit expected)
        {
            var result = CardGameService.ParseSuit(input);

            Assert.That(result, Is.EqualTo(expected),
                $"Expected '{input}' to parse as {expected} but got {result}");
        }

        /// <summary>
        /// Tests that lowercase card strings parse correctly into Value and Suit.
        /// </summary>
        [TestCase("2c", Value.Two, Suit.C)]
        [TestCase("3d", Value.Three, Suit.D)]
        [TestCase("jh", Value.J, Suit.H)]
        [TestCase("qs", Value.Q, Suit.S)]
        [TestCase("as", Value.A, Suit.S)]
        public void ParseCardLowercaseString(string cardString, Value expectedValue, Suit expectedSuit)
        {
            var card = CardGameService.ParseCard(cardString);

            Assert.That(card.Value, Is.EqualTo(expectedValue));
            Assert.That(card.Suit, Is.EqualTo(expectedSuit));
        }

        /// <summary>
        /// Tests that card strings with leading or trailing whitespace parse correctly.
        /// </summary>
        [TestCase(" 2C", Value.Two, Suit.C)]
        [TestCase("3D ", Value.Three, Suit.D)]
        [TestCase("  JH ", Value.J, Suit.H)]
        [TestCase("  qs", Value.Q, Suit.S)]
        public void ParseCard_WithWhitespace_ParsesCorrectly(string cardString, Value expectedValue, Suit expectedSuit)
        {
            var card = CardGameService.ParseCard(cardString.Trim());

            Assert.That(card.Value, Is.EqualTo(expectedValue));
            Assert.That(card.Suit, Is.EqualTo(expectedSuit));
        }

        // <summary>
        /// Tests that hand strings with extra whitespace between cards are parsed correctly.
        /// </summary>
        [TestCase("2C , 3D, 4H", 20)]
        [TestCase(" JC , QD , KH ", 74)]
        public void CalculateHandScore_WithWhitespace_ParsesCorrectly(string hand, int expectedScore)
        {
            int totalScore = CardGameService.CalculateHandScore(hand);
            Assert.That(totalScore, Is.EqualTo(expectedScore));
        }

        /// <summary>
        /// Tests that hand strings with invalid whitespace or empty cards throw exceptions.
        /// </summary>
        [TestCase("2C,, 3D", "Invalid input string")]
        [TestCase(" ,JC, QD", "Invalid input string")]
        [TestCase("4H, , 5S", "Invalid input string")]
        public void CalculateHandScore_WithInvalidWhitespace_Throws(string hand, string expectedMessage)
        {
            var ex = Assert.Throws<ArgumentException>(() => CardGameService.CalculateHandScore(hand));
            Assert.That(ex.Message, Is.EqualTo(expectedMessage));
        }
    }
}
