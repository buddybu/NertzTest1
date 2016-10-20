using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CardDeck
{
    public enum Values
    {
        [CardDeck.Description("A")]
        Ace=1,
        [CardDeck.Description("2")]
        Two = 2,
        [CardDeck.Description("3")]
        Three = 3,
        [CardDeck.Description("4")]
        Four = 4,
        [CardDeck.Description("5")]
        Five = 5,
        [CardDeck.Description("6")]
        Six = 6,
        [CardDeck.Description("7")]
        Seven = 7,
        [CardDeck.Description("8")]
        Eight = 8,
        [CardDeck.Description("9")]
        Nine = 9,
        [CardDeck.Description("10")]
        Ten = 10,
        [CardDeck.Description("J")]
        Jack = 11,
        [CardDeck.Description("Q")]
        Queen = 12,
        [CardDeck.Description("K")]
        King = 13,

    }
}
