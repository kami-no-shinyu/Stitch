using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch2
{
    public class RMD
    {
        public string author;
        public string filename;
        public string file;
        public string directory;
        public string result_prefix;
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
                    break;
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
    }
}
