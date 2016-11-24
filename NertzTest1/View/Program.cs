using NertzTest1.Model.Players;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NertzTest1
{
    class Program
    {
        static Random random = new Random((int)DateTime.Now.Ticks);
        static Game bud;
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            bud = new Game();

            ComputerPlayer ed = new ComputerPlayer("ed", random, bud, 2, 4);
            ComputerPlayer bob = new ComputerPlayer("bob", random, bud, 3, 6);
            ComputerPlayer joe = new ComputerPlayer("joe", random, bud, 1, 5);

            bud.AddPlayer(ed);
            bud.AddPlayer(bob);
            bud.AddPlayer(joe);

            bud.StartGame();

            ed.FlipThreeCards();
            bob.FlipThreeCards();
            joe.FlipThreeCards();

            string description = bud.DescribePlayerHands();
            Console.WriteLine(description.ToCharArray(), 0, description.Length);
            Console.WriteLine(bud.DescribePlayerHands());
                Console.ReadKey();

        }
    }
}
