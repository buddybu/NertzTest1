using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CardDeck;

namespace NertzTest1.Model.Players
{
     class Player : BasePlayer
    {
        public Player(string name, Random random, Game gameInProgress) :
            base(name, random, gameInProgress)
        {
        }

        
    }
}
