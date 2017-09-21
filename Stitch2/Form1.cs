using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Stitch2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LstDrop_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }


        List<string> rmd_files = new List<string>();

        private void LstDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] drag_content = (string[])e.Data.GetData(DataFormats.FileDrop);

            //For each of the dropped content...Get the rmd files
            foreach (string file_str in drag_content)
            {
                foreach(string file in GetFilesList(file_str))
                {
                    String file_name = Path.GetFileNameWithoutExtension(file);
        
                    if (!rmd_files.Contains(file))
                    {
                        rmd_files.Add(file);
                        lstDrop.Items.Add(file_name);
                    }
                }
            }

            pictureBox3.Visible = false;
            RenderLabel();
            lblCount.Text = rmd_files.Count.ToString();
            lblCount.Visible = true;
            lblDrop.Text = "RMD files dropped";
        }
    
        //Returns list of all rmd files in a dir
        private List<String> GetFilesList(String dir)
        {
            List<String> results = new List<string>();

            if (File.GetAttributes(dir).HasFlag(FileAttributes.Directory))
            {
                List<string> rmd_files = Directory.GetFiles(dir, "*.*", SearchOption.AllDirectories)
                    .Where(file => new string[] { ".rmd" }
                    .Contains(Path.GetExtension(file)))
                    .ToList();
                results.AddRange(rmd_files);
            }
            else
            {
                if (Path.HasExtension(dir))
                {
                    if (Path.GetExtension(dir) == ".rmd" || Path.GetExtension(dir) == ".RMD")
                    {
                        results.Add(dir);
                    }
                }
            }

            return results;
        }
                

        private void RenderLabel()
        {
            int x2 = (pnlFolder.Size.Width - lblCount.Size.Width) / 2;
            lblCount.Location = new Point(x2, lblCount.Location.Y);
        }

        private void BtnStitch_Click(object sender, EventArgs e)
        {
            if(rmd_files.Count <= 0)
            {
                MessageBox.Show("No RMD files have been selected");
            }
            else if(rmd_files.Count == 1)
            {
                MessageBox.Show("I'm sorry, can't work with just single files atm :(");
            }
            else
            {
                //Save the stuff to text file 
                String desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String fileName = desktop_path + "\\" + new DateTime().ToString("yyyyMMddHHmmssffff") + ".txt";

                TextWriter tw = new StreamWriter(fileName);
                foreach (String s in rmd_files)
                {
                    tw.WriteLine(s.Replace("\\", @"/"));
                }
                tw.Close();

                //Run the program on the text file
                Process p = new Process();
                p.StartInfo.FileName = "powershell";
                p.StartInfo.Arguments = " -executionpolicy remotesigned -File  Stitch.ps1 -f " + fileName;
                p.Start();

                p.WaitForExit();

                //Get the response from the resultant text file
                List<String> passed = new List<string>();
                List<String> failed = new List<string>();

                IEnumerable<string> lines = File.ReadLines(fileName + "-fail.txt");
                foreach (string line in lines) failed.Add(line);

                IEnumerable<string> lines2 = File.ReadLines(fileName + "-succeed.txt");
                foreach (string line in lines2) passed.Add(line);


                if (File.Exists(fileName)) File.Delete(fileName);
                if (File.Exists(fileName + "-fail.txt")) File.Delete(fileName + "-fail.txt");
                if (File.Exists(fileName + "-succeed.txt")) File.Delete(fileName + "-succeed.txt");
                //Send Data to the other form
                Report b = new Report();
                b.LoadDetails(passed, failed);
                b.Show();
                Hide();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.CenterToScreen();
            RenderLabel();

            String pandoc_path = GetFullPath("pandoc.exe");
            String rscript_path = GetFullPath("Rscript.exe");


            if (pandoc_path == null || rscript_path == null)
            {
                Process.Start("Patho.exe");
                Close();
            }
        }

        public static bool ExistsOnPath(string fileName)
        {
            return GetFullPath(fileName) != null;
        }

        public static string GetFullPath(string fileName)
        {
            if (File.Exists(fileName))
                return Path.GetFullPath(fileName);

            var values = Environment.GetEnvironmentVariable("PATH");
            foreach (var path in values.Split(';'))
            {
                var fullPath = Path.Combine(path, fileName);
                if (File.Exists(fullPath))
                    return fullPath;
            }
            return null;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            rmd_files.Clear();
            lstDrop.Items.Clear();
            lblDrop.Text = "Drop Files/Folders Here";
            pictureBox3.Visible = true;
            lblCount.Visible = false;
            RenderLabel();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }



}
