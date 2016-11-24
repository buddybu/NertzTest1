using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardCardDeck;
using NertzTest1.Model.Players;

namespace NertzTest1.Model.Cards
{
    class CardStack
    {
        private List<StackCard> cardsInStack;

        public bool Flipped { get; private set; }

        public CardStack(Card card, HumanPlayer owner)
        {
            cardsInStack = new List<StackCard>();
            AddCard(card, owner);
            Flipped = false;
        }

        public void AddCard(Card card, HumanPlayer owner)
        {
            cardsInStack.Add(new StackCard(card, owner));
            if (card.CardValue == Values.King)
                Flipped = true;
        }

        public Card GetTopCard()
        {
            return cardsInStack[cardsInStack.Count - 1].Card;
        }

        public Suits GetSuit()
        {
            return cardsInStack[0].Card.CardSuit;
        }

        public Values GetTopValue()
        {
            return cardsInStack[cardsInStack.Count-1].Card.CardValue;
        }

        public int PlayerCardCount(HumanPlayer player)
        {
            int cardCount = 0;
            foreach(StackCard card in cardsInStack)
            {
                if (card.Owner == player)
                    cardCount++;
            }
            return cardCount;
        }
    }
}
