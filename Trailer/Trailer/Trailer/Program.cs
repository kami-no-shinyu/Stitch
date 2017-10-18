using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trailer
{
    class Program
    {
        static void Main(string[] args)
        {
            AddToPath("pandoc.exe");
            Console.ReadLine();
        }

        public static void AddToPath(string path)
        {
            if (!IsVariableSetInPath(path))
            {
                MessageBox.Show("[ " + path + " ] Not Found", "Path Not Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void RemovePath(string path)
        {
            var old_path = Environment.GetEnvironmentVariable("PATH");
            var new_path = old_path.Replace(GetFullPath(path), "");

        }

        
        public static string GetFullPath(string pathToCheck)
        {
            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, pathToCheck);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        public static bool IsVariableSetInPath(string pathToCheck)
        {
            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, pathToCheck);
                if (File.Exists(fullPath))
                    return true;
            }
            return false;
        }

        public static void SetEnvironmentVariable(string pathToAdd,bool shouldOverride)
        {
            string path_variable = "path";
            string old_path = Environment.GetEnvironmentVariable(path_variable, EnvironmentVariableTarget.Machine);
            string new_path = null;

            if (shouldOverride) new_path = pathToAdd;
            else new_path = old_path + ";" + pathToAdd;

            EnvironmentVariableTarget target = EnvironmentVariableTarget.Machine;
            Environment.SetEnvironmentVariable(path_variable, new_path, target);
        }



    }
}
