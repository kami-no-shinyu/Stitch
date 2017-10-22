using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Stitch
{
    public partial class ProcessForm : Form
    {
        public PathList path_list;
        public MainForm parent;
        public List<string> rmds;

        public ProcessForm(PathList path_list,MainForm parent,List<string> rmds)
        {
            this.path_list = path_list;
            this.parent = parent;
            this.rmds = rmds;
            InitializeComponent();
        }

        private void Pending_Load(object sender, EventArgs e)
        {
            parent.Hide();
            Size = parent.Size;
            Location = parent.Location;
            CenterControl(prog);
            CenterControl(label1);
            CenterControl(lblCount);
            CenterControl(label2);
            Init();  
        }

        public float count = 0;
        public void Init()
        {
            try
            {
                // Run the stitcher ppwershell on the text file
                Process p = new Process();
                p.StartInfo.FileName = @"C:\Windows\SysWOW64\WindowsPowerShell\v1.0\powershell.exe";
                p.StartInfo.Arguments = " -executionpolicy remotesigned -File  stitcher.ps1 -f " + path_list.path_of_file;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.ErrorDialog = false;
                p.StartInfo.CreateNoWindow = true;
                p.EnableRaisingEvents = true;
                p.Start();

                p.OutputDataReceived += (sendingProcess, outLine) => this.Invoke((Action)delegate
                {
                    if (outLine.Data != null)
                    {
                        lblCount.Visible = true;
                        label1.Text = outLine.Data;
                        if (outLine.Data.Contains("processing file"))
                        {
                            count++;
                            lblCount.Text = count.ToString() + "/" + rmds.Count;
                            this.CenterControl(lblCount);

                            //MessageBox.Show("Count: " + count.ToString() + "RMD Count: " + rmds.Count.ToString() + "Percentage: " + ((count / rmds.Count)).ToString() + " " + outLine.Data);
                            prog.Value = (int)((count / rmds.Count) * 100);
                        }
                    }
                });
                p.ErrorDataReceived += (sendingProcess, errorLine) => this.Invoke((Action)delegate
                {
                    if(errorLine.Data != null)
                    {
                        lblCount.Visible = true;

                        if (errorLine.Data.Contains("processing file"))
                        {
                            label1.Text = errorLine.Data.Split(':')[1];
                            CenterControl(label1);
                            count++;
                            lblCount.Text = count.ToString() + "/" + rmds.Count;
                            this.CenterControl(lblCount);

                            //MessageBox.Show("Count: " + count.ToString() + "RMD Count: " + rmds.Count.ToString() + "Percentage: " + ((count / rmds.Count)).ToString() + " " + errorLine.Data);
                            prog.Value = (int)((count / rmds.Count) * 100);
                        }
                    }
                   
                });

                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                p.Exited += P_Exited;


            }
            catch (Exception e)
            {
                MessageBox.Show(e.StackTrace);
                MessageBox.Show("An Error Occurred During the Stitching", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        List<RMD> main = null;

        private void P_Exited(object sender, EventArgs e)
        {

            // Get the response from the resultant text file
            main = new List<RMD>();

            foreach(string path in path_list.GetFailTaskList().GetPaths())
            {
                main.Add(new RMD(path));
            }
            foreach(string path in path_list.GetSuccessTaskList().GetPaths())
            {
                main.Add(new RMD(path).SetPass());
            }
            
            // Delete the files produced
            try
            {
                path_list.Dispose();
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
            //Send Data to the other form
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
