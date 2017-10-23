using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Stitch
{
    public partial class MainForm : Form
    {
        private List<string> RMD_FILES = new List<string>();
        private List<RMD> RMDS = new List<RMD>();

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
            var dragContent = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var draggged in dragContent)
            {
                foreach (var file in FileHandler.GetFiles(draggged, Data.RMD_EXTENSIONS))
                {
                    if (RMD_FILES.Contains(file)) continue;
                    RMD_FILES.Add(file);

                    var tempRmd = new RMD(file);
                    RMDS.Add(tempRmd);
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
            while (true)
            {
                var ext = Path.GetExtension(source);
                openFile.FileName = source;
                openFile.Filter = $@" {ext} file (*{ext})|*{ext}";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    if (openFile.SafeFileName?.ToLower() == source.ToLower())
                    {
                        return openFile.FileName;
                    }
                    var result =MessageBox.Show(Data.Warnings.SELECTED_WRONG_FILE + source + " ]", Data.Warnings.SELECTED_WRONG_FILE_TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel) return Data.EXIT_CODE;
                }
                else
                {
                    var result = MessageBox.Show(Data.Warnings.SELECTED_NOTHING, Data.Warnings.SELECTED_NOTHING_TITLE, MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if (result == DialogResult.Cancel) return Data.EXIT_CODE;
                }
            }
        }

        private bool ReplacePaths(IEnumerable<RMD> rmds)
        {
            var knownSources = new Dictionary<string, string>();

            foreach (var rmd in rmds)
            {
                foreach (var source in rmd.GetSources().Keys)
                {
                    var sourceLower = source.ToLower();
                    if (knownSources.ContainsKey(sourceLower))
                    {
                        rmd.SetSource(source, knownSources[sourceLower]);
                        return true;
                    }

                    var newSource = KeepAskingForSource(source).Replace(@"\", @"/");
                    if (newSource == Data.EXIT_CODE)
                    {
                        return false;
                    }

                    knownSources[sourceLower] = newSource;
                    rmd.SetSource(source, newSource);
                    return true;
                }
            }
            return true;
        }

        private void Stitch(object sender, EventArgs e)
        {
            if (RMDS.Count == 0)
            {
                MessageBox.Show(Data.NO_RMD_FILES, Data.MSG_INFO, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (chkReplacePaths.Checked)
                {
                    if (ReplacePaths(RMDS) == false) return;
                }

                var t = new PathList(RMD_FILES);

                var p = new ProcessForm(t, this, RMD_FILES);
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

        private static void CenterControl(Control theControl)
        {
            var x2 = (theControl.Parent.Size.Width - theControl.Size.Width) / 2;
            theControl.Location = new Point(x2, theControl.Location.Y);
        }
        #endregion

    }
}
