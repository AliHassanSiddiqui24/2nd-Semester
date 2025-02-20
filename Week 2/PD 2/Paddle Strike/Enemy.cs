using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paddle_Strike
{
    public class Enemy
    {
        public int X;
        public int Y;
        public string Symbol;
        private int direction = 1;

        public Enemy(int x, int y, string symbol)
        {
            X = x;
            Y = y;
            Symbol = symbol;
        }

        public void Move()
        {
            X += direction;
            if (X >= Console.WindowWidth - 2 || X <= 1)
            {
                direction *= -1;
            }
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
