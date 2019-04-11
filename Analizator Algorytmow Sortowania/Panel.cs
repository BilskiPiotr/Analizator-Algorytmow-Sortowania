using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Analizator_Algorytmow_Sortowania
{
    public partial class Panel : Form
    {
        public static Panel panel;

        Controls crl = new Controls();

        Button BtRunTest;

        Chart ChWykres;

        CheckBox ChbAutoData;
        CheckBox ChbManualData;

        ComboBox CbResultMode;
        ComboBox CbLineStyle;

        DataGridView DgwWyniki;

        GroupBox GbDescription;
        GroupBox GbZO;
        GroupBox GbZP;
        GroupBox GbMode;
        GroupBox GbSourceData;
        GroupBox GbAction;
        GroupBox GbChartControl;
        GroupBox GbWyniki;

        Label LbDescription;
        Label LbZOl;
        Label LbZOp;
        Label LbZPl;
        Label LbZPp;
        Label LbLiczbaPowturzen;
        Label LbIloscElementow;
        Label LbMinElement;
        Label LbMaxElement;
        Label LbChartBgColor;
        Label LbChartLineColor;
        Label LbLineWeight;
        Label LbLineStyle;

        TextBox TbLiczbaPowturzen;
        TextBox TbIloscElementow;
        TextBox TbMinElement;
        TextBox TbMaxElement;
        TextBox TbChartBgColor;
        TextBox TbChartLineColor;
        TextBox TbGruboscLinii;
        TextBox TbStylLinii;

        TrackBar TbarGruboscLinii;

        private Font font;
        private Color controlColor = Color.FromKnownColor(KnownColor.Control);
        private Color foreColor;
        private Color backColor;
        private string text;
        private bool selected;
        private Random rnd;
        private Thread posortuj;

        private int licznikOperacji;
        private int iloscElementow;
        private double czas;

        // Tablica opcji prezentacji wyników sortowania
        private object[] resultMode = { "Show Table", "Show Chart" };



        public Panel()
        {
            InitializeComponent();

            panel = this;
            this.Width = (int)(1000);
            this.Height = (int)(600);
        }

        // Wygenerowanie kontrolek dla panelu prezentacji algorytmu
        private void LoadControls()
        {
            GbDescription = crl.Create_GoupBox(15, 10, 715, 85, "Description", "GbDescription");
            panel.Controls.Add(GbDescription);
            text = "        Działanie tego algorytmu polega na porównywaniu dwóch kolejnych elementów i zamianie ich kolejności, " +
                   "jeżeli zaburza ona porządek, w jakim się sortuje tablicę. Sortowanie kończy się, " +
                   "gdy podczas kolejnego przejścia nie dokonano żadnej zmiany. Algorytm sortowania bąbelkowego jest uważany za bardzo zły " +
                   "algorytm sortujący. Można go stosować tylko dla niewielkiej liczby elementów w sortowanym zbiorze (do około 5000). " +
                   "Przy większych zbiorach czas sortowania może być zbyt długi.";
            LbDescription = crl.Create_Label("LbDescription", 5, 15, font = new Font("Microsoft Sans Serif",
                                             9, FontStyle.Regular), controlColor, foreColor = Color.DarkBlue, text);
            GbDescription.Controls.Add(LbDescription);
            LbDescription.Width = 705;
            LbDescription.Height = 65;

            GbZO = crl.Create_GoupBox(740, 10, 232, 40, "", "GbZO");
            panel.Controls.Add(GbZO);
            text = "Złożoność obliczeniowa :";
            LbZOl = crl.Create_Label("LbZOl", 5, 15, font = new Font("Microsoft Sans Serif", 9, FontStyle.Italic),
                                     controlColor, foreColor = Color.Black, text);
            GbZO.Controls.Add(LbZOl);
            LbZOl.Width = 155;
            text = "O(n²)";
            LbZOp = crl.Create_Label("LbZOp", 165, 12, font = new Font("Times New Roman", 16, FontStyle.Bold),
                                     controlColor, foreColor = Color.Red, text);
            GbZO.Controls.Add(LbZOp);
            LbZOp.Width = 65;

            GbZP = crl.Create_GoupBox(740, 55, 232, 40, "", "GbZP");
            panel.Controls.Add(GbZP);
            text = "Złożoność Pamięciowa :";
            LbZPl = crl.Create_Label("LbZPl", 5, 15, font = new Font("Microsoft Sans Serif", 9, FontStyle.Italic),
                                     controlColor, foreColor = Color.Black, text);
            GbZP.Controls.Add(LbZPl);
            LbZPl.Width = 155;
            text = "O(1)";
            LbZPp = crl.Create_Label("LbZPp", 165, 12, font = new Font("Times New Roman", 16, FontStyle.Bold),
                                     controlColor, foreColor = Color.Red, text);
            GbZP.Controls.Add(LbZPp);
            LbZPp.Width = 65;

            GbMode = crl.Create_GoupBox(15, 470, 147, 80, "Mode", "Mode");
            panel.Controls.Add(GbMode);

            ChbAutoData = crl.Create_CheckBox("AutoData", 15, 22, 130, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                            foreColor = Color.Black, selected = true, "Auto generate values");
            GbMode.Controls.Add(ChbAutoData);
            ChbAutoData.CheckedChanged += new EventHandler(AutoData_CheckedChenged);

            ChbManualData = crl.Create_CheckBox("ManualData", 15, 45, 130, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                              foreColor = Color.Black, selected = false, "Self set data values");
            GbMode.Controls.Add(ChbManualData);
            ChbManualData.CheckedChanged += new EventHandler(ManualData_CheckedChanged);

            GbSourceData = crl.Create_GoupBox(174, 470, 325, 80, "Source Data", "SourceData");
            panel.Controls.Add(GbSourceData);
            GbSourceData.Enabled = false;

            LbIloscElementow = crl.Create_Label("LbIloscElementow", 11, 27, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                                controlColor, foreColor = Color.DarkBlue, "Liczba elementów");
            LbIloscElementow.Width = 97;
            LbIloscElementow.Height = 15;
            GbSourceData.Controls.Add(LbIloscElementow);

            TbIloscElementow = crl.Create_TextBox("TbIloscElementow", 110, 24, 40, 25, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                                  backColor = Color.Yellow, foreColor = Color.Red);
            GbSourceData.Controls.Add(TbIloscElementow);
            TbIloscElementow.MaxLength = 4;
            TbIloscElementow.Enter += new EventHandler(TbIloscElementow_Enter);
            TbIloscElementow.KeyPress += new KeyPressEventHandler(TbIloscElementow_KeyPress);

            LbLiczbaPowturzen = crl.Create_Label("LbLiczbaPowturzen", 11, 51, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                                 controlColor, foreColor = Color.DarkBlue, "Ilość symulacji");
            LbLiczbaPowturzen.Width = 97;
            LbLiczbaPowturzen.Height = 15;
            GbSourceData.Controls.Add(LbLiczbaPowturzen);

            TbLiczbaPowturzen = crl.Create_TextBox("TbLiczbaPowturzen", 110, 49, 40, 25, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                                    backColor = Color.Yellow, foreColor = Color.Red);
            GbSourceData.Controls.Add(TbLiczbaPowturzen);
            TbLiczbaPowturzen.MaxLength = 4;
            TbLiczbaPowturzen.Enter += new EventHandler(TbLiczbaPowturzen_Enter);
            TbLiczbaPowturzen.KeyPress += new KeyPressEventHandler(TbLiczbaPowturzen_KeyPress);

            LbMinElement = crl.Create_Label("LbMinElement", 162, 27, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                             controlColor, foreColor = Color.DarkBlue, "Najmniejsza wartość");
            LbMinElement.Width = 107;
            LbMinElement.Height = 15;
            GbSourceData.Controls.Add(LbMinElement);

            TbMinElement = crl.Create_TextBox("TbMinElement", 270, 24, 40, 25, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                               backColor = Color.Yellow, foreColor = Color.Red);
            GbSourceData.Controls.Add(TbMinElement);
            TbMinElement.MaxLength = 4;
            TbMinElement.Enter += new EventHandler(TbMinElement_Enter);
            TbMinElement.KeyPress += new KeyPressEventHandler(TbMinElement_KeyPress);

            LbMaxElement = crl.Create_Label("LbMaxElement", 162, 51, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                             controlColor, foreColor = Color.DarkBlue, "Największa wartość");
            LbMaxElement.Width = 107;
            LbMaxElement.Height = 15;
            GbSourceData.Controls.Add(LbMaxElement);

            TbMaxElement = crl.Create_TextBox("TbMaxElement", 270, 49, 40, 25, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                                    backColor = Color.Yellow, foreColor = Color.Red);
            GbSourceData.Controls.Add(TbMaxElement);
            TbMaxElement.MaxLength = 4;
            TbMaxElement.Enter += new EventHandler(TbMaxElement_Enter);
            TbMaxElement.KeyPress += new KeyPressEventHandler(TbMaxElement_KeyPress);

            GbAction = crl.Create_GoupBox(512, 470, 117, 80, "Action", "Action");
            panel.Controls.Add(GbAction);

            CbResultMode = crl.Create_ComboBox("Compare", 15, 22, 87, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                            foreColor = Color.DarkGreen, backColor = Color.Ivory);
            CbResultMode.SelectedIndexChanged += new EventHandler(ResultMode_SelectedIndexChanged);
            for (int i = 0; i < 2; i++)
            {
                CbResultMode.Items.Add(resultMode[i]);
            }
            GbAction.Controls.Add(CbResultMode);


            BtRunTest = crl.Create_Button("RunAlgorythm", 15, 47, 87, 23, font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold),
                                        foreColor = Color.DarkBlue, backColor = Color.Orange, text = "RUN");
            BtRunTest.Click += new EventHandler(BtRunTest_Click);
            BtRunTest.MouseHover += new EventHandler(BtRunTest_MouseHover);
            BtRunTest.MouseLeave += new EventHandler(BtRunTest_MouseLeave);
            GbAction.Controls.Add(BtRunTest);

            GbChartControl = crl.Create_GoupBox(642, 470, 328, 80, "Chart Control", "ChartControl");
            panel.Controls.Add(GbChartControl);
            GbChartControl.Enabled = false;

            LbChartBgColor = crl.Create_Label("ChartBgColor", 11, 27, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                          controlColor, foreColor = Color.DarkBlue, "Kolor tła");
            LbChartBgColor.AutoSize = false;
            LbChartBgColor.Width = 55;
            LbChartBgColor.Height = 25;
            GbChartControl.Controls.Add(LbChartBgColor);

            LbChartLineColor = crl.Create_Label("ChartBgColor", 11, 51, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                            controlColor, foreColor = Color.DarkBlue, "Kolor linii");
            LbChartLineColor.AutoSize = false;
            LbChartLineColor.Width = 55;
            LbChartLineColor.Height = 25;
            GbChartControl.Controls.Add(LbChartLineColor);

            TbChartBgColor = crl.Create_TextBox("PickChartBgColour", 67, 24, 40, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                                 backColor = Color.Blue);
            TbChartBgColor.Click += new EventHandler(TbChartBgColor_Click);
            TbChartBgColor.GotFocus += new EventHandler(TbChartBgColor_GotFocus);
            TbChartBgColor.MouseHover += new EventHandler(TbChartBgColor_MouseHover);
            GbChartControl.Controls.Add(TbChartBgColor);

            TbChartLineColor = crl.Create_TextBox("PickLineColor", 67, 49, 40, font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold),
                                                   backColor = Color.LightGreen);
            TbChartLineColor.Click += new EventHandler(TbChartLineColor_Click);
            TbChartLineColor.GotFocus += new EventHandler(TbChartLineColor_GotFocus);
            TbChartLineColor.MouseHover += new EventHandler(TbChartLineColor_MouseHover);
            GbChartControl.Controls.Add(TbChartLineColor);

            LbLineWeight = crl.Create_Label("ChartBgColor", 116, 27, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                             controlColor, foreColor = Color.DarkBlue, "Styl linii");
            LbLineWeight.AutoSize = false;
            LbLineWeight.Width = 65;
            LbLineWeight.Height = 25;
            GbChartControl.Controls.Add(LbLineWeight);

            LbLineStyle = crl.Create_Label("ChartBgColor", 116, 51, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                            controlColor, foreColor = Color.DarkBlue, "Grubość linii");
            LbLineStyle.AutoSize = false;
            LbLineStyle.Width = 65;
            LbLineStyle.Height = 25;
            GbChartControl.Controls.Add(LbLineStyle);

            CbLineStyle = crl.Create_ComboBox("CbStylLinii", 185, 20, 88, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                               backColor = Color.Black, foreColor = Color.White);
            CbLineStyle.SelectedIndexChanged += new EventHandler(CbLineStyle_SelectedIndexChanged);
            CbLineStyle.Text = "Solid";
            CbLineStyle.Items.Add(new ComboBoxItem("————————————————", "Solid"));
            CbLineStyle.Items.Add(new ComboBoxItem("ˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑˑ", "Dot"));
            CbLineStyle.Items.Add(new ComboBoxItem("- - - - - - - - - - - - - -", "Dash"));
            CbLineStyle.Items.Add(new ComboBoxItem("- ˑ - ˑ - ˑ - ˑ - ˑ - ˑ - ˑ -", "DashDot"));
            CbLineStyle.Items.Add(new ComboBoxItem("- ˑˑ - ˑˑ - ˑˑ - ˑˑ - ˑˑ - ˑ", "DashDotDot"));
            GbChartControl.Controls.Add(CbLineStyle);

            TbStylLinii = crl.Create_TextBox("TbStylLinii", 283, 20, 34, 29, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                              backColor = Color.White, foreColor = Color.Black);
            TbStylLinii.Text = "————————";
            GbChartControl.Controls.Add(TbStylLinii);

            TbarGruboscLinii = crl.Create_TrackBar("TbarGruboscLinii", 177, 47, 1, 5);
            TbarGruboscLinii.ValueChanged += new EventHandler(TbarGruboscLinii_ValueChanged);
            TbarGruboscLinii.AutoSize = false;
            TbarGruboscLinii.Height = 28;
            GbChartControl.Controls.Add(TbarGruboscLinii);

            TbGruboscLinii = crl.Create_TextBox("TextBoxGruboscLinii", 283, 47, 34, 29, font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular),
                                                 backColor = Color.White, foreColor = Color.Black);
            TbGruboscLinii.Text = "1";
            TbGruboscLinii.TextAlign = HorizontalAlignment.Center;
            TbGruboscLinii.Click += new EventHandler(TbGruboscLinii_Click);
            TbGruboscLinii.KeyPress += new KeyPressEventHandler(TbGruboscLinii_KeyPress);
            TbGruboscLinii.TextChanged += new EventHandler(TbGruboscLinii_TextChanged);
            GbChartControl.Controls.Add(TbGruboscLinii);

            GbWyniki = crl.Create_GoupBox(15, 97, 957, 365, "", "");
            panel.Controls.Add(GbWyniki);

            ChWykres = crl.Create_Chart("Nazwa Wykresu", 15, 11, 450, 348, "Text wykresu");
            ChWykres.Visible = true;
            GbWyniki.Controls.Add(ChWykres);

            DgwWyniki = crl.Create_DataGridView("DgwWyniki", 485, 11, 460, 348);
            DgwWyniki.Visible = true;
            GbWyniki.Controls.Add(DgwWyniki);

            // ustawienie domyślnego trybu wyświetlania wyników
            CbResultMode.SelectedIndex = 0;
        }


        private void TbMinElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void TbMaxElement_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void TbMinElement_Enter(object sender, EventArgs e)
        {
            this.TbMinElement.Text = "";
        }

        private void TbMaxElement_Enter(object sender, EventArgs e)
        {
            this.TbMaxElement.Text = "";
        }

        private void TbIloscElementow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void TbLiczbaPowturzen_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!Char.IsDigit(e.KeyChar)) && (e.KeyChar != Convert.ToChar(Keys.Back)))
                e.Handled = true;
        }

        private void TbIloscElementow_Enter(object sender, EventArgs e)
        {
            this.TbIloscElementow.Text = "";
        }

        private void TbLiczbaPowturzen_Enter(object sender, EventArgs e)
        {
            this.TbLiczbaPowturzen.Text = "";
        }

        // Obsługa zdażenia zmiany stanu dla kontrolki RadioBox AutoData
        private void AutoData_CheckedChenged(object sender, EventArgs e)
        {
            if (ChbAutoData.Checked)
            {
                if (ChbManualData.Checked)
                    ChbManualData.Checked = false;
                GbSourceData.Enabled = false;
                GenerateValues();
            }
            else
                return;
        }

        // Obsługa zdażenia zmiany stanu dla kontrolki RadioBox ManualData
        private void ManualData_CheckedChanged(object sender, EventArgs e)
        {
            if (ChbManualData.Checked)
            {
                if (ChbAutoData.Checked)
                    ChbAutoData.Checked = false;
                GbSourceData.Enabled = true;
                ClearValues();
            }
            else
                return;
        }

        // Ustawienie trybu prezentacji wyniku sortowania
        private void ResultMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CbResultMode.SelectedIndex == 0)
            {
                // prezentacja wyników tabelarycznie
                GbChartControl.Enabled = false;
            }
            else
            {
                // prezentacja wykresu
                GbChartControl.Enabled = true;
            }
        }

        // Reakcja na naciśnięcie buttona "RunAlgotythm"
        private void BtRunTest_Click(object sender, EventArgs e)
        {
            bool testResult = false;

            testResult = CheckInitialValues(TbIloscElementow.Text, TbLiczbaPowturzen.Text, TbMinElement.Text, TbMaxElement.Text);

            if (testResult)
            {
                // Zresetowanie poprzednich kontrolek prezentacji wyników
                if (ChWykres != null)
                {
                    ChWykres.ChartAreas.Clear();
                    this.Refresh();
                }
                if (DgwWyniki != null)
                {
                    if (DgwWyniki.Rows.Count > 0)
                        DgwWyniki.Rows.RemoveAt(0);
                }


                switch (Alg.Algorytm)
                {
                    case 1: // Bubble Sort
                        {
                            RunBubbleSort();
                        }
                        break;
                    case 2: // Bucket Sort
                        {

                        }
                        break;
                    case 3: // Count Sort
                        {

                        }
                        break;
                    case 4: // Insertion Sort
                        {

                        }
                        break;
                    case 5: // Merge Sort
                        {

                        }
                        break;
                    case 6: // Quick Sort
                        {

                        }
                        break;
                    case 7: // Select Sort
                        {

                        }
                        break;
                    case 8: // Redix Sort
                        {

                        }
                        break;
                    case 9: // Library Sort
                        {
                            MessageBox.Show("Nie wybrano algorytmu", "Uwaga!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                            break;                       
                }
            }
            else
                return;


            if (CbResultMode.SelectedIndex == 0)
            {
                DgwWyniki.Visible = true;
                DgwWyniki.Refresh();
            }

            else if (CbResultMode.SelectedIndex == 1)
                CreateChart();
            else
            {
                MessageBox.Show("Nie określono sposobu prezentacji wyników. Proszę wybrać wykres lub tabelę");
                return;
            }
        }

        // Reakcja na najechanie myszką nad Buttor RunAlgorythm
        private void BtRunTest_MouseHover(object sender, EventArgs e)
        {
            BtRunTest.BackColor = Color.Red;
            BtRunTest.ForeColor = Color.White;
        }

        // Reakcja na odsunięcie myszki od Button RunAlgorythm
        private void BtRunTest_MouseLeave(object sender, EventArgs e)
        {
            BtRunTest.BackColor = Color.Orange;
            BtRunTest.ForeColor = Color.DarkBlue;
        }

        // Reakcja na najechanie myszką na pole wyboru koloru tła wykresu
        private void TbChartBgColor_MouseHover(object sender, EventArgs e)
        {
            ((TextBox)sender).Cursor = Cursors.Cross;
        }

        // Reakcja na kliknięcie pola wyboru koloru tła wykresu
        private void TbChartBgColor_Click(object sender, EventArgs e)
        {
            PickColor(TbChartBgColor);
        }

        // Reakcja na najechanie muszką na pole wyboru koloru linii wykresu
        private void TbChartLineColor_MouseHover(object sender, EventArgs e)
        {
            ((TextBox)sender).Cursor = Cursors.Cross;
        }

        // Reakcja na kliknięcie pola wyboru koloru linii wykresu
        private void TbChartLineColor_Click(object sender, EventArgs e)
        {
            PickColor(TbChartLineColor);
        }

        // Ukrywanie kursora w kontrolce TextBox
        private void TbChartBgColor_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        private void TbChartLineColor_GotFocus(object sender, EventArgs e)
        {
            ((TextBox)sender).Parent.Focus();
        }

        // Obsługa zmiany wartości TrackBara w odniesieniu do grubości linii wykresu

        private void TbarGruboscLinii_ValueChanged(object sender, EventArgs e)
        {
            int lineWeight = Alg.ChartLineWeight = TbarGruboscLinii.Value;
            TbGruboscLinii.Text = lineWeight.ToString();
        }

        // Reakcja na wstawienie kursora w TextBox Grubość Linii
        private void TbGruboscLinii_Click(object sender, EventArgs e)
        {
            TbGruboscLinii.SelectionStart = 0;
            TbGruboscLinii.SelectionLength = TbGruboscLinii.Text.Length;
        }

        // Sprawdzenie poprawności wprowadzanych wartości do zmiennej określającej grubośc linii
        private void TbGruboscLinii_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && e.KeyChar != (char)8;
        }

        // Reakcja na zmianę wartości grubości linii wykresu
        private void TbGruboscLinii_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int lineWeight = int.Parse(TbGruboscLinii.Text);

                if (lineWeight > 5)
                {
                    TbarGruboscLinii.Value = 5;
                    Alg.ChartLineWeight = 5;
                }
                else
                {
                    TbarGruboscLinii.Value = Alg.ChartLineWeight = lineWeight;
                }
            }
            catch
            {
                TbGruboscLinii.Text = Alg.ChartLineWeight.ToString();
                throw;
            }
        }

        // Reakcja na zmianę rodzaju linii wykresu
        private void CbLineStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            int linia = CbLineStyle.SelectedIndex;

            // Określenie typu linii w zależności od wyboru użytkownika
            switch (linia)
            {
                case 0:
                    TbStylLinii.Text = "————————";
                    ChWykres.Series[0].BorderDashStyle = ChartDashStyle.Solid;
                    break;
                case 1:
                    TbStylLinii.Text = "ˑˑˑˑˑˑˑˑˑ";
                    ChWykres.Series[0].BorderDashStyle = ChartDashStyle.Dot;
                    break;
                case 2:
                    TbStylLinii.Text = "- - - - -";
                    ChWykres.Series[0].BorderDashStyle = ChartDashStyle.Dash;
                    break;
                case 3:
                    TbStylLinii.Text = "- ˑ - ˑ -";
                    ChWykres.Series[0].BorderDashStyle = ChartDashStyle.DashDot;
                    break;
                case 4:
                    TbStylLinii.Text = "- ˑˑ - ˑˑ";
                    ChWykres.Series[0].BorderDashStyle = ChartDashStyle.DashDotDot;
                    break;
            }
        }

        // Sprawdzenie wartości startowych dla symulacji sortowania
        private bool CheckInitialValues(string iloscElementow, string liczbaPowturzen, string minimalnaWartosc, string maksymalnaWartosc)
        {
            bool testParameters = false;
            int value = 0;

            if (ChbManualData.Checked)
            {
                errorProvider.Clear();
                if (int.TryParse(iloscElementow, out value) && value > 100)
                {
                    Alg.LiczbaElementow = value;
                    testParameters = true;
                    value = 0;
                }
                else
                {
                    errorProvider.SetError(TbIloscElementow, "Minimalna sendowna ilość elementów do testowania algorytmu to 100");
                    testParameters = false;
                    value = 0;
                    return testParameters;
                }
                errorProvider.Clear();
                if (int.TryParse(liczbaPowturzen, out value) && value > 10 && value < 500)
                {
                    Alg.IloscSymulacji = value;
                    testParameters = true;
                    value = 0;
                }
                else
                {
                    errorProvider.SetError(TbLiczbaPowturzen, "Minimalna sensowna liczba powturzeń to 50. Proszę zwiększyć wpisaną wartość");
                    testParameters = false;
                    value = 0;
                    return testParameters;
                }
            }
            else
            {
                Alg.LiczbaElementow = rnd.Next(100, 4999);
                Alg.IloscSymulacji = rnd.Next(10, 499);
            }
            errorProvider.Clear();
            if (int.TryParse(minimalnaWartosc, out value))
            {
                Alg.MinimalnaWartosc = value;
                testParameters = true;
                value = 0;
            }
            else
            {
                testParameters = false;
                value = 0;
                return testParameters;
            }
            if (int.TryParse(maksymalnaWartosc, out value) && value > Alg.MinimalnaWartosc)
            {
                Alg.MaksymalnaWartosc = value;
                testParameters = true;
                value = 0;
            }
            else
            {
                testParameters = false;
                value = 0;
                return testParameters;
            }
            return testParameters;
        }

        // Wygenerowanie wartości startowych dla symulacji obliczeń algorytmu
        private void GenerateValues()
        {
            rnd = new Random();
            int wylosowanaWartosc;

            wylosowanaWartosc = rnd.Next(100, 4999);
            TbIloscElementow.Text = wylosowanaWartosc.ToString();
            wylosowanaWartosc = rnd.Next(100, 499);
            TbLiczbaPowturzen.Text = wylosowanaWartosc.ToString();
            wylosowanaWartosc = rnd.Next(10, 9999);
            TbMinElement.Text = wylosowanaWartosc.ToString();
            wylosowanaWartosc = rnd.Next(wylosowanaWartosc, 99999);
            TbMaxElement.Text = wylosowanaWartosc.ToString();
        }

        // Wyczyszczenie kontrolek TextBox przekazujących wartości dla symulacji obliczeń algorytmu
        private void ClearValues()
        {
            TbIloscElementow.Text = "";
            TbLiczbaPowturzen.Text = "";
            TbMinElement.Text = "";
            TbMaxElement.Text = "";
        }

        // ustalenie wybranego koloru
        private void PickColor (TextBox textBox)
        {
            ColorDialog colorDialog = new ColorDialog();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.BackColor = colorDialog.Color;
            }
        }

        // załadowanie panelu
        private void Panel_Load(object sender, EventArgs e)
        {
            
            LoadControls();
            PrepareDataTables();
            GenerateValues();
        }

        // zamknięcie panelu
        private void Panel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();

            Analizator.algStatus = false;
            Analizator.algThread.Join();
        }

        private void CreateChart()
        {

        }

        private void PrepareDataTables()
        {
            Alg.firstDataTable = new DataTable("First");
            Alg.secondDataTable = new DataTable("Second");

            Alg.firstDataTable.Columns.Add("Nr", typeof (int));
            Alg.firstDataTable.Columns.Add("Rozmiar tablicy", typeof (int));
            Alg.firstDataTable.Columns.Add("Liczba operacji", typeof (int));
            Alg.firstDataTable.Columns.Add("Czas (s)", typeof(double));
            Alg.firstDataTable.Columns.Add("Złożoność obliczeniowa", Type.GetType("System.String"));
            Alg.firstDataTable.Columns.Add("Stosunek rozmiaru tablicy do ilości iteracji", Type.GetType("System.String"));
            Alg.firstDataTable.Columns.Add("Stosunek rozmiaru tablicy do Złożoności Analitycznej", Type.GetType("System.String"));

            for (int i = 0; i < Alg.firstDataTable.Columns.Count; i++)
            {
                Alg.firstDataTable.Columns[i].AllowDBNull = false;
            }

            DataColumn[] uniqueColumn =
            {
                Alg.firstDataTable.Columns["Nr"]
            };

            Alg.firstDataTable.Constraints.Add(new UniqueConstraint(uniqueColumn));
        }


        // Dodanie wyników sortowania do tymczasowej DT
        private void AddToDataTable(DataTable dt, int iloscElementow, int licznikOperacji, double czasSortowania, int licznikPowtórzeń)
        {
            //int nfi = (NumberFormatInfo)CultureInfo.InvariantCulture.NumberFormat.Clone();
            //nfi.NumberGroupSeparator = " ";
            //string formatted = 1234897.11m.ToString("#,0.00", nfi); // "1 234 897.11"
            DataRow row = dt.NewRow();
            row["Nr"] = (licznikPowtórzeń + 1);
            row["Rozmiar tablicy"] = iloscElementow/*.ToString("{0 000 000}")*/;
            row["Liczba operacji"] = licznikOperacji/*.ToString()*/;
            row["Złożoność obliczeniowa"] = (((Alg.LiczbaElementow * Alg.LiczbaElementow) - Alg.LiczbaElementow) / 2).ToString();
            row["Czas (s)"] = czasSortowania;
            row["Stosunek rozmiaru tablicy do ilości iteracji"] = (licznikOperacji / Alg.LiczbaElementow).ToString();
            row["Stosunek rozmiaru tablicy do Złożoności Analitycznej"] = (Convert.ToDouble(Alg.LiczbaElementow) / czasSortowania).ToString();
            dt.Rows.Add(row);
        }

    // napełnienie tablicy do posortowania liczbami losowymi 
    private int[] NapełnienieTablicy(out int liczbaElementow)
        {
            // Zainicjowanie zmiennej losowej
            rnd = new Random();

            // Utworzenie tymczasowej zmiennej lokalnej służącej do załadowania tablicy do sortowania
            int wylosowanaLiczba = 0;

            // Zainicjowanie nowej tablicy tymczasowej
            liczbaElementow = rnd.Next(100, 4999);
            int[] tablicaDoPosortowania = new int[liczbaElementow];

            // Napełnienie tablicy wartościami losowymi ze sprawdzeniem
            for (int i = 0; i < tablicaDoPosortowania.Length; i++)
            {
                wylosowanaLiczba = rnd.Next(Alg.MinimalnaWartosc, Alg.MaksymalnaWartosc);
                tablicaDoPosortowania[i] = wylosowanaLiczba;
            }
            return tablicaDoPosortowania;
        }

        private void RunBubbleSort()
        {
            for (int m = 0; m < Alg.IloscSymulacji; m++)
            {
                Thread.Sleep(7);
                Alg.TablicaDoPosortowania = NapełnienieTablicy(out iloscElementow);
                Alg.SortowanieBąbelkowe(Alg.TablicaDoPosortowania, out licznikOperacji, out czas);
                AddToDataTable(Alg.firstDataTable, iloscElementow, licznikOperacji, czas, m);
            }

            DgwWyniki.DataSource = Alg.firstDataTable;
            DgwWyniki.Refresh();


        }

    }

    public class ComboBoxItem
    {
        public string CbValue;
        public string CbText;

        public ComboBoxItem(string val, string text)
        {
            CbValue = val;
            CbText = text;
        }

        public override string ToString()
        {
            return CbText;
        }
    }
}
