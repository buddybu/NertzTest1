using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Player
{
    private NertzHand nertzHand;
    private Random random;
    private Deck cardDeck;
    private Game gameInProgress;

    class NertzPlayer : BasePlayer
    {
        public NertzPlayer(string name, Random random, Game gameInProgress, bool inGame = false ) : base(name, inGame)
        {
        }
    }
}
