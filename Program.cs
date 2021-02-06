using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Project
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.SetBufferSize(120, 32);
            
            // Отрисовка краев 
            Hor_Line upLine = new Hor_Line(0, 78, 0, '+');
            Hor_Line downLine = new Hor_Line(0, 78, 24, '+');
            Ver_Line rightLine = new Ver_Line(0, 24, 0, '+');
            Ver_Line leftLine = new Ver_Line(0, 24, 78, '+');
            upLine.Draw();
            downLine.Draw();
            leftLine.Draw();
            rightLine.Draw();
            
            
            // Точки
            Point p = new Point(4, 5, '*');
            p.Draw();
            
            /*Point p1 = new Point(1, 3, '*');
            p1.Draw();

            Point p2 = new Point(4, 5, '#');
            p2.Draw();

            Hor_Line line = new Hor_Line(5, 10, 8, '+');
            line.Draw();

            Ver_Line line = new Ver_Line();
            line.Draw();*/

            Console.ReadLine();
        }
    }
}