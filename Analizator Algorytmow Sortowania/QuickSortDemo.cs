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
    public partial class QuickSortDemo : Form
    {
        private static QuickSortDemo quicksortDemoPanel;
        Controls crl = new Controls();
        public QuickSortDemo()
        {
            InitializeComponent();
            quicksortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbQuickSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbQuickSortDemo);
        }

        private void QuickSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void QuickSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
