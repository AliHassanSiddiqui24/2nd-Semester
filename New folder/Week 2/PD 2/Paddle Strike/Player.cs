using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paddle_Strike
{
    public class Player
    {
        public int X;
        public int Y;
        public string Symbol;

        public Player(int x, int y, string symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Symbol);
        }

        public void Erase()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }
    }
}
