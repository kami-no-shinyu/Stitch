using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stitch
{
    public partial class ReplaceDialog : Form
    {
        public Dictionary<string, string> KnownPaths = new Dictionary<string, string>();
        public List<string> unknown = new List<string>();
        public List<string> RMDs { get; set; }

        public ReplaceDialog()
        {
            InitializeComponent();
        }

        public void Init()
        {
            Dictionary<string, string> NewKnownPaths = new Dictionary<string, string>();

            foreach(string rmd in RMDs)
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

                        if (!unknown.Contains(rmd_name))
                        {
                            unknown.Add(rmd_name);
                        }
                    }
                }
            }
            CreateUIForUnknowns();
        }

        private void CreateUIForUnknowns()
        {
            int count = 0;
            foreach(string source in unknown)
            {
                count++;
                Label counter = new Label
                {
                    Text = count.ToString(),
                    Font = new Font("Segoe UI", 10f,FontStyle.Bold),
                    Width = 30
                };

                Label sourceName = new Label
                {
                    Text = source,
                    Font = new Font("Segoe UI",8f,FontStyle.Bold)
                };

                Button replacer = new Button
                {
                    Text = "Select"
                };

                TextBox sourceReplacement = new TextBox()
                {
                    Width = 150,
                    ForeColor = Color.Gray,
                    Font = replacer.Font,
                    Text = source
                };

                sourceReplacement.GotFocus += new EventHandler(delegate (object sender, EventArgs a)
                {
                    sourceReplacement.Text = "";
                    sourceReplacement.ForeColor = Color.Black;
                });
                

                OpenFileDialog opener = new OpenFileDialog();

                replacer.Click += new EventHandler(delegate (Object o, EventArgs a)
                {
                    if(opener.ShowDialog() == DialogResult.OK)
                    {
                        sourceReplacement.Text = opener.SafeFileName;
                        KnownPaths[source] = opener.FileName;
                    }
                });

                FlowLayoutPanel p = new FlowLayoutPanel();
                p.Controls.Add(counter);
                p.Controls.Add(sourceName);
                p.Controls.Add(sourceReplacement);
                p.Controls.Add(replacer);
                p.Width = pan.Width;
                p.Height = 30;

                pan.Controls.Add(p);
            }

        }

        private void Replacer_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            Init();

        }
        
        private void Replacer_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
