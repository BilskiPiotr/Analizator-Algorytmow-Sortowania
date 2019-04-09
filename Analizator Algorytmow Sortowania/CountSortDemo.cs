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
    public partial class CountSortDemo : Form
    {
        private static CountSortDemo countsortDemoPanel;
        Controls crl = new Controls();
        public CountSortDemo()
        {
            InitializeComponent();
            countsortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbCountSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbCountSortDemo);
        }

        private void CountSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void CountSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
