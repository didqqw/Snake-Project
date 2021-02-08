using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake_Project
{
    public class Params
    {
        private string resourcesFolder;

        public Params()
        {
            var ind = Directory.GetCurrentDirectory().ToString().IndexOf("bin", StringComparison.Ordinal);

            string binFolder = Directory.GetCurrentDirectory().ToString().Substring(0, ind).ToString();

            resourcesFolder = binFolder + "recources\\";
        }

        public string GetResourceFolder()
        {
            return resourcesFolder;
        }
    }
}