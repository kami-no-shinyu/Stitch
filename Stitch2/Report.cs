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
        public Report()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Report_Load(object sender, EventArgs e)
        {

        }

        public Dictionary<String, String> book = new Dictionary<string, string>();
        public void LoadDetails(List<String> passed,List<String> failed)
        {
            foreach(String pass in passed)
            {
                String name = Path.GetFileNameWithoutExtension(pass);
                book.Add(name, pass);
                lstSucceed.Items.Add(name);
            }
            foreach (String fail in failed)
            {
                String name = Path.GetFileNameWithoutExtension(fail);
                book.Add(name, fail);
                lstFail.Items.Add(name);
            }
        }

        private void lstSucceed_DoubleClick(object sender, EventArgs e)
        {
            //Open the selected index's rmd file 

            if(lstSucceed.SelectedItems.Count == 0)
            {

            }
            else
            {
                String file_ankasa = book[lstSucceed.SelectedItems[0].Text];
                System.Diagnostics.Process.Start(file_ankasa);


                //Make the label blue
                lstSucceed.SelectedItems[0].BackColor = Color.Blue;
                lstSucceed.SelectedItems[0].ForeColor = Color.White;
            }
          
        }

        private void lstFail_DoubleClick(object sender, EventArgs e)
        {

            if (lstFail.SelectedItems.Count == 0)
            {

            }
            else
            {
                String file_ankasa = book[lstFail.SelectedItems[0].Text];
                System.Diagnostics.Process.Start(file_ankasa);


                //Make the label blue
                lstFail.SelectedItems[0].BackColor = Color.Blue;
                lstFail.SelectedItems[0].ForeColor = Color.White;
            }
        }
    }
}
