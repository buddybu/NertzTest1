﻿using NertzTest1.Model.Players;
using StandardCardDeck;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace NertzTest1
{
    class Game : INotifyPropertyChanged
    {
        private List<BaseNertzPlayer> players;

        private PlayingArea playingArea;
        private Random random;

        // properties
        public bool GameInProgress { get; private set; }
        public bool GameNotStarted { get { return !GameInProgress; } }
        public string PlayerName { get; set; }
        public string GameProgress { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Game()
        {
            random = new Random((int)DateTime.Now.Ticks);
            players = new List<BaseNertzPlayer>();
            ResetGame();
        }

        public bool AddPlayer(string playerName)
        {
            var found = false;
            if (playerName != null && playerName.Length > 0)
            {
                HumanPlayer newPlayer = new HumanPlayer(playerName, random, 1, this);
                if (players.Count > 0)
                {
                    foreach (HumanPlayer player in players)
                    {
                        if (player.Name.CompareTo(playerName) == 0)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                    players.Add(newPlayer);
            }

            return found;
        }

        public bool AddPlayer(HumanPlayer player)
        {
            var found = false;
            if (player != null && player.Name.Length > 0)
            {
                if (players.Count > 0)
                {
                    foreach (HumanPlayer newplayer in players)
                    {
                        if (newplayer.Name.CompareTo(player.Name) == 0)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                    players.Add(player);
            }

            return found;
        }

        public bool AddPlayer(ComputerPlayer player)
        {
            var found = false;
            if (player != null && player.Name.Length > 0)
            {
                if (players.Count > 0)
                {
                    foreach (ComputerPlayer newplayer in players)
                    {
                        if (newplayer.Name.CompareTo(player.Name) == 0)
                        {
                            found = true;
                            break;
                        }
                    }
                }
                if (!found)
                    players.Add(player);
            }

            return found;
        }

        /// <summary>
        /// This is where the game starts—this method's only called at the beginning
        /// of the game. Shuffle the stock, deal five cards to each player, then use a
        /// foreach loop to call each player's PullOutBooks() method.
        /// </summary>
        private void Deal()
        {
            foreach (BaseNertzPlayer player in players)
            {
                player.Deal();
            }
        }

        public void StartGame()
        {
            ClearProgress();
            GameInProgress = true;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
            Shuffle();
            Deal();
        }

        private void Shuffle()
        {
            foreach (BaseNertzPlayer player in players)
            {
                player.Shuffle();
            }
        }

        public void AddProgress(string progress)
        {
            GameProgress = progress + Environment.NewLine + GameProgress;
            OnPropertyChanged("GameProgress");
        }

        public void ClearProgress()
        {
            GameProgress = String.Empty;
            OnPropertyChanged("GameProgress");
        }


        public void ResetGame()
        {
            GameInProgress = false;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");
        }

        public void PlayOneRound(int selectedPlayerCard)
        {
//            bool gameOver = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                Card nertzTopCard = players[i].GetNertzTopCard();

                description += players[i].Name + " has " +
                        players[i].GetSlotCard(CardSlot.NertzPile) + " " +
                        players[i].GetSlotCard(CardSlot.SlotOne) + " " +
                        players[i].GetSlotCard(CardSlot.SlotTwo) + " " +
                        players[i].GetSlotCard(CardSlot.SlotThree) + " " +
                        players[i].GetSlotCard(CardSlot.SlotFour) + " ";

                if (nertzTopCard == null)
                    description += "empty";
                else
                    description += nertzTopCard;
                description += Environment.NewLine;


            }
            return description;
        }

        public string DescribePlayPiles()
        {
            string description = playingArea.DescribeStacks();

            if (description.Length == 0)
                description = "No playing piles";

            return description;
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }


    }
}
