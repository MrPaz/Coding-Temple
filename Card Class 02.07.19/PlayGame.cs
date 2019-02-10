using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Class_02._07._19
{
    class PlayGame
    {
        // properties
        public int PlayerTurn { get; set; } //does this need get/set -- never called outside of this class?
        public static string Message { get; private set; }

        private Deck _deck; //field
        Card[] _hand1 = null; //field
        Card[] _hand2 = null; //field
        bool isWinner = false; //field
        string winner = null;

        // Console.WriteLine("How many points do you want to play to? (default = 100)");
        // int points = int.Parse(Console.ReadLine());

        // constructor => sets up game, creates loop to go through until a player has won
        public PlayGame(Deck deck)
        {
            _deck = deck; // use _deck because both Deck and deck are already used
            _hand1 = deck.Deal(); // ask Joe why used _hand1 here
            _hand2 = deck.Deal();

            DisplayHand("Player 1 Hand: ", _hand1);
            DisplayHand("Player 2 Hand: ", _hand2);
            deck.UpCard();
            PlayerTurn = 0;
            Message = "enter \"t\" to take the upcard or \"d\" to draw from the deck.";

            while (isWinner == false)
            {
                if (PlayerTurn % 2 == 0)
                {
                    Console.WriteLine("*** PLAYER 1 TURN ***");
                    DisplayHand("Player 1 Hand: ", _hand1);
                    Console.WriteLine("Player 1, " + Message);

                }
                else
                {
                    Console.WriteLine("*** PLAYER 2 TURN ***");  // this is very similar to above, could probably be condensed (DRY)
                    DisplayHand("Player 2 Hand: ", _hand2);
                    Console.WriteLine("Player 2, " + Message);
                }
                UserInput();
            }
        }

        Card userSelection = null;

        private void UserInput()
        {
            string userInput = Console.ReadLine();
            while (userInput.ToLower() != "t" && userInput.ToLower() != "d")
            {
                Console.WriteLine("Invalid selection. Please " + PlayGame.Message);
                userInput = Console.ReadLine();
            }
            if (userInput == "t")
            {
                userSelection = _deck.upcard;
                Discard();
            }
            else
            {
                userSelection = _deck.Deal(1).First();  // why do I need First here? wouldn't _deck.Deal(1) do the same thing? Deal does Take(1)
                Console.WriteLine(userSelection);
                Discard();
            }
        }
        private void Discard()
        {
            string message = "Enter 1, 2, or 3 to discard the 1st, 2nd or 3rd card from your hand, or 0 to discard your draw.";
            Console.WriteLine(message);
            string discardInput = Console.ReadLine();
            while (discardInput != "1" && discardInput != "2" && discardInput != "3" && discardInput != "0")
            {
                Console.WriteLine("Invalid selection. " + message);
                discardInput = Console.ReadLine();
            }

            int parsedDiscardInput = int.Parse(discardInput) - 1;

            if (discardInput == "0")
            {
                // _deck.upcard = userSelection;  // does this cause error if user presses 0 but took from deck?
                if (PlayerTurn == 0)
                {
                    DisplayHand("Player 1 Hand: ", _hand1);
                }
                else
                {
                    DisplayHand("Player 2 Hand: ", _hand2);
                }
                _deck.upcard = userSelection;
                Console.WriteLine("Upcard: " + _deck.upcard);
                PlayerTurn = (PlayerTurn + 1) % 2;
            }
            else if (PlayerTurn == 0)
            {
                Card temp = _hand1[parsedDiscardInput];
                _hand1[parsedDiscardInput] = userSelection;
                _deck.upcard = temp;
                DisplayHand("Player 1 Hand: ", _hand1);
                if (IsWinner(_hand1) == true) {
                    winner = "player1";
                    return; }
                Console.WriteLine("Upcard: " + _deck.upcard);
                PlayerTurn = (PlayerTurn + 1) % 2;
            }
            else
            {
                Card temp = _hand2[parsedDiscardInput]; // just like above code --> DRY
                _hand2[parsedDiscardInput] = userSelection;
                _deck.upcard = temp;
                DisplayHand("Player 2 Hand: ", _hand2);
                if (IsWinner(_hand2) == true) {
                    winner = "player2";
                    return; }
                Console.WriteLine("Upcard: " + _deck.upcard);
                PlayerTurn = (PlayerTurn + 1) % 2;
            }
        }

        public static void DisplayHand(string playerNumber, Card[] hand)
        {
            string player = playerNumber;

            Console.WriteLine(playerNumber + string.Join(' ', hand.Select(x => x.ToString())));
        }

        public bool IsWinner(Card[] hand)
        {
            var cardValueRankings = new Dictionary<string, int>
            {
                {"A", 1 },{"2", 2 }, {"3", 3 },{"4", 4 },{"5", 5 }, {"6", 6 }, {"7", 7 }, {"8", 8 },{"9",9 }, {"10", 10 },{"J", 11 },{"Q", 12 },{"K",13 },
            };
            var tempHand = hand.OrderBy(x => cardValueRankings[x.Value]).ToArray();
            //Array.Sort(hand);
            //if (hand.Value[0] == hand.Value[1] && hand.Value[0] == hand.Value[2])
            if (tempHand.All(x => tempHand[0].Value == x.Value))
            {
                WinMessage();
                isWinner = true;
                return true;

            }
            else if ((tempHand.All(y => tempHand[0].Suit == y.Suit))
                && (cardValueRankings[tempHand[0].Value] + 1 == cardValueRankings[tempHand[1].Value]
                && cardValueRankings[tempHand[1].Value] + 1 == cardValueRankings[tempHand[2].Value]))
            {
                WinMessage(); // DRY
                isWinner = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public void WinMessage()
        {
            Console.WriteLine("***** GIN!!! *****");
            Console.WriteLine("***** Congratulation you won!!! *****");
        }
        public int Points(Card[] hand) // must return gin plus points from *opponent's* hand
        {
            int points = 0;
            int gin = 25;
            var cardPointValues = new Dictionary<string, int>
            {
                { "A", 1 },{ "2", 2 }, { "3", 3 },{ "4", 4 },{ "5", 5 }, { "6", 6 }, { "7", 7 }, { "8", 8 },{ "9",9 }, { "10", 10 },{ "J", 10 },{ "Q", 10 },{ "K",10 },
            };
            for (int i = 0; i < hand.Length; i++)
            {
                points += cardPointValues[hand[i].Value];
            }
            return gin + points;
        }
        public int Score()
        {
            int player1points = 0;
            int player2points = 0;
            if (winner == "player1")
            {
                player1points += Points(_hand2);
            }
            else
            {
                player2points += Points(_hand1);
            }
            Console.WriteLine($"Player 1: {player1points} | Player 2: {player2points}");
            return Math.Max(player1points, player2points);
        }
}
}
