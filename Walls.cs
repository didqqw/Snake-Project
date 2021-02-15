using System.Collections.Generic;


namespace Snake_Project
{
    public class Walls
    {
        private List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            int widthScoreWall = 30;
            
            // Draw box
            Hor_Line upLine = new Hor_Line(0, mapWidth + widthScoreWall, 0, '+');
            Hor_Line downLine = new Hor_Line(0, mapWidth + widthScoreWall, mapHeight - 1, '+');
            Ver_Line leftLine = new Ver_Line(0, mapHeight - 1, 0, '+');
            Ver_Line rightLine = new Ver_Line(0, mapHeight - 1, mapWidth - 2, '+');
            Ver_Line scoreRightWall = new Ver_Line(0, mapHeight - 1, mapWidth + widthScoreWall, '+');
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(scoreRightWall);
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