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

namespace Stitch2
{
    public partial class Report : Form
    {
        private Form parent;
        private Form nextForm;
        public Report(Form nextForm){
            this.nextForm = nextForm;
            InitializeComponent();
        }

        // Dictionary containing the raw name of book to its path
        public Dictionary<String, RMD> book = new Dictionary<string, RMD>();

        public void SetRMDFiles(List<RMD> passed_rmds)
        {
            int fail_count = 0;
            int success_count = 0;

            foreach(RMD rmd in passed_rmds)
            {
                if (book.ContainsKey(rmd.author))
                {
                    book[rmd.author] = rmd;
                } else
                {
                    book.Add(rmd.author, rmd);
                }

                if (rmd.passed)
                {
                    success_count++;
                    lstSuccess2.Items.Add(rmd.author);
                } else
                {
                    fail_count++;
                    lstFailed2.Items.Add(rmd.author);
                }
            }

            lblfail.Text = "Failed (" + fail_count.ToString() + ")";
            lblsuccess.Text = "Success (" + success_count.ToString() + ")";
        }

        
        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            nextForm.Show();
            //Application.Exit();
        }

        public void SetParentForm(Form parent)
        {
            this.parent = parent;
        }
        private void Report_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void LstSucceed_DoubleClick(object sender, MouseEventArgs e)
        {
            if (lstSuccess2.SelectedItems.Count > 0)
            {
                String file_ankasa = book[lstSuccess2.SelectedItem.ToString()].result_prefix;
                try
                {
                    System.Diagnostics.Process.Start(file_ankasa + ".docx");
                }
                catch (Exception)
                {

                }

                //Make the label blue
                lstSuccess2.SetItemChecked(lstSuccess2.SelectedIndex, true);
            }
        }

        private void LstFailed_DoubleClick(object sender, EventArgs e)
        {
            if (lstFailed2.SelectedItems.Count != 0)
            {
                String file_ankasa = book[lstFailed2.SelectedItem.ToString()].file;
                try
                {
                    System.Diagnostics.Process.Start(file_ankasa);
                }
                catch (Exception) { }

                lstFailed2.SetItemChecked(lstFailed2.SelectedIndex, true);

            }
        }
    }
}
