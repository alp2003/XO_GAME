using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XOGame
{
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
        }

        public void Put(string location)
        {

        }

        public string Status()
        {
            return string.Empty;
        }

        public void Display()
        {


            Console.WriteLine("XO Game");
            Console.WriteLine("==============");
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
