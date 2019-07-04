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

        public PathList PathList;
        public List<string> Rmds;

        public ProcessForm(PathList pathList,MainForm parent,List<string> rmds)
        {
            PathList = pathList;
            this.parent = parent;
            Rmds = rmds;
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
                var p = new Process
                {
                    StartInfo =
                    {
                        FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe",
                        Arguments = " -executionpolicy remotesigned -File  stitcher.ps1 -f " + PathList.PathOfFile,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        ErrorDialog = false,
                        CreateNoWindow = true
                    },
                    EnableRaisingEvents = true
                };
                p.Start();

                p.ErrorDataReceived += (sendingProcess, errorLine) => Invoke((Action)delegate
                {
                    if(errorLine.Data != null)
                    {
                        lblCount.Visible = true;

                        if (errorLine.Data.Contains("processing file"))
                        {
                            count++;

                            label1.Text = errorLine.Data.Split(':')[1];
                            lblCount.Text = $@"{count}/{Rmds.Count}";
                            CenterControl(label1);
                            CenterControl(lblCount);

                            prog.Value = (int)((count / Rmds.Count) * 100);
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

        List<RMD> _main;
        private void StitchingEnded(object sender, EventArgs e)
        {
            _main = new List<RMD>();

            foreach(string path in PathList.GetFailTaskList().GetPaths())
            {
                _main.Add(new RMD(path));
            }
            foreach(string path in PathList.GetSuccessTaskList().GetPaths())
            {
                _main.Add(new RMD(path).SetPass());
            }
            
            // Delete the files produced
            PathList.Dispose();

            Invoke((Action)(ShowReport));

        }

        private void ShowReport()
        {
            parent.ClearList(null, null);
            DialogResult = DialogResult.OK;
            Close();            
        }

        private void Pending_FormClosing(object sender, FormClosingEventArgs e)
        {
            var report = new ReportForm(parent);
            report.SetParentForm(this);
            report.StageRmdFiles(_main);
            report.Show();
        }

        private static void CenterControl(Control theControl)
        {
            var x2 = (theControl.Parent.Size.Width - theControl.Size.Width) / 2;
            theControl.Location = new Point(x2, theControl.Location.Y);
        }
    }
}
