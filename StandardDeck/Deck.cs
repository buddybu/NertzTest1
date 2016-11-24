using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StandardCardDeck
{
    public class Deck
    {
        private List<Card> cards;
        private Random random;

        public Deck(Random random)
        {
            this.random = random;
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit ++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card((Suits)suit, (Values)value));
                }
            }
        }

        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count { get { return cards.Count; } }

        public bool Add(Card cardToAdd)
        {
            bool result = false;
            if (!cards.Contains(cardToAdd))
            {
                result = true;
                cards.Add(cardToAdd);
            }
            return result;
        }

        public Card Deal(int index)
        {
            Card cardToDeal = cards[index];
            cards.RemoveAt(index);
            return cardToDeal;
        }

        virtual public Card Deal()
        {
            return Deal(0);
        }

        public void Shuffle()
        {
            // shuffle the cards to a random order
            List<Card> newCards = new List<Card>();
            while (cards.Count > 0)
            {
                int cardToMove = random.Next(cards.Count);
                newCards.Add(cards[cardToMove]);
                cards.RemoveAt(cardToMove);
            }
            cards = newCards;
        }
        
        public IEnumerable<string> GetCardNames()
        {
            // returns enumerable list of strings that contains each card's name.
            string[] cardNames = new string[cards.Count];
            for (int i=0; i < cards.Count; i++)
            {
                cardNames[i] = cards[i].Name;
            }
            return cardNames;
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_byValue());
        }

        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        public bool ContainsValue(Values value)
        {
            foreach (Card card in cards)
                if (card.CardValue == value)
                    return true;
            return false;
        }

        public Deck PullOutValues(Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count - 1; i >= 0; i--)
                if (cards[i].CardValue == value)
                    deckToReturn.Add(Deal(i));
            return deckToReturn;
        }

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
