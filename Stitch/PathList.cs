using System;
using System.Collections.Generic;
using System.IO;

namespace Stitch
{
    /// <summary>
    /// A TaskList represents a txtfile that contains a list of paths. One per line 
    /// </summary>

    public class PathList
    {
        public string PathOfFile;

        public List<string> ListOfPaths = null;

        private PathList _failedTasks = null;
        private PathList _succeedTasks = null;
        
        public List<string> GetPaths()
        {
            return ListOfPaths;
        }

        // Creates a tasklist from a file - the fail and succeed tasklists created
        public PathList(string pathOfFile)
        {
            PathOfFile = pathOfFile;
            if (!File.Exists(pathOfFile)) return;
            ListOfPaths = new List<string>();
            foreach (var line in File.ReadLines(pathOfFile))
            {
                ListOfPaths.Add(line);
            }
        }

        // Creates a tasklist to a file
        public PathList(List<string> listOfPaths)
        {
            ListOfPaths = listOfPaths;

            var nameOfFile = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            var destinationOfFile = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
            PathOfFile = Path.Combine(destinationOfFile, nameOfFile);

            using(TextWriter tw = new StreamWriter(PathOfFile))
            {
                foreach(var path in listOfPaths)
                {
                    tw.WriteLine(path.Replace("\\",@"/"));
                }
            }
        }

        public PathList GetFailTaskList()
        {
            if(_failedTasks == null)
            {
                _failedTasks = new PathList(PathOfFile + "-fail");
            }
            return _failedTasks;
        }

        public PathList GetSuccessTaskList()
        {
            if(_succeedTasks == null)
            {
                _succeedTasks = new PathList(PathOfFile + "-succeed");
            }
            return _succeedTasks;
        }

        // Deletes the tasklist file if it has been created
        public void Dispose()
        {
            if (File.Exists(PathOfFile))
            {
                try
                {
                    File.Delete(PathOfFile);
                    File.Delete(_failedTasks.PathOfFile);
                    File.Delete(_succeedTasks.PathOfFile);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        
    }



}
