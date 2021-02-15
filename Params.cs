using System;
using System.IO;

namespace Snake_Project
{
    public class Params
    {
        private string resourcesFolder;

        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString().IndexOf("bin", StringComparison.Ordinal); 

            string binFolder = Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString(); resourcesFolder = binFolder + "resources\\";
        }

        public string GetResourceFolder()
        {
            return resourcesFolder;
        }

    }
}