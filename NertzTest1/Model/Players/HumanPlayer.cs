using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StandardCardDeck;

namespace NertzTest1.Model.Players
{
     class HumanPlayer : BaseNertzPlayer
    {
        public HumanPlayer(string name, Random random, int shuffleCount, Game gameInProgress) :
            base(name, random, shuffleCount, gameInProgress)
        {
        }

        
    }
}
