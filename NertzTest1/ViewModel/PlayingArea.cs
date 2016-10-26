using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CardDeck;
using NertzTest1.Model.Players;

namespace NertzTest1
{
    class PlayingArea
    {
        private List<CardStack> stacks;
        private List<CardStack> completedStacks;

        public PlayingArea()
        {
            stacks = new List<CardStack>();
            completedStacks = new List<CardStack>();
        }

        /// <summary>
        /// Starts a new stack of cards, but only if the card value 
        /// is an Ace.  Otherwise does nothing.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="player"></param>
        public bool StartStack(Card card, HumanPlayer player)
        {
            bool stackStarted = false;
            if (card.CardValue == Values.Ace)
            {
                stacks.Add(new CardStack(card, player));
                stackStarted = true;
            }
            return stackStarted;
        }

        /// <summary>
        /// Finds a stack that the card could play on.  Returns the stack, 
        /// if no stack found, then returns null.
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public CardStack FindStack(Card card)
        {
            CardStack stackFound = null;
            foreach(CardStack stack in stacks)
            {
                if (stack.GetSuit() == card.CardSuit)
                {
                    if ((int)stack.GetTopValue() == (int)card.CardValue - 1)
                        stackFound = stack;
                }
            }
            return stackFound;
        }

        /// <summary>
        /// Adds a card to the specified stack.  The stack must be one of the
        /// stacks in play, the card must match the specified stack suit and 
        /// the card value must be numerically greater and sequential to the
        /// top card of the stack. 
        /// </summary>
        /// <param name="stack"></param>
        /// <param name="card"></param>
        /// <param name="owner"></param>
        public void AddCardToStack(CardStack stack, Card card, HumanPlayer owner)
        {
            foreach(CardStack cardStack in stacks)
            {
                if (cardStack == stack)
                {
                    if (card.CardSuit == cardStack.GetSuit() &&
                        (int)card.CardValue == (int)cardStack.GetTopValue() + 1)
                    {
                        cardStack.AddCard(card, owner);
                        
                        // move from open stacks to completed stacks
                        if (card.CardValue == CardDeck.Values.King)
                        {
                            stacks.Remove(cardStack);
                            completedStacks.Add(cardStack);
                        }
                    }
                }
            }
        }

        public string DescribeStacks()
        {
            string description = "";
            for (int i = 0; i < stacks.Count; i++)
            {
                description += stacks[i].GetTopCard().ToString(); 
            }
            if (description.Length == 0)
                description = "No playing piles";
            return description;
        }

    }
}
