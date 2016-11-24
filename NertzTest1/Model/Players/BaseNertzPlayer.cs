using NertzTest1.Model.Cards;
using StandardCardDeck;
using System;

namespace NertzTest1.Model.Players
{
    class BaseNertzPlayer
    {
        private int shuffleCount;
        private string name;
        private bool inGame;
        private NertzHand nertzHand;
        private Random random;
        private Deck cardDeck;
        private Game gameInProgress;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public BaseNertzPlayer(string name, Random random, int shuffleCount, Game gameInProgress)
        {
            this.Name = name;
            this.random = random;
            this.cardDeck = new Deck(random);
            this.gameInProgress = gameInProgress;
            this.nertzHand = new NertzHand(cardDeck);
            this.shuffleCount = shuffleCount;

            gameInProgress.AddProgress(Name + " has joined the game.");
        }

        public virtual void Shuffle()
        {
            int count = shuffleCount;
            if (count == 0)
                count = 1;
            while (count-- > 0)
                nertzHand.Shuffle();
        }


        public virtual void Deal()
        {
            nertzHand.Deal();
        }

        public virtual Card GetNertzTopCard()
        {
            if (nertzHand.NertzPileCount > 0)
                return nertzHand.NertzPile;
            else
                return null;
        }

        public virtual Card FlipThreeCards()
        {
            nertzHand.DrawThreeCards();
            return nertzHand.FlippedDeckTopCard();
        }


        public virtual Card GetSlotCard(CardSlot slotNumber)
        {
            Card card = null;
            switch (slotNumber)
            {
                case CardSlot.NertzPile:
                    card = GetNertzTopCard();
                    break;

                case CardSlot.SlotOne:
                    card = nertzHand.CardSlot1;
                    break;

                case CardSlot.SlotTwo:
                    card = nertzHand.CardSlot2;
                    break;

                case CardSlot.SlotThree:
                    card = nertzHand.CardSlot3;
                    break;

                case CardSlot.SlotFour:
                    card = nertzHand.CardSlot4;
                    break;
            }
            return card;
        }


    }

}
