using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Snake_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetBufferSize(120, 31);

            Walls walls = new Walls(120, 31);
            walls.Draw();


            // Отрисовка краев   
            Hor_Line upLine = new Hor_Line(0, 119, 0, '▼');
            Hor_Line downLine = new Hor_Line(0, 119, 30, '▲');
            Ver_Line leftLine = new Ver_Line(0, 29, 0, '►');
            Ver_Line rightLine = new Ver_Line(0, 29, 119, '◄');
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();
            
            
            // Точки
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(120, 30, '*');
            Point food = foodCreator.CreateFood();
            food.Draw();

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }
                Thread.Sleep(100);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
        }
    }
}