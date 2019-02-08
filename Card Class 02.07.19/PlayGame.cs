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

        public PlayGame(Deck deck)
        {
            _deck = deck;
            _hand1 = deck.Deal();
            _hand2 = deck.Deal();

            DisplayHand player1 = new DisplayHand("Player 1 Hand: ", _hand1); 
            DisplayHand player2 = new DisplayHand("Player 2 Hand: ", _hand2);
            // PlayGame();
            deck.UpCard();
            PlayerTurn = 1;
            bool isWinner = false;

            while(isWinner == false)
            {
                if (PlayerTurn % 2 != 0)
                {
                    Console.WriteLine("Player 1, press\"T\" to take the upcard or \"D\" to draw from the deck.");
                }
                else
                {
                    Console.WriteLine("Player 2, press\"T\" to take the upcard or \"D\" to draw from the deck.");
                }
                UserInput();
            }
        }

        Card playerSelection = null;

        private void UserInput()
        {
            string userInput = Console.ReadLine();
            while (userInput.ToLower() != "t" && userInput.ToLower() != "d")
            {
                Console.WriteLine("Invalid selection. Please press\"T\" to take the upcard or \"D\" to draw from the deck.");
                userInput = Console.ReadLine();
            }
            if (userInput == "t")
            {
                playerSelection = _deck.upcard;
                Discard();
            }
            else
            {
                playerSelection = _deck.Deal(1).First();
                Console.WriteLine(playerSelection);
                Discard();
            }
        }
        private void Discard()
        {
            Console.WriteLine("Press 1, 2, or 3 to discard");
            string discardInput = Console.ReadLine();
            while (discardInput != "1" && discardInput != "2" && discardInput != "3")
            {
                Console.WriteLine("Invalid selection. Please press 1, 2, or 3 to discard");
                discardInput = Console.ReadLine();
            }
            int parsedDiscardInput = int.Parse(discardInput) - 1;
            if (PlayerTurn == 1)
            {
                Card temp = _hand1[parsedDiscardInput];
                _hand1[parsedDiscardInput] = playerSelection;
                _deck.upcard = temp ;
                Console.WriteLine("Upcard: " + _deck.upcard);
                DisplayHand player1 = new DisplayHand("Player 1 Hand: ", _hand1);
            }
            else
            {
                Card temp = _hand2[parsedDiscardInput];
                _hand2[parsedDiscardInput] = playerSelection;
                _deck.upcard = temp;
                Console.WriteLine("Upcard: " + _deck.upcard);
                DisplayHand player1 = new DisplayHand("Player 1 Hand: ", _hand2);
            }
            PlayerTurn += 1;
        }
    }
}
