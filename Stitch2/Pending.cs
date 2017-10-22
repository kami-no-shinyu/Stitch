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

namespace Stitch
{
    public partial class Pending : Form
    {
        public string storage;
        public Form1 parent;
        public List<string> rmds;

        public Pending(string filename,Form1 parent,List<string> rmds)
        {
            this.storage = filename;
            this.parent = parent;
            this.rmds = rmds;
            InitializeComponent();
        }

        private void Pending_Load(object sender, EventArgs e)
        {
            this.parent.Hide();
            this.Size = this.parent.Size;
            this.Location = this.parent.Location;
            this.CenterControl(prog);
            this.CenterControl(label1);
            this.CenterControl(lblCount);
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
                p.StartInfo.Arguments = " -executionpolicy remotesigned -File  stitcher.ps1 -f " + this.storage;
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
                            MessageBox.Show(prog.Value.ToString());
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
            catch (Exception)
            {
                MessageBox.Show("An Error Occurred During the Stitching", "Ooops", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        List<RMD> main = null;

        private void P_Exited(object sender, EventArgs e)
        {

            // Get the response from the resultant text file
            main = new List<RMD>();

            IEnumerable<string> lines = File.ReadLines(this.storage + "-fail.txt");
            foreach (string line in lines) main.Add(new RMD(line));
            IEnumerable<string> lines2 = File.ReadLines(this.storage + "-succeed.txt");
            foreach (string line in lines2) main.Add(new RMD(line).SetPass());

            // Delete the files produced
            try
            {
                if (File.Exists(this.storage)) File.Delete(this.storage);
                if (File.Exists(this.storage + "-fail.txt")) File.Delete(this.storage + "-fail.txt");
                if (File.Exists(this.storage + "-succeed.txt")) File.Delete(this.storage + "-succeed.txt");
            }
            catch (Exception)
            {
                throw;
            }

            this.Invoke((Action)(() =>
            {
                ShowReport(main);
            }));

        }

        private void ShowReport(List<RMD> main)
        {
            this.parent.BtnClearList_Click(null, null);
            //Send Data to the other form
            this.DialogResult = DialogResult.OK;
            Close();            
        }

        private void Pending_FormClosing(object sender, FormClosingEventArgs e)
        {
            Report report = new Report(this.parent);
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
