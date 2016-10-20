using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CardDeck
{
    public enum Suits
    {
        [CardDeck.Description("♠")]
        Spades=0,
        [CardDeck.Description("♥")]
        Clubs = 1,
        [CardDeck.Description("♦")]
        Diamonds = 2,
        [CardDeck.Description("♣")]
        Hearts = 3,
    }
}
