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
    public partial class SelectSortDemo : Form
    {
        private static SelectSortDemo selectsortDemoPanel;
        Controls crl = new Controls();
        public SelectSortDemo()
        {
            InitializeComponent();
            selectsortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbSelectSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbSelectSortDemo);
        }

        private void SelectSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void SelectSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
