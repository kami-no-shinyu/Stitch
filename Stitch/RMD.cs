using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Stitch
{
    public class RMD
    {
        public string Author;
        public readonly string _file;
        public string _resultPrefix;
        private readonly Dictionary<string,string> _sources = new Dictionary<string, string>();
        public bool _passed;

        public RMD(string file)
        {
            
            _file = file;
            var filename = Path.GetFileNameWithoutExtension(file);

            foreach (var line in File.ReadLines(file))
            {
                if (line.Contains("author"))
                {
                    var pieces = line.Split(':');
                    Author = pieces[1].Replace("\"","").Replace("\'","");
                }

                if (line.Contains("load") || line.Contains("read.delim"))
                {
                    var start = line.IndexOf('"'); // Find first quote
                    var end = line.IndexOf('"', start + 1); // Find the next quote
                    var sourceLine = line.Substring(start, end - start + 1).Replace('"', ' ').Trim();

                    string rmdName;
                    if (sourceLine.Contains("/")) //If person referenced a path instead of just the filename
                    {
                        rmdName = sourceLine.Split('/').Last().Replace('"', ' ').Trim();
                    }
                    else if (sourceLine.Contains(@"\"))
                    {
                        var sourceNew = sourceLine.Replace(@"\", @"/");
                        rmdName = sourceNew.Split('/').Last().Replace('"', ' ').Trim();
                    }
                    else
                    {
                        rmdName = sourceLine.Replace('"', ' ').Trim();
                    }

                    _sources[rmdName.ToLower()] = sourceLine;
                }
            }

            var directory = Path.GetDirectoryName(file);
            _resultPrefix = directory + @"\" + filename;
        }

        public RMD SetPass()
        {
            _passed = true;
            return this;
        }

        public void SetSource(string name,string newSource)
        {
            if (!_sources.Keys.Contains(name)) return;
            var oldSource = _sources[name];
            var oldString = File.ReadAllText(_file);
            var newString = oldString.Replace(oldSource, newSource);
            File.WriteAllText(_file, newString);
        }

        public Dictionary<string,string> GetSources()
        {
            return _sources;
        }

    }
}
