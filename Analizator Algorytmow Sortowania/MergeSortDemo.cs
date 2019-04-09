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
    public partial class MergeSortDemo : Form
    {
        private static MergeSortDemo mergesortDemoPanel;
        Controls crl = new Controls();
        public MergeSortDemo()
        {
            InitializeComponent();
            mergesortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbMergeSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbMergeSortDemo);
        }

        private void MergeSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void MergeSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
