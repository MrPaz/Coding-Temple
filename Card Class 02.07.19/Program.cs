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
            Console.WriteLine(string.Join(' ', deck.Cards.Select(x => x.Value + x.Suit).ToArray()));
            
            Console.ReadLine();
        }
    }
}