using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace NertzTest1.Model.Players
{
    class Computer : BasePlayer
    {
        // speed of shuffling, dealing, playing cards...  delay time in seconds
        private int speed;
        private int shuffleCount;

        public int Speed { get; }
        public int ShuffleCount { get; }

        public Computer(string name, Random random, Game gameInProgress, int speed, int shuffleCount) :
            base(name, random, gameInProgress)
        {
            this.speed = speed;
            this.shuffleCount = shuffleCount;
        }

        public void Shuffle()
        {
            int i;
            for (i = 0; i < shuffleCount; i++)
            {
                base.Shuffle(1);
                Thread.Sleep(speed * 1000);
            }
        }

        public override void Deal()
        {

        }

    }
}
