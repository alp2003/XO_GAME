using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Game XO_Game = new Game();
            XO_Game.StartGame();

            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
