using System;
using System.Collections.Generic;
using System.IO;
using System;
using System.Diagnostics;

namespace Snake_Project
{
    public class Score
    {
        Params settings = new Params();
        private static string pathToRecordFile;
        private static string pathToResultsFile;
        private int currentPoints = 0;

        public Score(string _pathToResources)
        {
            pathToRecordFile = _pathToResources + "record.txt";
            pathToResultsFile = _pathToResources + "results.txt";

            Console.ForegroundColor = ConsoleColor.DarkGray;
            WriteText("Счет", 92, 1);

            ShowCurrentPoints();

            Console.ForegroundColor = ConsoleColor.Black;
            WriteText("Рекорд:", 90, 5);

            WriteText(GetBestResult(), 98, 5);

            WriteText("-----------------------------", 80, 6);

            ShowLastFiveResults();
        }


        public string GetBestResult()
        {

            StreamReader streamReader = new StreamReader(pathToRecordFile);
            string record = streamReader.ReadToEnd();
            streamReader.Close();
            if (record == "")
            {
                record = "0";
            }

            return record;
        }

        public void WriteBestResult()
        {
            if (currentPoints > Convert.ToInt32(GetBestResult()))
            {
   
                StreamWriter streamWriter = new StreamWriter(pathToRecordFile);
                streamWriter.Write(currentPoints);
                streamWriter.Close();

           
                StreamWriter streamWriter1 = new StreamWriter(pathToResultsFile, true);
                streamWriter1.WriteLine(currentPoints);
                streamWriter1.Close();
            }
            else
            {
            
                /*StreamWriter streamWriter = new StreamWriter(pathToResultsFile, true);
                streamWriter.WriteLine(currentPoints);
                streamWriter.Close();*/
            }
        }


        public void UpCurrentPoints()
        {
            currentPoints += 10;
        }

        public void ShowCurrentPoints()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (currentPoints == 0)
            {
                Console.SetCursorPosition(94, 3);
            }
            else if (currentPoints > 0)
            {
                Console.SetCursorPosition(93, 3);
            }

            Console.WriteLine(currentPoints.ToString());
        }

        public void ShowLastFiveResults()
        {
            List<int> res = new List<int>();
            string line;


            StreamReader streamReader = new StreamReader(pathToResultsFile);
            while ((line = streamReader.ReadLine()) != null)
            {

                res.Add(Convert.ToInt32(line));
            }

            streamReader.Close();



            for (int i = res.Count - 1, j = 1; i > res.Count - 6; i--, j++)
            {
                Console.SetCursorPosition(80, 7 + j);
                Console.WriteLine(j + ") " + res[i]);
            }
        }

        public void WriteGameOver()
        {
            int xOffset = 23;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("================================", xOffset, yOffset++);
            WriteText("GAME OVER", xOffset + 3, yOffset++);
            WriteText("================================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}