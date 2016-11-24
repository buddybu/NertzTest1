using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StandardCardDeck;

namespace NertzTest1.Model.Cards
{
    class NertzHand : Deck
    {
        //Deck deckOfCards;
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

        public NertzHand(Random random) : base(random)
        {
            //deckOfCards = cards;
            //deckOfCards.Shuffle();
            flippedDeckOfCards = new Deck(new Card[] { });
            nertzPile = new List<Card> { };
        }

        //public void Shuffle()
        //{
        //    base.Shuffle();
        //}

        public void NertzDeal()
        { 
            for (int i = 0; i < 13; i++)
                nertzPile.Add(Deal(0));

            CardSlot1 = Deal(0);
            CardSlot2 = Deal(0);
            CardSlot3 = Deal(0);
            CardSlot4 = Deal(0);
        }

        public void RotateOneCard()
        {
            if (flippedDeckOfCards.Count == 0 && Count > 1) 
                Add(Deal(0));
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
                        RemoveNertzPileCard();
                    }
                    break;
                case CardSlot.SlotTwo:
                    if (CardSlot2 == null)
                    {
                        CardSlot2 = nertzPile[0];
                        RemoveNertzPileCard();
                    }
                    break;
                case CardSlot.SlotThree:
                    if (CardSlot3 == null)
                    {
                        CardSlot3 = nertzPile[0];
                        RemoveNertzPileCard();
                    }
                    break;
                case CardSlot.SlotFour:
                    if (CardSlot4 == null)
                    {
                        CardSlot4 = nertzPile[0];
                        RemoveNertzPileCard();
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

            // if removing the nertz pile card, remove it directly
            if (slotNum == CardSlot.NertzPile)
            {
                nertzPileEmpty = RemoveNertzPileCard();
            }

            // must be one of the slots
            // clear the slot and check if the nertz pile
            // is empty
            else
            {
                if (nertzPile.Count > 1)
                {
                    switch (slotNum)
                    {
                        case CardSlot.SlotOne:
                            CardSlot1 = null;
                            break;

                        case CardSlot.SlotTwo:
                            CardSlot2 = null;
                            break;

                        case CardSlot.SlotThree:
                            CardSlot3 = null;
                            break;

                        case CardSlot.SlotFour:
                            CardSlot4 = null;
                            break;
                    }
                    NertzPileCardToSlot(slotNum);
                }

                if (nertzPile.Count == 0)
                    nertzPileEmpty = true;

            }

            return nertzPileEmpty;
        }


        public void DrawThreeCards()
        {
            int drawCount;

            if (Count == 0)
            {

                while (flippedDeckOfCards.Count > 0)
                {
                    Add(flippedDeckOfCards.Deal());
                }
            }   

            // 3 or more cards left on deck, flip 3 cards
            if (Count >= 3)
            {
                drawCount = 3;
            }
            else
            {
                drawCount = Count;
            }

            while (drawCount-- > 0)
            {
                flippedDeckOfCards.Add(Deal());
            }

        }
    }
}
