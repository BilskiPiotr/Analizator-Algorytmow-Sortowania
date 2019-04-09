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
    public partial class BucketSortDemo : Form
    {
        private static BucketSortDemo bucketsortDemoPanel;
        Controls crl = new Controls();
        public BucketSortDemo()
        {
            InitializeComponent();
            bucketsortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbBucketSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbBucketSortDemo);
        }

        private void BucketSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void BucketSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
