using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Stitch
{
    public partial class ReplaceDialog : Form
    {
        public Dictionary<string, string> KnownPaths = new Dictionary<string, string>();
        public List<string> Unknown = new List<string>();
        public List<string> RmDs { get; set; }

        public ReplaceDialog()
        {
            InitializeComponent();
        }

        public void Init()
        {
            var newKnownPaths = new Dictionary<string, string>();

            foreach(var rmd in RmDs)
            {
                var str = File.ReadAllText(rmd);
                foreach (var line in File.ReadLines(rmd))
                {
                    if (line.Contains("load") || line.Contains("read.delim"))
                    {
                        var start = line.IndexOf('"');
                        var end = line.IndexOf('"', start + 1);
                        var old_path = line.Substring(start, end - start + 1).Replace('"', ' ').Trim();
                        var rmd_name = "";

                        if (old_path.Contains("/")) //If person referenced a path instead of just the filename
                        {
                            rmd_name = old_path.Split('/').Last().Replace('"', ' ').Trim();
                        }
                        else
                        {
                            rmd_name = old_path.Replace('"', ' ').Trim();
                        }

                        if (!Unknown.Contains(rmd_name))
                        {
                            Unknown.Add(rmd_name);
                        }
                    }
                }
            }
            CreateUIForUnknowns();
        }

        private void CreateUIForUnknowns()
        {
            var count = 0;
            foreach(var source in Unknown)
            {
                count++;
                var counter = new Label
                {
                    Text = count.ToString(),
                    Font = new Font("Segoe UI", 10f,FontStyle.Bold),
                    Width = 30
                };

                var sourceName = new Label
                {
                    Text = source,
                    Font = new Font("Segoe UI",8f,FontStyle.Bold)
                };

                var replacer = new Button
                {
                    Text = @"Select"
                };

                var sourceReplacement = new TextBox
                {
                    Width = 150,
                    ForeColor = Color.Gray,
                    Font = replacer.Font,
                    Text = source
                };

                sourceReplacement.GotFocus += delegate
                {
                    sourceReplacement.Text = "";
                    sourceReplacement.ForeColor = Color.Black;
                };
                

                var opener = new OpenFileDialog();

                replacer.Click += delegate
                {
                    if (opener.ShowDialog() != DialogResult.OK) return;
                    sourceReplacement.Text = opener.SafeFileName;
                    KnownPaths[source] = opener.FileName;
                };

                var p = new FlowLayoutPanel();
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
            DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
