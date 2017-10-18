using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stitch2
{
    public partial class Replacer : Form
    {
        public Replacer()
        {
            InitializeComponent();
        }

        public Dictionary<string,string> Init()
        {
            Dictionary<string, string> KnownPaths = new Dictionary<string, string>();
            return KnownPaths;
        }

        private void Replacer_Load(object sender, EventArgs e)
        {
            CenterToScreen();
        }
    }
}
