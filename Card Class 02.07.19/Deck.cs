using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Card_Class_02._07._19
{
    class Deck
    {
        // this is a special type of method called a constructor, it's run every time you create a deck of cards
        public Deck()
        {
            //Building the Deck of Cards:
            string[] suits = { "s", "c", "h", "d" };
            string[] values = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            Cards = new Card[52];
            for (int i = 0; i < suits.Length; i++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    Cards[(i * values.Length) + j] = new Card(suits[i], values[j]);
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
        }

        const int handSize = 3;
        public int cardsDealt = 0;

        public Card[] Deal(int numberOfCardsToDeal = handSize)
        {
            Card[] cardsToDeal = Cards.Skip(cardsDealt).Take(numberOfCardsToDeal).ToArray();
            cardsDealt += numberOfCardsToDeal;
            return cardsToDeal;
            //Card[] hand1 = Cards.Take(handSize).ToArray();
            //cardsDealt += hand1.Length;
            //DisplayHand player1 = new DisplayHand("Player 1 Hand: ", hand1);

            //Card[] hand2 = Cards.Skip(cardsDealt).Take(handSize).ToArray();
            //cardsDealt += hand2.Length;
            //DisplayHand player2 = new DisplayHand("Player 2 Hand: ", hand2);
        }

        public Card upcard = null;

        public Card UpCard()
        {
            upcard = Cards.Skip(cardsDealt).First();
            Console.WriteLine("Upcard: " + upcard);
            cardsDealt += 1;
            return upcard;
        }
    }
    
}
