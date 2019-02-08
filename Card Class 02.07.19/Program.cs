using System;
using System.Linq;

namespace Card_Class_02._07._19
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();
            
            deck.Shuffle();
            // Console.WriteLine(string.Join(' ', deck.Cards.Select(x => x.Value + x.Suit).ToArray()));

            PlayGame game = new PlayGame(deck);
            
            Console.ReadLine();
        }
    }
}


//3 card gin rummy
// step one deal 3 cards to each player, display hands
// giant while loop, while winner = false play game
// step two display up card, player opposite dealer gets first choice of up card, then dealer
// if player takes, card, must discard.  discard becomes upcard
// if player draws from deck, deck-1, player must discard.
