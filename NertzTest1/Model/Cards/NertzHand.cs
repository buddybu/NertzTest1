using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardDeck;

namespace NertzTest1
{
    class NertzHand
    {
        Deck deckOfCards;
        Deck flippedDeckOfCards;

        private List<Card> nertzPile;
        public Card NertzPile
        {
            get
            {
                // returns top card
                return nertzPile[nertzPile.Count - 1];
            }
        }

        public int NertzPileCount
        {
            get
            {
                return nertzPile.Count;
            }
        }

        public Card CardSlot1 { get; private set; }
        public Card CardSlot2 { get; private set; }
        public Card CardSlot3 { get; private set; }
        public Card CardSlot4 { get; private set; }

        public NertzHand(Deck cards)
        {
            deckOfCards = cards;
            deckOfCards.Shuffle();
            flippedDeckOfCards = new Deck(new Card[] { });
            nertzPile = new List<Card> { };
        }

        public void Shuffle()
        {
            deckOfCards.Shuffle();
        }

        public void Deal()
        { 
            for (int i = 0; i < 13; i++)
                nertzPile.Add(deckOfCards.Deal(0));

            CardSlot1 = deckOfCards.Deal(0);
            CardSlot2 = deckOfCards.Deal(0);
            CardSlot3 = deckOfCards.Deal(0);
            CardSlot4 = deckOfCards.Deal(0);
        }

        public void RotateOneCard()
        {
            if (flippedDeckOfCards.Count == 0 && deckOfCards.Count > 1) 
                deckOfCards.Add(deckOfCards.Deal(0));
        }

        public Card FlippedDeckTopCard()
        {
            if (flippedDeckOfCards.Count > 0)
                return flippedDeckOfCards.Peek(flippedDeckOfCards.Count-1);
            else
                return null;
        }

        public void NertzPileCardToSlot(CardSlot slotNum)
        {
            switch (slotNum)
            {
                // trying to move from nertzpile to nertzpile?  
                // do nothing
                case CardSlot.NertzPile:
                    break;

                case CardSlot.SlotOne:
                    if (CardSlot1 == null)
                    {
                        CardSlot1 = nertzPile[0];
                        nertzPile.Remove(nertzPile[0]);
                    }
                    break;
                case CardSlot.SlotTwo:
                    if (CardSlot2 == null)
                    {
                        CardSlot2 = nertzPile[0];
                        nertzPile.Remove(nertzPile[0]);
                    }
                    break;
                case CardSlot.SlotThree:
                    if (CardSlot3 == null)
                    {
                        CardSlot3 = nertzPile[0];
                        nertzPile.Remove(nertzPile[0]);
                    }
                    break;
                case CardSlot.SlotFour:
                    if (CardSlot4 == null)
                    {
                        CardSlot4 = nertzPile[0];
                        nertzPile.Remove(nertzPile[0]);
                    }
                    break;
            }
        }

        /// <summary>
        /// removes the top card from the nertz pile
        /// returns true of the nertz pile is empty
        /// returns false otherwize
        /// </summary>
        /// <returns></returns>
        public bool RemoveNertzPileCard()
        {
            bool nertzPileEmpty = false;
            if (nertzPile.Count != 0)
                nertzPile.RemoveAt(0);
            if (nertzPile.Count == 0)
                nertzPileEmpty = true;
            return nertzPileEmpty;
        }

        public bool RemoveSlotCard(CardSlot slotNum)
        {
            bool nertzPileEmpty = false;

            switch(slotNum)
            {
                case CardSlot.NertzPile:
                    nertzPileEmpty = RemoveNertzPileCard();
                    break;

                case CardSlot.SlotOne:
                    CardSlot1 = null;
                    if (nertzPile.Count == 1)
                        nertzPileEmpty = true;
                    break;

                case CardSlot.SlotTwo:
                    CardSlot2 = null;
                    if (nertzPile.Count == 1)
                        nertzPileEmpty = true;
                    break;

                case CardSlot.SlotThree:
                    CardSlot3 = null;
                    if (nertzPile.Count == 1)
                        nertzPileEmpty = true;
                    break;

                case CardSlot.SlotFour:
                    CardSlot4 = null;
                    if (nertzPile.Count == 1)
                        nertzPileEmpty = true;
                    break;
            }

            return nertzPileEmpty;
        }


        public void DrawThreeCards()
        {
            Card card;
            int drawCount;

            if (deckOfCards.Count == 0)
            {
                deckOfCards = flippedDeckOfCards;
                flippedDeckOfCards = new Deck(new Card[] { });
            }

            // 3 or more cards left on deck, flip 3 cards
            if (deckOfCards.Count >= 3)
            {
                drawCount = 3;
            }
            else
            {
                drawCount = deckOfCards.Count;
            }

            while (drawCount-- > 0)
            {
                flippedDeckOfCards.Add(deckOfCards.Deal());
            }

            //if (deckOfCards.Count >= 3)
            //{
            //    card = deckOfCards.Deal();
            //    flippedDeckOfCards.Add(card);
            //    card = deckOfCards.Deal();
            //    flippedDeckOfCards.Add(card);
            //    card = deckOfCards.Deal();
            //    flippedDeckOfCards.Add(card);
            //}

            //// only two cards left on deck, flip them one at a time
            //else if (deckOfCards.Count == 2)
            //{
            //    card = deckOfCards.Deal();
            //    flippedDeckOfCards.Add(card);
            //    card = deckOfCards.Deal();
            //    flippedDeckOfCards.Add(card);
            //}

            //// only one card left on deck, flip it
            //else
            //{
            //    card = deckOfCards.Deal();
            //    flippedDeckOfCards.Add(card);
            //}
        }
    }
}
