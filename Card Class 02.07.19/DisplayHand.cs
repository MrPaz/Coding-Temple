using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Card_Class_02._07._19
{
    class DisplayHand
    {
        public string playerNumber { get; set; }

        public DisplayHand(string playerNumber, Card[] hand)
        {
            string player = playerNumber;

            Console.WriteLine(playerNumber + string.Join(' ', hand.Select(x => x.ToString())));
        }
    }
}
