using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Project
{
    class Walls
    {
        static List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();
            
            // Отрисовка краев   
            Hor_Line upLine = new Hor_Line(0, mapWidth - 2, 0, '▼');
            Hor_Line downLine = new Hor_Line(0, mapWidth - 2, mapHeight - 1, '▲');
            Ver_Line leftLine = new Ver_Line(0, mapHeight - 1, 0, '►');
            Ver_Line rightLine = new Ver_Line(0, mapHeight - 1, mapWidth -2, '◄');
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                }
            }

            return false;
        }

        public void Draw()
        {
            foreach (var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
}