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
    public partial class InsertionSortDemo : Form
    {
        private static InsertionSortDemo insertionsortDemoPanel;
        Controls crl = new Controls();
        public InsertionSortDemo()
        {
            InitializeComponent();
            insertionsortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbInsertionSortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbInsertionSortDemo);
        }

        private void InsertionSortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void InsertionSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
