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
        List<RMD> RMDS = new List<RMD>();

        public MainForm() { InitializeComponent(); }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            LoadSettings();
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

            foreach (string draggged in drag_content)
            {
                foreach (string file in FileHandler.GetFiles(draggged, Data.RMD_EXTENSIONS))
                {
                    if (!RMD_FILES.Contains(file))
                    {
                        RMD_FILES.Add(file);

                        RMD temp_RMD = new RMD(file);
                        RMDS.Add(temp_RMD);
                    }
                }
            }

            // Change UI once stuff changes: Show RMD count
            ShowItemsDroppedUI();
        }

        public void ClearList(object sender, EventArgs e)
        {
            ShowItemsClearedUI();
            RMD_FILES.Clear();
            RMDS.Clear();
        }

        private string KeepAskingForSource(string source)
        {
            string ext = Path.GetExtension(source);
            openFile.FileName = source;
            openFile.Filter = " " + ext + " file (*" + ext + ")|*" + ext;

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                if (openFile.SafeFileName.ToLower() == source.ToLower())
                {
                    return openFile.FileName;
                }
                else
                {
                    DialogResult result = MessageBox.Show(Data.Warnings.SELECTED_WRONG_FILE + source + " ]", Data.Warnings.SELECTED_WRONG_FILE_TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel) return Data.EXIT_CODE;
                    else return KeepAskingForSource(source);
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(Data.Warnings.SELECTED_NOTHING, Data.Warnings.SELECTED_NOTHING_TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel) return Data.EXIT_CODE;
                else return KeepAskingForSource(source);
            }
        }

        private bool ReplacePaths(List<RMD> rmds)
        {
            Dictionary<string, string> KnownSources = new Dictionary<string, string>();

            foreach (RMD rmd in rmds)
            {
                foreach (string source in rmd.GetSources().Keys)
                {
                    string source_lower = source.ToLower();
                    if (KnownSources.ContainsKey(source_lower))
                    {
                        rmd.SetSource(source, KnownSources[source_lower]);
                        return true;
                    }
                    else
                    {
                        string new_source = KeepAskingForSource(source).Replace(@"\", @"/");
                        if (new_source == Data.EXIT_CODE)
                        {
                            return false;
                        }
                        else
                        {
                            KnownSources[source_lower] = new_source;
                            rmd.SetSource(source, new_source);
                            return true;
                        }
                    }
                }
            }

            return true;
        }

        private void Stitch(object sender, EventArgs e)
        {
            if (RMDS.Count == 0)
            {
                MessageBox.Show(Data.NO_RMD_FILES, "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (chkReplacePaths.Checked)
                {
                    if (ReplacePaths(RMDS) == false) return;
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

            CenterControl(lblCount);
        }

        private void CenterControl(Control theControl)
        {
            int x2 = (theControl.Parent.Size.Width - theControl.Size.Width) / 2;
            theControl.Location = new Point(x2, theControl.Location.Y);
        }
        #endregion

    }
}
