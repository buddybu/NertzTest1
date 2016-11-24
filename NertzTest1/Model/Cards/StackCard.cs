using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardCardDeck;
using NertzTest1.Model.Players;

namespace NertzTest1.Model.Cards
{
    class StackCard
    {
        private Card _card;
        private HumanPlayer _owner;

        public Card Card { get { return _card; } }
        public HumanPlayer Owner { get { return _owner; } }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card"></param>
        /// <param name="owner"></param>
        public StackCard(Card card, HumanPlayer owner)
        {
            _card = card;
            _owner = owner;
        }

    }
}
