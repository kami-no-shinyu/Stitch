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
        public Report(){InitializeComponent();}

        // Dictionary containing the raw name of book to its path
        public Dictionary<String, String> book = new Dictionary<string, string>();

        public void LoadDetails(List<String> passed,List<String> failed)
        {
            foreach(String pass in passed)
            {
                String name = Path.GetFileNameWithoutExtension(pass);
                book.Add(name, Path.GetDirectoryName(pass) + @"\" + name);
                lstSucceed.Items.Add(name);
            }
            foreach (String fail in failed)
            {
                String name = Path.GetFileNameWithoutExtension(fail);
                book.Add(name, Path.GetDirectoryName(fail) + @"\" + name);
                lstFail.Items.Add(name);
            }
            lblfail.Text = "Failed (" + failed.Count.ToString() + ")"; 
            lblsuccess.Text = "Success (" + passed.Count.ToString() + ")";
        }

        private void LstSucceed_DoubleClick(object sender, EventArgs e)
        {

            if(lstSucceed.SelectedItems.Count > 0)
            {
                String file_ankasa = book[lstSucceed.SelectedItems[0].Text];
                System.Diagnostics.Process.Start(file_ankasa + ".docx");
                
                //Make the label blue
                lstSucceed.SelectedItems[0].BackColor = Color.Blue;
                lstSucceed.SelectedItems[0].ForeColor = Color.White;
            }
          
        }

        private void LstFail_DoubleClick(object sender, EventArgs e)
        {

            if (lstFail.SelectedItems.Count != 0)
            {
                String file_ankasa = book[lstFail.SelectedItems[0].Text];
                System.Diagnostics.Process.Start(file_ankasa + ".rmd");
                
                lstFail.SelectedItems[0].BackColor = Color.Blue;
                lstFail.SelectedItems[0].ForeColor = Color.White;
            }
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
