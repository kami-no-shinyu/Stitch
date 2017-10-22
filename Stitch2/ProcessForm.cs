using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Stitch
{
    public partial class ProcessForm : Form
    {
        public MainForm parent;

        public PathList pathList;
        public List<string> rmds;

        public ProcessForm(PathList path_list,MainForm parent,List<string> rmds)
        {
            this.pathList = path_list;
            this.parent = parent;
            this.rmds = rmds;
            InitializeComponent();
        }

        private void Pending_Load(object sender, EventArgs e)
        {
            parent.Hide();
            Size = parent.Size;
            Location = parent.Location;
            
            foreach(Control c in Controls){ CenterControl(c);}
            
            StartStitching();  
        }

        public void StartStitching()
        {
            float count = 0;
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
                p.StartInfo.Arguments = " -executionpolicy remotesigned -File  stitcher.ps1 -f " + pathList.path_of_file;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.CreateNoWindow = true;
                p.EnableRaisingEvents = true;
                p.Start();

                p.ErrorDataReceived += (sendingProcess, errorLine) => this.Invoke((Action)delegate
                {
                    if(errorLine.Data != null)
                    {
                        lblCount.Visible = true;

                        if (errorLine.Data.Contains("processing file"))
                        {
                            count++;

                            label1.Text = errorLine.Data.Split(':')[1];
                            lblCount.Text = count.ToString() + "/" + rmds.Count;
                            CenterControl(label1);
                            CenterControl(lblCount);

                            prog.Value = (int)((count / rmds.Count) * 100);
                        }
                    }
                });

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
                p.Exited += StitchingEnded;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show(Data.ERROR_DURING_STITCHING, "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Hide();
                parent.Show();
            }
        }

        List<RMD> main = null;
        private void StitchingEnded(object sender, EventArgs e)
        {
            main = new List<RMD>();

            foreach(string path in pathList.GetFailTaskList().GetPaths())
            {
                main.Add(new RMD(path));
            }
            foreach(string path in pathList.GetSuccessTaskList().GetPaths())
            {
                main.Add(new RMD(path).SetPass());
            }
            
            // Delete the files produced
            try
            {
                pathList.Dispose();
            }
            catch (Exception)
            {
                throw;
            }

            Invoke((Action)(() =>
            {
                ShowReport(main);
            }));

        }

        private void ShowReport(List<RMD> main)
        {
            parent.ClearList(null, null);
            DialogResult = DialogResult.OK;
            Close();            
        }

        private void Pending_FormClosing(object sender, FormClosingEventArgs e)
        {
            ReportForm report = new ReportForm(parent);
            report.SetParentForm(this);
            report.SetRMDFiles(main);
            report.Show();
        }

        private void CenterControl(Control theControl)
        {
            int x2 = (theControl.Parent.Size.Width - theControl.Size.Width) / 2;
            theControl.Location = new Point(x2, theControl.Location.Y);
        }
    }
}
