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
        public string path_of_file;

        public List<string> list_of_paths = null;

        private PathList failed_tasks = null;
        private PathList succeed_tasks = null;
        
        public List<string> GetPaths()
        {
            return this.list_of_paths;
        }

        // Creates a tasklist from a file - the fail and succeed tasklists created
        public PathList(string path_of_file)
        {
            this.path_of_file = path_of_file;
            if (File.Exists(path_of_file))
            {
                list_of_paths = new List<string>();
                foreach (string line in File.ReadLines(path_of_file))
                {
                    list_of_paths.Add(line);
                }
            }
        }

        // Creates a tasklist to a file
        public PathList(List<string> list_of_paths)
        {
            this.list_of_paths = list_of_paths;

            string name_of_file = DateTime.Now.ToString("yyyy-MM-ddTHH-mm-ss");
            string destination_of_file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
            path_of_file = Path.Combine(destination_of_file, name_of_file);

            using(TextWriter tw = new StreamWriter(path_of_file))
            {
                foreach(string path in list_of_paths)
                {
                    tw.WriteLine(path.Replace("\\",@"/"));
                }
            }
        }

        public PathList GetFailTaskList()
        {
            if(failed_tasks == null)
            {
                failed_tasks = new PathList(path_of_file + "-fail");
            }
            return failed_tasks;
        }

        public PathList GetSuccessTaskList()
        {
            if(succeed_tasks == null)
            {
                succeed_tasks = new PathList(path_of_file + "-succeed");
            }
            return succeed_tasks;
        }

        // Deletes the tasklist file if it has been created
        public void Dispose()
        {
            if (File.Exists(path_of_file))
            {
                try
                {
                    File.Delete(path_of_file);
                    File.Delete(failed_tasks.path_of_file);
                    File.Delete(succeed_tasks.path_of_file);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        
    }



}
