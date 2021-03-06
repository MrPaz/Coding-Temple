﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Card_Class_02._07._19
{
    class Card
    {
        // properties are qualities of the class, methods are the actions the class can perform
        public string Suit { get; set; }
        public string Value { get; set; }
        
        // constructor method
        public Card(string suit, string value)
        {
            Suit = suit;
            Value = value;
        }

        // need to ask Joe what exactly this does
        public override string ToString()
        {
            return $"{Value}{Suit}";
        }
    }
}
