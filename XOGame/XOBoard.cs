using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
    public enum Player
    {
        X = 'X',
        O = 'O',
        BLANK = ' ',
        DRAW = 'E'
    }

    public class XOBoard
    {
        private int m_BoardLength;
        private char[,] m_XOBoard;

        public int BoardLength
        {
            get { return m_BoardLength; }
            set
            {
                if (value > 0 && value < 100)
                {
                    m_BoardLength = value;
                }
            }
        }

        public char[,] Board
        {
            get { return m_XOBoard; }
        }

        public XOBoard(int i_BoardSize)
        {
            BoardLength = i_BoardSize;
            m_XOBoard = new char[BoardLength, BoardLength];
            initBoard();
        }

        private void initBoard()
        {
            for (int i = 0; i < BoardLength; i++)
            {
                for (int j = 0; j < BoardLength; j++)
                {
                    Board[i, j] = Convert.ToChar(Player.BLANK);
                }
            }
        }

        public void Put(string i_Move, Player i_player)
        {
            int row = i_Move[1] - '0' - 1;
            int col = i_Move[0] - 'A';

            

            if (col < BoardLength && col >= 0 && row >= 0 && row < BoardLength)
            {
                if (Board[row, col] == Convert.ToChar(Player.BLANK))
                {
                    Board[row, col] = Convert.ToChar(i_player);
                    // TODO: Check if player won
                }
                else
                {
                    Console.WriteLine("Invalid Move (Place not empty)");
                }
            }
            else
            {
                Console.WriteLine("Invalid Move(Out side of the board)");
            }

        }

        public Player Status()
        {
            

            // check Row
            for (int x = 0; x < BoardLength; x++)
            {
                Player value = (Player)Board[x,0];

                if (value == Player.BLANK)
                {
                    continue;
                }

                for (int y = 1; y < BoardLength; y++)
                {
                    Player current = (Player)Board[x, y];
                    if (current == Player.BLANK || !current.Equals(value))
                    {
                        break;
                    }

                    if (y == BoardLength - 1)
                    {
                        // found Row winner
                        return value;
                    }
                    
                }
            }

            // check Column
            for (int y = 0; y < BoardLength; y++)
            {
                Player value = (Player)Board[0, y];

                if (value == Player.BLANK)
                {
                    continue;
                }

                for (int x = 1; x < BoardLength; x++)
                {
                    Player current = (Player)Board[x, y];
                    if (current == Player.BLANK || !current.Equals(value))
                    {
                        break;
                    }

                    if (x == BoardLength - 1)
                    {
                        // found Column winner
                        return value;
                    }

                }
            }

            // Check Main Diagonal
            Player diagValue = (Player)Board[0, 0];

            if (diagValue != Player.BLANK)
            {
                for (int i = 1; i < BoardLength; i++)
                {
                    if ((Player)Board[i, i] != diagValue)
                    {
                        break;
                    }

                    if (i == BoardLength - 1)
                    {
                        return diagValue;
                    }
                }
            }

            // Check Second Diagonal
            Player diagValue2 = (Player)Board[0, BoardLength - 1];

            if (diagValue2 != Player.BLANK)
            {
                for (int i = 1; i < BoardLength; i++)
                {
                    if ((Player)Board[i, BoardLength - i - 1] != diagValue2)
                    {
                        break;
                    }

                    if (i == BoardLength - 1)
                    {
                        return diagValue2;
                    }
                }
            }

            for (int x = 0; x < BoardLength; x++)
            {
                for (int y = 0; y < BoardLength; y++)
                {
                    if ((Player)Board[x,y] == Player.BLANK)
                    {
                        return Player.BLANK;
                    }
                }
            }

            return Player.DRAW;
        }

        public void Display()
        {
            char currentCharToPrint = 'A';
            StringBuilder borderLine = new StringBuilder("  =");
            StringBuilder currentLine = new StringBuilder(string.Empty);

            currentLine.Append(" ");
            for (int i = 0; i < BoardLength; i++)
            {
                currentLine.Append("   ").Append(currentCharToPrint++);
                borderLine.Append("====");
            }

            Console.WriteLine(currentLine);
            Console.WriteLine(borderLine);

            for (int i = 1; i <= BoardLength; i++)
            {
                currentLine = new StringBuilder(string.Empty);
                currentLine.Append(string.Format("{0}", i)).Append(" |");
                for (int j = 1; j <= BoardLength; j++)
                {
                    currentLine.Append(' ').Append(Board[i - 1, j - 1]).Append(" |");
                }

                Console.WriteLine(currentLine);
                Console.WriteLine(borderLine);
            }

        }
    }
}
