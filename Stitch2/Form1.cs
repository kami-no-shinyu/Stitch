using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stitch2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lstDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        List<string> rmd_files = new List<string>();

        private void lstDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file_str in files)
            {
                string extension = Path.GetExtension(file_str);
                if(extension == ".rmd")
                {
                    rmd_files.Add(file_str);
                    lstDrop.Items.Add(Path.GetFileNameWithoutExtension(file_str));
                }

            }
        }

        private void btnStitch_Click(object sender, EventArgs e)
        {
            //Save the stuff to text file 
            String desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            String fileName = desktop_path + "\\" + new DateTime().ToString("yyyyMMddHHmmssffff") + ".txt";

            TextWriter tw = new StreamWriter(fileName);
            foreach(String s in rmd_files)
            {
                tw.WriteLine(s);
            }
            tw.Close();

            //Run the program on the text file 
            Process p = new Process();
            //p.StartInfo.UseShellExecute = false;
            //p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = "Powershell.exe";
            p.StartInfo.Arguments = "-executionpolicy remotesigned -File  Stitch.ps1 -f " + fileName;
            p.Start();

            p.WaitForExit();

            //Get the response from the resultant text file
            List<String> passed = new List<string>();
            List<String> failed = new List<string>();

            IEnumerable<string> lines = File.ReadLines(fileName + "-fail.txt");
            foreach(string line in lines)
            {
                failed.Add(line);
            }

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            if (File.Exists(fileName + "-fail.txt")){
                File.Delete(fileName + "-fail.txt");
            }

            IEnumerable<string> lines2 = File.ReadLines(fileName + "-succeed.txt");
            foreach (string line in lines2)
            {
                passed.Add(line);
            }

            if (File.Exists(fileName + "-succeed.txt"))
            {
                File.Delete(fileName + "-succeed.txt");
            }
            //Send Data to the other form
            Report b = new Report();
            b.LoadDetails(passed, failed);
            b.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
        }
    }
}
