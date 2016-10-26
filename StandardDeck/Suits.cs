using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StandardCardDeck
{
    public enum Suits
    {
        [StandardCardDeck.Description("♠")]
        Spades=0,
        [StandardCardDeck.Description("♥")]
        Clubs = 1,
        [StandardCardDeck.Description("♦")]
        Diamonds = 2,
        [StandardCardDeck.Description("♣")]
        Hearts = 3,
    }
}
