using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
    public class Game
    {
        public void StartGame()
        {
            GameTitle();
            Console.Write("Please enter board size: ");
            int boardSize = 0;
            
            try
            {
                boardSize = int.Parse(Console.ReadLine());

                if (boardSize >= 3)
                {
                    Console.WriteLine("Board Size Cant be less than 3");
                    return ;
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            XOBoard XOGame = new XOBoard(boardSize);
            bool isUserAskToExit = false;
            bool isGameOver = false;
            int countMove = 0;
            Player player = Player.X;
            string move = string.Empty;

            while (!isUserAskToExit && !isGameOver)
            {
                Console.Clear();
                GameTitle();
                XOGame.Display();
                Console.WriteLine("Player {0} Move (move ex: E5, q for exit): ", player);
                move = Console.ReadLine();

                if (move != string.Empty && move.Length <= 2)
                {
                    if (move == "Q" || move == "q")
                    {
                        isUserAskToExit = true;
                    }
                    else
                    {
                        if (move.Length == 2 && char.IsDigit(move[1]) && char.IsLetter(move[0]))
                        {
                            XOGame.Put(move, player);
                            Player winStatus = XOGame.Status();
                            checkStatus(winStatus, out isGameOver);
                            countMove++;
                        }
                        else
                        {
                            continue;
                        }
                    }

                    player = countMove % 2 == 0 ? Player.X : Player.O;
                }

            }

            Console.WriteLine("Goodbye!!!");

        }

        private void checkStatus(Player winStatus, out bool isGameOver)
        {
            isGameOver = false;

            switch (winStatus)
            {
                case Player.X:
                    {
                        Console.WriteLine("X Player Wins!!!");
                        isGameOver = true;
                        break;
                    }
                case Player.O:
                    {
                        Console.WriteLine("O Player Wins!!!");
                        isGameOver = true;
                        break;
                    }

                case Player.BLANK:
                    {
                        Console.WriteLine("None winner yet");
                        isGameOver = false;
                        break;
                    }

                case Player.DRAW:
                    {
                        Console.WriteLine("Draw");
                        isGameOver = true;
                        break;
                    }
                default: break;
            }
        }

        public void GameTitle()
        {
            Console.WriteLine("XO GAME");
            Console.WriteLine("===========");
        }
    }
}
