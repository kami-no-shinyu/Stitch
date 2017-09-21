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
        List<string> RMD_FILES = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            SetUI();
            CheckDependencies();
        }

        // UI Section
        public Form1(){InitializeComponent();}
        private void LstDrop_DragEnter(object sender, DragEventArgs e){if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;}
        private void LstDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] drag_content = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file_str in drag_content)
            {
                foreach(string file in GetFilesList(file_str))
                {
                    String file_name = Path.GetFileNameWithoutExtension(file);
        
                    if (!RMD_FILES.Contains(file))
                    {
                        RMD_FILES.Add(file);
                        lstDrop.Items.Add(file_name);
                    }
                }
            }

            img_folder.Visible = false;
            CenterLabel();
            lblCount.Text = RMD_FILES.Count.ToString();
            lblCount.Visible = true;
            lblDrop.Text = Data.RMD_FILES_DROPPED;
        }
        private void SetUI()
        {
            CenterToScreen();
            CenterLabel();
        }
        private void CenterLabel()
        {
            int x2 = (pnlFolder.Size.Width - lblCount.Size.Width) / 2;
            lblCount.Location = new Point(x2, lblCount.Location.Y);
        }


        private void BtnStitch_Click(object sender, EventArgs e)
        {
            if (RMD_FILES.Count == 0) {MessageBox.Show(Data.NO_RMD_FILES,"Info", MessageBoxButtons.OK,MessageBoxIcon.Warning);}
            else if (RMD_FILES.Count == 1) { MessageBox.Show(Data.ONLY_ONE_RMD, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                // Save the paths of RMDs to text file 
                String desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String fileName = desktop_path + "\\" + new DateTime().ToString("yyyyMMddHHmmssffff") + ".txt";
                TextWriter tw = new StreamWriter(fileName);
                foreach (String s in RMD_FILES){tw.WriteLine(s.Replace("\\", @"/"));}
                tw.Close();

                // Run the stitcher ppwershell on the text file
                Process p = new Process();
                p.StartInfo.FileName = "powershell";
                p.StartInfo.Arguments = " -executionpolicy remotesigned -File  Stitch.ps1 -f " + fileName;
                p.Start();
                p.WaitForExit();

                // Get the response from the resultant text file
                List<String> passed = new List<string>();
                List<String> failed = new List<string>();

                IEnumerable<string> lines = File.ReadLines(fileName + "-fail.txt");
                foreach (string line in lines) failed.Add(line);
                IEnumerable<string> lines2 = File.ReadLines(fileName + "-succeed.txt");
                foreach (string line in lines2) passed.Add(line);

                // Delete the files produced
                try
                {
                    if (File.Exists(fileName)) File.Delete(fileName);
                    if (File.Exists(fileName + "-fail.txt")) File.Delete(fileName + "-fail.txt");
                    if (File.Exists(fileName + "-succeed.txt")) File.Delete(fileName + "-succeed.txt");
                }
                catch (Exception)
                {

                    throw;
                }
                
                //Send Data to the other form
                Report report = new Report();
                report.LoadDetails(passed, failed);
                report.Show();

                Hide();
            }
        }
        private void BtnClearList_Click(object sender, EventArgs e)
        {
            RMD_FILES.Clear();
            lstDrop.Items.Clear();
            lblDrop.Text = Data.DROP_HERE;
            img_folder.Visible = true;
            lblCount.Visible = false;
            CenterLabel();
        }


        // Dependency Checking
        private void CheckDependencies()
        {
            //Check If Dependencies are set right
            if (!ExistsOnPath("pandoc.exe") || !ExistsOnPath("Rscript.exe"))
            {
                Process.Start("Patho.exe");
                Close();
            }
        }
        public static bool ExistsOnPath(string fileName){return GetFullPath(fileName) != null;}
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


        //// Tools Section 

        // Returns list of all rmd files in folder ( including subfolders )
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

       
    }



}
