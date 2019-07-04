using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Stitch
{
    public partial class ReportForm : Form
    {
        private Form _parent;
        private Form nextForm;
        public ReportForm(Form nextForm){
            this.nextForm = nextForm;
            InitializeComponent();
        }

        // Dictionary containing the raw name of book to its path
        public Dictionary<string, RMD> Book = new Dictionary<string, RMD>();

        public void StageRmdFiles(List<RMD> rmds)
        {
            var failCount = 0;
            var successCount = 0;

            foreach(var rmd in rmds)
            {
                if (Book.ContainsKey(rmd.Author))
                {
                    Book[rmd.Author] = rmd;
                } else
                {
                    Book.Add(rmd.Author, rmd);
                }

                if (rmd._passed)
                {
                    successCount++;
                    lstSuccess2.Items.Add(rmd.Author);
                } else
                {
                    failCount++;
                    lstFailed2.Items.Add(rmd.Author);
                }
            }

            lblfail.Text = $@"Failed ({failCount})";
            lblsuccess.Text = $@"Success ({successCount})";
        }

        
        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            nextForm.Show();
            //Application.Exit();
        }

        public void SetParentForm(Form parent)
        {
            _parent = parent;
        }
        private void Report_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }

        private void LstSucceed_DoubleClick(object sender, MouseEventArgs e)
        {
            if (lstSuccess2.SelectedItems.Count <= 0) return;
            var fileAnkasa = Book[lstSuccess2.SelectedItem.ToString()]._resultPrefix;
            try
            {
                System.Diagnostics.Process.Start(fileAnkasa + ".docx");
            }
            catch (Exception)
            {
                // ignored
            }

            //Make the label blue
            lstSuccess2.SetItemChecked(lstSuccess2.SelectedIndex, true);
        }

        private void LstFailed_DoubleClick(object sender, EventArgs e)
        {
            if (lstFailed2.SelectedItems.Count == 0) return;
            var fileAnkasa = Book[lstFailed2.SelectedItem.ToString()]._file;
            try
            {
                System.Diagnostics.Process.Start(fileAnkasa);
            }
            catch (Exception)
            {
                // ignored
            }

            lstFailed2.SetItemChecked(lstFailed2.SelectedIndex, true);
        }
    }
}
