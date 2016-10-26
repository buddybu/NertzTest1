using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace StandardCardDeck
{
    public enum Values
    {
        [StandardCardDeck.Description("A")]
        Ace=1,
        [StandardCardDeck.Description("2")]
        Two = 2,
        [StandardCardDeck.Description("3")]
        Three = 3,
        [StandardCardDeck.Description("4")]
        Four = 4,
        [StandardCardDeck.Description("5")]
        Five = 5,
        [StandardCardDeck.Description("6")]
        Six = 6,
        [StandardCardDeck.Description("7")]
        Seven = 7,
        [StandardCardDeck.Description("8")]
        Eight = 8,
        [StandardCardDeck.Description("9")]
        Nine = 9,
        [StandardCardDeck.Description("10")]
        Ten = 10,
        [StandardCardDeck.Description("J")]
        Jack = 11,
        [StandardCardDeck.Description("Q")]
        Queen = 12,
        [StandardCardDeck.Description("K")]
        King = 13,

    }
}
