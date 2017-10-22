using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Stitch
{
    public partial class MainForm : Form
    {
        List<string> RMD_FILES = new List<string>();
        public Dictionary<string, string> KnownPaths = new Dictionary<string, string>();

        public MainForm() { InitializeComponent(); }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadSettings();
            CenterToScreen();
            LoadDependencies();
        }

        private void LoadSettings()
        {
            chkReplacePaths.Checked = Properties.Settings.Default.replace;
            txtVersion.Text = 'v' + Properties.Settings.Default.version;
        }
        private void LoadDependencies()
        {
            DependencyHelper.CheckDependencies(Data.dependencies);

            if (!DependencyHelper.DependenciesSet(Data.dependencies))
            {
                Close();
            }
        }

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

            // Change ui once stuff changes: Show RMD count
            ShowItemsDroppedUI();
        }

        #region UI Functions
                private void ShowItemsDroppedUI()
                {
                    folder_icon.Visible = false;
                    lblCount.Visible = true;

                    lblCount.Text = RMD_FILES.Count.ToString();
                    lblDrop.Text = Data.RMD_FILES_DROPPED;

                    CenterControl(lblCount);
                }
     
                private void ShowItemsClearedUI()
                {
                    folder_icon.Visible = true;
                    lblCount.Visible = false;

                    lblDrop.Text = Data.DROP_HERE;

                    RMD_FILES.Clear();
                    KnownPaths.Clear();
           
                    CenterControl(lblCount);
                }

                private void CenterControl(Control theControl)
                {
                    int x2 = (theControl.Parent.Size.Width - theControl.Size.Width) / 2;
                    theControl.Location = new Point(x2, theControl.Location.Y);
                }
        #endregion

       
        public void ClearList(object sender, EventArgs e)
        {
            ShowItemsClearedUI();
        }


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
        /// Handles the whole process of replacing paths in the rmd file with desired paths. Returns True if it worked. Returns False if user cancel's operation.
        /// </summary>
        /// <param name="rmds"></param>
        private bool ReplacePaths(List<string> rmds)
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


                        if (!KnownPaths.ContainsKey(rmd_name.ToLower()))
                        {
                            //Keep asking for file but if the user cancels close everything
                            if (KeepAskingForFile(rmd_name) == Data.EXIT_CODE)
                            {
                                goto Close;
                            }
                        }

                        str = str.Replace(old_path, KnownPaths[rmd_name.ToLower()].Replace(@"\", @"/"));
                    }
                }
                File.WriteAllText(rmd, str);
            }

            return true;

            Close:
            return false;
        }

        public Dictionary<string, string> KNOWN = new Dictionary<string, string>();
        private bool ReplacePaths2(List<string> RMD)
        {
            using (var form = new ReplaceDialog())
            {
                form.RMDs = RMD;
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    KNOWN = form.KnownPaths;
                    foreach (string item in form.KnownPaths.Keys)
                    {
                        MessageBox.Show(item + " - " + form.KnownPaths[item]);
                    }
                    foreach (string rmd in RMD)
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


                                if (!KNOWN.Keys.Contains(rmd_name))
                                {

                                }

                                str = str.Replace(old_path, KNOWN[rmd_name].Replace(@"\", @"/"));
                            }
                        }
                        File.WriteAllText(rmd, str);
                    }
                    return true;
                }
                else
                {
                    return false;
                }


            }
        }
        
        /// <summary>
        /// Asks for location of file with name [filename] and adds the new location to knownpaths dictionary
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        private string KeepAskingForFile(string filename)
        {
            string ext = Path.GetExtension(filename);
            openFile.FileName = filename;
            openFile.Filter = " " + ext + " file (*" + ext + ")|*" + ext;


            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.SafeFileName.ToLower() == filename.ToLower())
                {
                    KnownPaths[filename.ToLower()] = openFile.FileName.ToLower();
                    return KnownPaths[filename.ToLower()];
                }
                else
                {
                    DialogResult result = MessageBox.Show(Data.Warnings.SELECTED_WRONG_FILE + filename + " ]", Data.Warnings.SELECTED_WRONG_FILE_TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel) return Data.EXIT_CODE;
                    else return KeepAskingForFile(filename);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(Data.Warnings.SELECTED_NOTHING, Data.Warnings.SELECTED_NOTHING_TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel) return Data.EXIT_CODE;
                else return KeepAskingForFile(filename);
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
            else {

                if (chkReplacePaths.Checked)
                {
                    if (ReplacePaths(RMD_FILES) == false) return;
                }

                PathList t = new PathList(RMD_FILES);

                ProcessForm p = new ProcessForm(t, this, RMD_FILES);
                p.ShowDialog();
            }
        }

        private void OnClose(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.replace = chkReplacePaths.Checked;
            Properties.Settings.Default.Save();
        }
    }
}
