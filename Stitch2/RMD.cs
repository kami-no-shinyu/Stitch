using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch
{
    public class RMD
    {
        public string author;
        public string filename;
        public string file;
        public string directory;
        public string result_prefix;
        public Dictionary<string,string> sources = new Dictionary<string, string>();

        public Boolean passed = false;

        public RMD(string file)
        {
            this.file = file;
            this.filename = Path.GetFileNameWithoutExtension(file);

            foreach (String line in File.ReadLines(file))
            {
                if (line.Contains("author"))
                {
                    string[] pieces = line.Split(':');
                    author = pieces[1].Replace("\"","").Replace("\'","");
                }

                if (line.Contains("load") || line.Contains("read.delim"))
                {
                    int start = line.IndexOf('"'); // Find first quote
                    int end = line.IndexOf('"', start + 1); // Find the next quote
                    string source_line = line.Substring(start, end - start + 1).Replace('"', ' ').Trim();

                    string rmd_name = "";
                    if (source_line.Contains("/")) //If person referenced a path instead of just the filename
                    {
                        rmd_name = source_line.Split('/').Last().Replace('"', ' ').Trim();
                    }
                    else if (source_line.Contains(@"\"))
                    {
                        string source_new = source_line.Replace(@"\", @"/");
                        rmd_name = source_new.Split('/').Last().Replace('"', ' ').Trim();
                    }
                    else
                    {
                        rmd_name = source_line.Replace('"', ' ').Trim();
                    }

                    sources[rmd_name.ToLower()] = source_line;
                }
            }

            directory = Path.GetDirectoryName(file);
            result_prefix = directory + @"\" + filename;
        }

        public RMD SetPass()
        {
            passed = true;
            return this;
        }

        public void SetSource(string name,string new_source)
        {
            if (sources.Keys.Contains(name))
            {
                string old_source = sources[name];
                string old_string = File.ReadAllText(file);
                string new_string = old_string.Replace(old_source, new_source);
                File.WriteAllText(file, new_string);
            }
        }

        public Dictionary<string,string> GetSources()
        {
            return sources;
        }

    }
}
