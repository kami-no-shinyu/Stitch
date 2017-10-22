using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch
{
    public static class FileHandler
    {
        public static List<string> GetFiles(String dir,List<string> extensions)
        {
            List<String> results = new List<string>();
            if (File.GetAttributes(dir).HasFlag(FileAttributes.Directory))
            {
                List<string> rmd_files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                    .Where(file => extensions
                    .Contains(Path.GetExtension(file)))
                    .ToList();
                results.AddRange(rmd_files);
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
