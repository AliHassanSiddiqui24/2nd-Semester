using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Paddle_Strike
{
    internal class GameManager
    {
        private Player player;
        private List<Enemy> enemies = new List<Enemy>();

        public void InitializeGame()
        {
            // Initialize player
            player = new Player(40, 20, "■");

            // Create enemies
            enemies.Add(new Enemy(10, 5, "♦"));
            enemies.Add(new Enemy(30, 8, "♣"));
            enemies.Add(new Enemy(50, 12, "♠"));
        }

        public void RunGame()
        {
            while (true)
            {
                // Handle input
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.LeftArrow) player.X--;
                    if (key == ConsoleKey.RightArrow) player.X++;
                }

                // Update game state
                foreach (var enemy in enemies)
                {
                    enemy.Erase();
                    enemy.Move();
                    enemy.Draw();
                }

                // Draw player
                player.Erase();
                player.Draw();

                // Simple collision detection
                foreach (var enemy in enemies)
                {
                    if (Math.Abs(player.X - enemy.X) < 2 &&
                       Math.Abs(player.Y - enemy.Y) < 2)
                    {
                        GameOver();
                        return;
                    }
                }

                Thread.Sleep(50);
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game Over!");
            Console.ReadKey();
        }
    }
}
