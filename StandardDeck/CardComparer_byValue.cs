﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardCardDeck
{
    class CardComparer_byValue : IComparer<Card>

    {
        public int Compare(Card x, Card y)
        {
            int compareResult = 0;
            if (x.CardValue < y.CardValue)
                compareResult = -1;
            else if (x.CardValue > y.CardValue)
                compareResult = 1;
            else
            {
                if (x.CardSuit < y.CardSuit)
                    compareResult = -1;
                else if (x.CardSuit > y.CardSuit)
                    compareResult = 1;
            }

            return compareResult;
        }
    }
}
