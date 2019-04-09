using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace Analizator_Algorytmow_Sortowania
{
    public partial class Analizator : Form
    {
        private static Analizator analizatorPanel;
        Controls crl = new Controls();

        // Manualne zarządzanie zdażeniami wątków typu DEMO
        public static bool demoStatus;
        public static Thread demoThread;

        // Manualne zarządzanie zdażeniami wątków typu Algorytm
        public static bool algStatus;
        public static Thread algThread;

        List<Alg> algorithmList = new List<Alg>();


        public Analizator()
        {
            InitializeComponent();
            analizatorPanel = this;

            //this.demoStatus = false;
            this.Location = new Point(10, 10);
            this.Width = 250;
            this.Height = 70;
        }

        private void Analizator_Load(object sender, EventArgs e)
        {
            CreateMenu();
        }

        private void CreateMenu()
        {
            MenuStrip ms_menuGłówne = new MenuStrip
            {
                Location = new Point(1, 1)
            };
            ToolStripMenuItem topMenuFile = new ToolStripMenuItem("&File");
            ToolStripMenuItem topMenuAlgorytm = new ToolStripMenuItem("&Algorytm");
            ToolStripMenuItem topMenuDemo = new ToolStripMenuItem("&Demo");
            ToolStripMenuItem topMenuAbout = new ToolStripMenuItem("&About");
            ToolStripMenuItem resetData = new ToolStripMenuItem("&Reset");
            ToolStripMenuItem endApplication = new ToolStripMenuItem("&Koniec");

            ToolStripMenuItem bubbleSort = new ToolStripMenuItem("Bubble Sort");
            ToolStripMenuItem bucketSort = new ToolStripMenuItem("Bucket Sort");
            ToolStripMenuItem countSort = new ToolStripMenuItem("Count Sort");
            ToolStripMenuItem insertionSort = new ToolStripMenuItem("Insertion Sort");
            ToolStripMenuItem mergeSort = new ToolStripMenuItem("Merge Sort");
            ToolStripMenuItem quickSort = new ToolStripMenuItem("Quick Sort");
            ToolStripMenuItem selectSort = new ToolStripMenuItem("Select Sort");
            ToolStripMenuItem redixSort = new ToolStripMenuItem("REdix Sort");
            ToolStripMenuItem librarySort = new ToolStripMenuItem("Library Sort");

            ToolStripMenuItem bubbleDemo = new ToolStripMenuItem("Bubble Sort");
            ToolStripMenuItem bucketDemo = new ToolStripMenuItem("Bucket Sort");
            ToolStripMenuItem countDemo = new ToolStripMenuItem("Count Sort");
            ToolStripMenuItem insertionDemo = new ToolStripMenuItem("Insertion Sort");
            ToolStripMenuItem mergeDemo = new ToolStripMenuItem("Merge Sort");
            ToolStripMenuItem quickDemo = new ToolStripMenuItem("Quick Sort");
            ToolStripMenuItem selectDemo = new ToolStripMenuItem("Select Sort");
            ToolStripMenuItem redixDemo = new ToolStripMenuItem("REdix Sort");
            ToolStripMenuItem libraryDemo = new ToolStripMenuItem("Library Sort");


            topMenuFile.DropDownItems.Add(resetData);

            topMenuFile.DropDownItems.Add(endApplication);

            topMenuAlgorytm.DropDownItems.Add(bubbleSort);
            topMenuAlgorytm.DropDownItems.Add(bucketSort);
            topMenuAlgorytm.DropDownItems.Add(countSort);
            topMenuAlgorytm.DropDownItems.Add(insertionSort);
            topMenuAlgorytm.DropDownItems.Add(mergeSort);
            topMenuAlgorytm.DropDownItems.Add(quickSort);
            topMenuAlgorytm.DropDownItems.Add(selectSort);
            topMenuAlgorytm.DropDownItems.Add(redixSort);
            topMenuAlgorytm.DropDownItems.Add(librarySort);

            topMenuDemo.DropDownItems.Add(bubbleDemo);
            topMenuDemo.DropDownItems.Add(bucketDemo);
            topMenuDemo.DropDownItems.Add(countDemo);
            topMenuDemo.DropDownItems.Add(insertionDemo);
            topMenuDemo.DropDownItems.Add(mergeDemo);
            topMenuDemo.DropDownItems.Add(quickDemo);
            topMenuDemo.DropDownItems.Add(selectDemo);
            topMenuDemo.DropDownItems.Add(redixDemo);
            topMenuDemo.DropDownItems.Add(libraryDemo);

            ms_menuGłówne.Items.Add(topMenuFile);
            ms_menuGłówne.Items.Add(topMenuAlgorytm);
            ms_menuGłówne.Items.Add(topMenuDemo);
            ms_menuGłówne.Items.Add(topMenuAbout);

            resetData.Click += new EventHandler(ResetData_Click);
            endApplication.Click += new EventHandler(EndApplication_Click);
            bubbleSort.Click += new EventHandler(BubbleSort_Click);
            bucketSort.Click += new EventHandler(BucketSort_Click);
            countSort.Click += new EventHandler(CountSort_Click);
            insertionSort.Click += new EventHandler(InsertionSort_Click);
            mergeSort.Click += new EventHandler(MergeSort_Click);
            quickSort.Click += new EventHandler(QuickSort_Click);
            selectSort.Click += new EventHandler(SelectSort_Click);
            redixSort.Click += new EventHandler(RedixSort_Click);
            librarySort.Click += new EventHandler(LibrarySort_Click);
            bubbleDemo.Click += new EventHandler(BubbleDemo_Click);
            bucketDemo.Click += new EventHandler(BucketDemo_Click);
            countDemo.Click += new EventHandler(CountDemo_Click);
            insertionDemo.Click += new EventHandler(InsertionDemo_Click);
            mergeDemo.Click += new EventHandler(MergeDemo_Click);
            quickDemo.Click += new EventHandler(QuickDemo_Click);
            selectDemo.Click += new EventHandler(SelectDemo_Click);
            redixDemo.Click += new EventHandler(RedixDemo_Click);
            libraryDemo.Click += new EventHandler(LibraryDemo_Click);
            topMenuAbout.Click += new EventHandler(TopMenuAbout_Click);
            this.Controls.Add(ms_menuGłówne);
        }

        private void ResetData_Click(object sender, EventArgs e)
        {

        }

        // zakończenie programu
        private void EndApplication_Click(object sender, EventArgs e)
        {
            DialogResult drExit = MessageBox.Show("Zakończyć Program?", "",
                MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (drExit == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void BubbleSort_Click(object sender, EventArgs e)
        {
            if (algStatus)
            {
                return;
            }

            Alg.AlgorytmName = "BubbleSort";
            Alg.Algorytm = 1;

            algStatus = true;

            algThread = new Thread(CreateAnalizatorPanel)
            {
                Name = Alg.AlgorytmName
            };
            algThread.Start();
        }

        private void BucketSort_Click(object sender, EventArgs e)
        {

        }

        private void CountSort_Click(object sender, EventArgs e)
        {

        }

        private void InsertionSort_Click(object sender, EventArgs e)
        {
            
        }

        private void MergeSort_Click(object sender, EventArgs e)
        {
            
        }

        private void QuickSort_Click(object sender, EventArgs e)
        {
            
        }

        private void SelectSort_Click(object sender, EventArgs e)
        {

        }

        private void RedixSort_Click(object sender, EventArgs e)
        {

        }

        private void LibrarySort_Click(object sender, EventArgs e)
        {

        }

        #region -> Wywołanie paneli DEMO

        private void BubbleDemo_Click(object sender, EventArgs e)
        {
            if (demoStatus)
            {
                return;
            }

            demoStatus = true;

            demoThread = new Thread(CreateBubbleSortDemoPanel);
            demoThread.Start();
        }

        private void BucketDemo_Click(object sender, EventArgs e)
        {

        }

        private void CountDemo_Click(object sender, EventArgs e)
        {

        }

        private void InsertionDemo_Click(object sender, EventArgs e)
        {

        }

        private void MergeDemo_Click(object sender, EventArgs e)
        {

        }

        private void QuickDemo_Click(object sender, EventArgs e)
        {

        }

        private void SelectDemo_Click(object sender, EventArgs e)
        {

        }

        private void RedixDemo_Click(object sender, EventArgs e)
        {

        }

        private void LibraryDemo_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void TopMenuAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Projekt i Wykonanie: Piotr Bilski, index 43335, gr 373 Vistula, Informatyka, Niestacjonarne", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Analizator_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndApplication_Click(sender, e);
        }

        #region -> Konstruktory paneli DEMO
        private void CreateBubbleSortDemoPanel()
        {
            try
            {
                BubbleSortDemo bubbleSortDemo = new BubbleSortDemo();
                bubbleSortDemo.ShowDialog();
            }
            catch (ThreadAbortException)
            {
                throw;
            }
        }

        private void CreateBucketSortDemoPanel()
        {

        }

        private void CreateCountSortDemoPanel()
        {

        }

        private void CreateInsertionSortDemoPanel()
        {

        }

        private void CreateMergeSortDemoPanel()
        {

        }

        private void CreateQuickSortDemoPanel()
        {

        }

        private void CreateSelectSortDemoPanel()
        {

        }

        private void CreateRedixSortDemoPanel()
        {

        }

        private void CreateLibrarySortDemoPanel()
        {

        }

        #endregion

        private void CreateAnalizatorPanel()
        {
            try
            {
                Panel panel = new Panel
                {
                    Name = Alg.AlgorytmName,
                    Text = Alg.AlgorytmName
                };
                panel.ShowDialog();
            }
            catch (ThreadAbortException)
            {
                throw;
            }
        }
    }
}
