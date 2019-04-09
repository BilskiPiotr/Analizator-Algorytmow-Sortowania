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
    public partial class LibrarySortDemo : Form
    {
        private static LibrarySortDemo librarysortDemoPanel;
        Controls crl = new Controls();
        public LibrarySortDemo()
        {
            InitializeComponent();
            librarysortDemoPanel = this;
            this.Width = 1000;
            this.Height = 600;
        }

        private void LoadControls()
        {
            string nazwaGb = "";
            GroupBox gbLibrarySortDemo = crl.Create_GoupBox(100, 100, 100, 300, nazwaGb, "Description");
            this.Controls.Add(gbLibrarySortDemo);
        }

        private void LibrarySortDemo_Load(object sender, EventArgs e)
        {
            LoadControls();
        }

        private void LibrarySortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
    }
}
