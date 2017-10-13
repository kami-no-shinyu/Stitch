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
        public Dictionary<string, string> KnownPaths = new Dictionary<string, string>();


        private void Form1_Load(object sender, EventArgs e)
        {
            CenterToScreen();

            DependencyHelper.CheckDependencies(Data.dependencies);

            // Check once-more if dependency paths are set in case the
            // user cancelled something during path-setting. In that case..
            if (!DependencyHelper.DependenciesSet(Data.dependencies))
            {
                MessageBox.Show("Dependencies have not been set","Dependencies not set",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                Close();
            }
        }

        public Form1() { InitializeComponent(); }


        //UI SECTION
        private void LstDrop_DragEnter(object sender, DragEventArgs e) { if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy; }
        private void LstDrop_DragDrop(object sender, DragEventArgs e)
        {
            string[] drag_content = (string[])e.Data.GetData(DataFormats.FileDrop);

            // [dragged] is either a collection of files or directories
            foreach (string draggged in drag_content)
            {
                foreach (string file in GetFiles(draggged, Data.RMD_EXTENSIONS))
                {
                    if (!RMD_FILES.Contains(file))
                    {
                        RMD_FILES.Add(file);
                    }
                }
            }

            // Change ui once stuff changes
            folder_icon.Visible = false;
            lblCount.Text = RMD_FILES.Count.ToString();
            lblCount.Visible = true;
            CenterLabel(lblCount);
            lblDrop.Text = Data.RMD_FILES_DROPPED;
        }

        /// <summary>
        /// Centers a label within its parent
        /// </summary>
        /// <param name="theLabel"></param>
        private void CenterLabel(Label theLabel)
        {
            int x2 = (theLabel.Parent.Size.Width - theLabel.Size.Width) / 2;
            theLabel.Location = new Point(x2, theLabel.Location.Y);
        }

        /// <summary>
        /// Clears the rmd files list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClearList_Click(object sender, EventArgs e)
        {
            RMD_FILES.Clear();
            KnownPaths.Clear();
            lblDrop.Text = Data.DROP_HERE;
            folder_icon.Visible = true;
            lblCount.Visible = false;
            CenterLabel(lblCount);
        }

     
        // TOOLS SECTION

        /// <summary>
        /// Checks folder for files with extension in extension list
        /// </summary>
        /// <param name="dir"> The directory to search within </param>
        /// <param name="extensions"> The extensions to look out for</param>
        /// <returns>Returns a list of paths of files with extensions in [extensions]</returns>
        private List<String> GetFiles(String dir, List<string> extensions)
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

        /// <summary>
        /// Handles the whole process of replacing paths in the rmd file with desired paths
        /// </summary>
        /// <param name="rmds"></param>
        private void ReplacePaths(List<string> rmds)
        {
            foreach (string rmd in rmds)
            {
                string str = File.ReadAllText(rmd);

                foreach (string line in File.ReadLines(rmd))
                {
                    if (line.Contains("load") || line.Contains("read.delim"))
                    {
                        int start = line.IndexOf('"');
                        int end = line.IndexOf('"', start + 1);
                        string old_path = line.Substring(start, end - start + 1).Replace('"', ' ').Trim();

                        string rmd_name = "";

                        if (old_path.Contains("/")) //If person referenced a path instead of just the filename
                        {
                            rmd_name = old_path.Split('/').Last().Replace('"', ' ').Trim();
                        }
                        else
                        {
                            rmd_name = old_path.Replace('"', ' ').Trim();
                        }


                        if (!KnownPaths.ContainsKey(rmd_name))
                        {
                            KeepAskingForFile(rmd_name);
                        }

                        str = str.Replace(old_path, KnownPaths[rmd_name].Replace(@"\", @"/"));
                    }
                }
                File.WriteAllText(rmd, str);
            }
        }

        /// <summary>
        /// Asks for location of file with name [filename] and adds the new location to knownpaths dictionary
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string KeepAskingForFile(string filename)
        {
            openFile.FileName = filename;
            string ext = Path.GetExtension(filename);
            openFile.Filter = " " + ext + " file (*" + ext + ")|*" + ext;


            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.SafeFileName == filename)
                {
                    KnownPaths[filename] = openFile.FileName;
                    return KnownPaths[filename];
                }
                else
                {
                    MessageBox.Show("You've selected the wrong file\n Please look for [" + filename + "]", "Wrong Replacement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return KeepAskingForFile(filename);
                }

            }
            else
            {
                MessageBox.Show("You haven't selected a replacement", "Missing Replacement", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return KeepAskingForFile(filename);
            }
        }

        /// <summary>
        /// The MAIN Stitching Part
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Stitch_button_Click(object sender, EventArgs e)
        {
            if (RMD_FILES.Count == 0) { MessageBox.Show(Data.NO_RMD_FILES, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
            else
            {
                if (chkReplacePaths.Checked)
                {
                    ReplacePaths(RMD_FILES);
                }

                // Save the paths of RMDs to text file 
                String desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                String fileName = desktop_path + "\\" + new DateTime().ToString("yyyyMMddHHmmssffff") + ".txt";
                TextWriter tw = new StreamWriter(fileName);
                foreach (String s in RMD_FILES) { tw.WriteLine(s.Replace("\\", @"/")); }
                tw.Close();

                // Run the stitcher ppwershell on the text file
                Process p = new Process();
                p.StartInfo.FileName = "powershell";
                p.StartInfo.Arguments = " -executionpolicy remotesigned -File  stitcher.ps1 -f " + fileName;
                p.Start();
                p.WaitForExit();

                // Get the response from the resultant text file
                List<RMD> main = new List<RMD>();

                IEnumerable<string> lines = File.ReadLines(fileName + "-fail.txt");
                foreach (string line in lines) main.Add(new RMD(line));
                IEnumerable<string> lines2 = File.ReadLines(fileName + "-succeed.txt");
                foreach (string line in lines2) main.Add(new RMD(line).SetPass());

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

                BtnClearList_Click(null, null);

                //Send Data to the other form
                Report report = new Report();
                report.SetParentForm(this);
                report.SetRMDFiles(main);
                report.Show();

                Hide();
            }
        }
    }
}
