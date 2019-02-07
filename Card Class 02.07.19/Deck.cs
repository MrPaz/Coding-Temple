using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Class_02._07._19
{
    class Deck
    {
        // this is a special type of method called a constructor, it's run every time you create a deck of cards
        public Deck()
        {
            //Building the Deck of Cards:
            string[] suits = { "Spades", "Clubs", "Hearts", "Diamonds" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };
            Card[] cards = new Card[52];
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    cards[(i * values.Length) + j] = new Card();
                    cards[(i * values.Length) + j].Suit = suits[i];
                    cards[(i * values.Length) + j].Value = values[j];
                }
            }
        }

        public Card[] Cards { get; set; }

        public void Shuffle()
        {
            Random rng = new Random();
            for (int i = 0; i < this.Cards.Length * 1000000; i++)
            {

                int position1 = rng.Next(0, this.Cards.Length);
                int position2 = rng.Next(0, this.Cards.Length);
                Card temp = this.Cards[position1];
                this.Cards[position1] = this.Cards[position2];
                this.Cards[position2] = temp;
            }
            return this.Cards;
        }
    }
}
