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
            int boardSize = 3;

            Console.WriteLine("XO GAME");
            Console.WriteLine("===========");
            Console.Write("Please enter board size:");
            boardSize = int.Parse(Console.ReadLine());
            Console.Clear();

            XOBoard XOGame = new XOBoard(boardSize);
            XOGame.Display();

            Console.Write("");
            Console.ReadKey();
        }
    }
}
