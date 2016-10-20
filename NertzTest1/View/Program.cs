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

            bud.AddPlayer("Ed");
            bud.AddPlayer("Bob");
            bud.AddPlayer("Joe");

            bud.StartGame();

            string description = bud.DescribePlayerHands();
            Console.WriteLine(description.ToCharArray(), 0, description.Length);
            Console.WriteLine(bud.DescribePlayerHands());
                Console.ReadKey();

        }
    }
}
