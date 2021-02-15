using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using WMPLib;

namespace Snake_Project
{
    public class Snake : Figure
    {
        Direction direction;


        public Snake(Point tail, int length, Direction _direction)
        {
            direction = _direction;
            pList = new List<Point>();
            for (int i = 0; i < length; i++)
            {
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        internal void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);

            tail.Clear();
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }


        internal bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void HandleKey(ConsoleKey key /*Score score*/)
        {
            if ((key == ConsoleKey.LeftArrow && direction != Direction.RIGHT) ||
                (key == ConsoleKey.A && direction != Direction.RIGHT))
            {
                direction = Direction.LEFT;
            }
            else if ((key == ConsoleKey.RightArrow && direction != Direction.LEFT) ||
                     (key == ConsoleKey.D && direction != Direction.LEFT))
            {
                direction = Direction.RIGHT;
            }
            else if ((key == ConsoleKey.DownArrow && direction != Direction.UP) ||
                     (key == ConsoleKey.S && direction != Direction.UP))
            {
                direction = Direction.DOWN;
            }
            else if ((key == ConsoleKey.UpArrow && direction != Direction.DOWN) ||
                     (key == ConsoleKey.W && direction != Direction.DOWN))
            {
                direction = Direction.UP;
            }
            else if (key == ConsoleKey.Escape)
            {
                //score.WriteBestResult();
                //score.WriteGameOver();
                System.Environment.Exit(0); // exit
            }
        }

        internal bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                food.sym = head.sym;
                pList.Add(food);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}