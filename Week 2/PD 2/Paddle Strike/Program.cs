using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paddle_Strike
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameManager game = new GameManager();
            game.InitializeGame();
            game.RunGame();
        }
    }
}
