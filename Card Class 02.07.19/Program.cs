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
            PlayGame game = new PlayGame(deck);
            // Console.WriteLine(string.Join(' ', deck.Cards.Select(x => x.Value + x.Suit).ToArray()));
            Console.ReadLine();
        }
    }
}


//3 card gin rummy
// step one deal 3 cards to each player, display hands  X
// giant while loop, while winner = false play game     X
// step two display up card, player opposite dealer gets first choice of up card, then dealer  --simplified, player1 always starts
// if player takes, card, must discard.  discard becomes upcard     X
// if player draws from deck, deck-1, player must discard.      X
