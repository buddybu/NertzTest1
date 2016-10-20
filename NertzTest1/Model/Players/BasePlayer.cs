using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardDeck;

namespace NertzTest1.Model.Players
{
    class BasePlayer
    {
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

        public BasePlayer(string name, Random random, Game gameInProgress)
        {
            this.Name = name;
            this.random = random;
            this.cardDeck = new Deck(random);
            this.gameInProgress = gameInProgress;
            this.nertzHand = new NertzHand(cardDeck);

            gameInProgress.AddProgress(Name + " has joined the game.");
        }

        public virtual void Shuffle(int count=1)
        {
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
            return nertzHand.NertzPile;
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
