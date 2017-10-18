using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch2
{
    class DependencyHelper
    {
        //Checks if [pathsToCheck] are in the Environment path. If not ask [Patho] to help user set them
        public static void CheckDependencies(string[] pathsToCheck)
        {
            bool oneIsNotSet = false;
            string combinedPathsForPatho = "";

            foreach(string path in pathsToCheck)
            {
                if (!ExistsOnPath(path.Split('*')[0]))
                {
                    oneIsNotSet = true;
                    combinedPathsForPatho += " " + path;
                }
            }

            if (oneIsNotSet)
            {
                Process p = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        FileName = Data.DependencyWorker,
                        Arguments = combinedPathsForPatho,

                    }
                };
                try
                {
                    p.Start();
                    p.WaitForExit();
                }
                catch (Exception){ }
            }
        }
        
        //Deprecated!: Checks if [pathsToCheck] are in the Environment path. Returns True or False
        public static bool DependenciesSet(string[] pathsToCheck)
        {
            bool result = true;
            foreach (string path in pathsToCheck)
            {
                if (!ExistsOnPath(path.Split('*')[0])) result = false;
            }
            return result;
        }

        //Backend Functions that do the actual checking
        public static bool ExistsOnPath(string fileName) {
            return GetFullPath(fileName) != null;
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }


    }
}
