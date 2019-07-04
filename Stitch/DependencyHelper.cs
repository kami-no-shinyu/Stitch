using System;
using System.Diagnostics;
using System.IO;

namespace Stitch
{
    internal class DependencyHelper
    {
        //Checks if [pathsToCheck] are in the Environment path. If not ask [Patho] to help user set them
        public static void CheckDependencies(string[] pathsToCheck)
        {
            var oneIsNotSet = false;
            var combinedPathsForPatho = "";

            foreach(var path in pathsToCheck)
            {
                if (ExistsOnPath(path.Split('*')[0])) continue;
                oneIsNotSet = true;
                combinedPathsForPatho += " " + path;
            }

            if (!oneIsNotSet) return;
            var p = new Process
            {
                StartInfo = new ProcessStartInfo
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
        
        //Deprecated!: Checks if [pathsToCheck] are in the Environment path. Returns True or False
        public static bool DependenciesSet(string[] pathsToCheck)
        {
            var result = true;
            foreach (var path in pathsToCheck)
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
