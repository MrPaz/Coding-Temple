using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Class_02._07._19
{
    class PlayGame
    {
        public int PlayerTurn { get; set; }
        private Deck _deck;
        Card[] _hand1 = null;
        Card[] _hand2 = null;
        bool isWinner = false;

        public PlayGame(Deck deck)
        {
            _deck = deck;
            _hand1 = deck.Deal();
            _hand2 = deck.Deal();

            DisplayHand("Player 1 Hand: ", _hand1); 
            DisplayHand("Player 2 Hand: ", _hand2);
            // PlayGame();
            deck.UpCard();
            PlayerTurn = 0;

            while(isWinner == false)
            {
                if (PlayerTurn % 2 == 0)
                {
                    Console.WriteLine("*** PLAYER 1 TURN ***");
                    DisplayHand("Player 1 Hand: ", _hand1);
                    Console.WriteLine("Player 1, enter \"T\" to take the upcard or \"D\" to draw from the deck.");
                }
                else
                {
                    Console.WriteLine("*** PLAYER 2 TURN ***");
                    DisplayHand("Player 2 Hand: ", _hand2);
                    Console.WriteLine("Player 2, enter \"T\" to take the upcard or \"D\" to draw from the deck.");
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
                Console.WriteLine("Invalid selection. Please enter \"T\" to take the upcard or \"D\" to draw from the deck.");
                userInput = Console.ReadLine();
            }
            if (userInput == "t")
            {
                userSelection = _deck.upcard;
                Discard();
            }
            else
            {
                userSelection = _deck.Deal(1).First();
                Console.WriteLine(userSelection);
                Discard();
            }
        }
        private void Discard()
        {
            Console.WriteLine("Enter 1, 2, or 3 to discard the 1st, 2nd or 3rd card from your hand, or 0 to discard your draw.");
            string discardInput = Console.ReadLine();
            while (discardInput != "1" && discardInput != "2" && discardInput != "3" && discardInput != "0")
            {
                Console.WriteLine("Invalid selection. Please enter 1, 2, or 3 to discard the 1st, 2nd or 3rd card from your hand, or 0 to discard your draw.");
                discardInput = Console.ReadLine();
            }
            int parsedDiscardInput = int.Parse(discardInput) - 1;
            if (discardInput == "0")
            {
                _deck.upcard = userSelection;
                if (PlayerTurn == 0)
                {
                    DisplayHand("Player 1 Hand: ", _hand1);
                }
                else
                {
                    DisplayHand("Player 2 Hand: ", _hand2);
                }
                Console.WriteLine("Upcard: " + _deck.upcard);
                PlayerTurn = (PlayerTurn + 1) % 2;
            }
            else if (PlayerTurn == 0)
            {
                Card temp = _hand1[parsedDiscardInput];
                _hand1[parsedDiscardInput] = userSelection;
                _deck.upcard = temp ;
                DisplayHand("Player 1 Hand: ", _hand1);
                Console.WriteLine("Upcard: " + _deck.upcard);
                PlayerTurn = (PlayerTurn + 1) % 2;
            }
            else
            {
                Card temp = _hand2[parsedDiscardInput];
                _hand2[parsedDiscardInput] = userSelection;
                _deck.upcard = temp;
                DisplayHand("Player 2 Hand: ", _hand2);
                Console.WriteLine("Upcard: " + _deck.upcard);
                PlayerTurn = (PlayerTurn + 1) % 2;
            }
        }

        public static void DisplayHand(string playerNumber, Card[] hand)
        {
            string player = playerNumber;

            Console.WriteLine(playerNumber + string.Join(' ', hand.Select(x => x.ToString())));
        }

        public void IsWinner(Card[] hand)
        {
            var tempHand = hand.OrderBy(x => x.Value).ToArray();
            //Array.Sort(hand);
            //if (hand.Value[0] == hand.Value[1] && hand.Value[0] == hand.Value[2])
            if (tempHand.All(x => tempHand[0].Value == x.Value))
            {
                isWinner = true;
                Console.WriteLine("***** GIN!!! *****");
                Console.WriteLine("***** Congratulation you won!!! *****");
            }
            else if ((tempHand.All(y => tempHand[0].Suit == y.Suit)) 
                && (tempHand[0].Value + 1 == tempHand[1].Value && tempHand[1].Value + 1 == tempHand[2].Value)  )
            {
                isWinner = true;
                Console.WriteLine("***** GIN!!! *****");
                Console.WriteLine("***** Congratulation you won!!! *****");
            }
            else
            {
                isWinner = false;
            }
        }
    }
}
