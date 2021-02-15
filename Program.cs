using System;
using System.Threading;
using System.Diagnostics;

namespace Snake_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 50);
            
            // Отрисовка краев
            Walls walls = new Walls(80, 25);
            walls.Draw();

            
            // Точки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25, '*');
            Point food = foodCreator.CreateFood();
            food.Draw(ConsoleColor.Yellow);
            
            //back music
            Params settings = new Params();
            
            Sounds sounds = new Sounds(settings.GetResourceFolder());
            sounds.Play();
            Sounds sounds3 = new Sounds(settings.GetResourceFolder());
            sounds.Play();
            Sounds sounds1 = new Sounds(settings.GetResourceFolder());
            Sounds sounds2 = new Sounds(settings.GetResourceFolder());
            
            // score
            Score score = new Score(settings.GetResourceFolder());


            //Timer
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    score.WriteGameOver();
                    break;
                }

                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw(ConsoleColor.Yellow);
                    sounds2.PlayEat();
                    score.UpCurrentPoints();
                    score.ShowCurrentPoints();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(75);

                if (Console.KeyAvailable)
                {
                    snake.HandleKey(Console.ReadKey(true).Key); //score);

                }
                TimeSpan timeSpan = TimeSpan.FromSeconds(Convert.ToInt32(stopwatch.Elapsed.TotalSeconds));
                Console.SetCursorPosition(93, 23);
                Console.Write(timeSpan.ToString("mm':'ss"));
                Console.Write('\r');
                
            }

            score.WriteBestResult();
            score.WriteGameOver();
            
            //Console.ReadKey();
        }
    }
}