using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analizator_Algorytmow_Sortowania
{
    public partial class RedixSortDemo : Form
    {
        private static RedixSortDemo redixsortDemoPanel;
        Controls crl = new Controls();
        public RedixSortDemo()
        {
            InitializeComponent();
            redixsortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbRedixSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbRedixSortDemo);
        }

        private void RedixSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void RedixSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
