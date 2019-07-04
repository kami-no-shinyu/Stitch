using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.IO.File;

namespace Stitch
{
    public static class FileHandler
    {
        public static List<string> GetFiles(string dir,List<string> extensions)
        {
            var results = new List<string>();
            if (GetAttributes(dir).HasFlag(FileAttributes.Directory))
            {
                var rmdFiles = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                    .Where(file => extensions
                    .Contains(Path.GetExtension(file)))
                    .ToList();
                results.AddRange(rmdFiles);
            }
            else // if its a file
            {
                if (extensions.Contains(Path.GetExtension(dir).ToLower()))
                {
                    results.Add(dir);
                }
            }

            return results;
        }
    }
}
