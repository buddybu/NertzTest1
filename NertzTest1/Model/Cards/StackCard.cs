using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardDeck;
using NertzTest1.Model.Players;

namespace NertzTest1
{
    class StackCard
    {
        private Card _card;
        private Player _owner;

        public Card Card { get { return _card; } }
        public Player Owner { get { return _owner; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="owner"></param>
        public StackCard(Card card, Player owner)
        {
            _card = card;
            _owner = owner;
        }

    }
}
