using CardDeck;
using System;
using System.Collections.Generic;

namespace CardPlayer
{
    public class CardPlayer
    {
        private string name;
        private bool inGame;
        private Random random;
        private Deck cardDeck;

        public string Name { get; set; }

        public CardPlayer(string name, bool inGame = false)
        {
            this.Name = name;
            this.inGame = inGame;
            random = new Random((int)System.DateTime.Now.Ticks);
            cardDeck = new Deck(random);
        }

        public bool JoinGame()
        {
            if (inGame)
                return false;
            else
            {
                inGame = true;
                return true;
            }
        }

        public bool IsInGame()
        {
            return inGame;
        }

        public virtual void Shuffle(int count = 1)
        {
            if (count == 0)
                count = 1;
            while (count-- > 0)
                cardDeck.Shuffle();
        }

        public virtual Card Deal()
        {
            return cardDeck.Deal();
        }

        public virtual List<Card> Deal(int numCards = 1)
        {
            List<Card> deck = new List<Card> { };

            if (numCards > deck.Count)
                numCards = deck.Count;
            for (int i = 0; i < numCards; i++)
                deck.Add(Deal());
            return deck;
        }

        public virtual bool Collect(Card card)
        {
            return cardDeck.Add(card);
        }

        public virtual bool Collect(List<Card> cards)
        {
            bool result = true;
            foreach (Card card in cards)
            {
                result = cardDeck.Add(card);

                if (!result)
                    break;
            }
            return result;
        }
    }
}
