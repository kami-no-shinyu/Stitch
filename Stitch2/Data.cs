using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stitch2
{
    class Data
    {
        public static string DependencyWorker = "Patho.exe";
        public static string[] dependencies = new string[] { "pandoc.exe*folder*[Rstudio->bin->pandoc]", "Rscript.exe*folder*[R->R-a.b.c->bin]" };
        public static List<string> RMD_EXTENSIONS = new List<string>() { ".rmd", ".Rmd", ".RMD" };
        public static string RMD_FILES_DROPPED = "RMD files dropped";
        public static String NO_RMD_FILES = "No RMD files Selected";
        public static String ONLY_ONE_RMD = "I'm sorry, can't work with just single files atm :(";
        public static String DROP_HERE = "Drop Files/Folders Here";
     }
}
