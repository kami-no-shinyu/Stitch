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

        public void LoadDetails2(List<String> passed,List<String> failed)
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
                lstDrop.Items.Add(name);
            }
            lblfail.Text = "Failed (" + failed.Count.ToString() + ")"; 
            lblsuccess.Text = "Success (" + passed.Count.ToString() + ")";
        }

        public void LoadDetails(List<String> passed, List<String> failed)
        {
            for (int i = 0; i < passed.Count; ++i)
            {
                String name = Path.GetFileNameWithoutExtension(passed[i]);
                book.Add(i.ToString(), Path.GetDirectoryName(passed[i]) + @"\" + name);
                lstSucceed.Items.Add(name);
            }

            for (int i = 0; i < failed.Count; ++i)
            {
                String name = Path.GetFileNameWithoutExtension(failed[i]);
                book.Add((i+passed.Count).ToString(), Path.GetDirectoryName(failed[i]) + @"\" + name);
                lstDrop.Items.Add(name);
            }

            //foreach (String pass in passed)
            //{
            //    String name = Path.GetFileNameWithoutExtension(pass);
            //    book.Add(name, Path.GetDirectoryName(pass) + @"\" + name);
            //    lstSucceed.Items.Add(name);
            //}
            //foreach (String fail in failed)
            //{
            //    String name = Path.GetFileNameWithoutExtension(fail);
            //    book.Add(name, Path.GetDirectoryName(fail) + @"\" + name);
            //    lstDrop.Items.Add(name);
            //}
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

            if (lstDrop.SelectedItems.Count != 0)
            {
                String file_ankasa = book[lstDrop.SelectedItems[0].Text];
                System.Diagnostics.Process.Start(file_ankasa + ".rmd");
                
                lstDrop.SelectedItems[0].BackColor = Color.Blue;
                lstDrop.SelectedItems[0].ForeColor = Color.White;
            }
        }

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Report_Load(object sender, EventArgs e)
        {
                
        }
    }
}
