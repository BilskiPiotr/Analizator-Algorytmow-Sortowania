using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Analizator_Algorytmow_Sortowania
{
    class Controls
    {

        public Button Create_Button(string name, int x, int y, int width, int height, Font czcionka, Color foreColor, Color backColor, string text)
        {
            Button button = new Button
            {
                Location = new Point(x, y),
                Width = width,
                Height = height,
                AutoSize = false,
                Font = czcionka,
                ForeColor = foreColor,
                BackColor = backColor,
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter
            };
            return button;
        }

        public CheckBox Create_CheckBox(string name, int x, int y, int width, Font czcionka, Color foreColor, bool selected, string text)
        {
            CheckBox checkBox = new CheckBox
            {
                Location = new Point(x, y),
                Width = width,
                Font = czcionka,
                ForeColor = foreColor,
                Checked = selected,
                Name = name,
                Text = text
            };
            return checkBox;
        }

        public ComboBox Create_ComboBox(string name, int x, int y, int width, Font czcionka, Color foreColot, Color backColor)
        {
            ComboBox comboBox = new ComboBox
            {
                Location = new Point(x, y),
                Width = width,
                Font = czcionka,
                ForeColor = foreColot,
                BackColor = backColor
            };
            return comboBox;
        }

        // GroupBox 
        public GroupBox Create_GoupBox(int x, int y, int width, int height, string text, string name)
        {
            GroupBox groubBox = new GroupBox
            {
                Location = new Point(x, y),
                Width = width,
                Height = height,
                Text = text,
                Name = name
            };
            return groubBox;
        }

        public Label Create_Label(string name, int x, int y, Font czcionka, Color backColor, Color foreColor, string text)
        {
            Label label = new Label
            {
                Location = new Point(x, y),
                AutoSize = false,
                Font = czcionka,
                BackColor = backColor,
                ForeColor = foreColor,
                Name = name,
                Text = text
            };
            return label;
        }

        public RadioButton Create_Radio(string name, int x, int y, string text)
        {
            RadioButton radio = new RadioButton
            {
                Location = new Point(x, y),
                Name = name,
                Text = text
            };
            return radio;
        }

        public TextBox Create_TextBox(string name, int x, int y, int width, int height, Font czcionka, Color bgColor, Color fColor)
        {
            TextBox tb = new TextBox
            {
                Location = new Point(x, y),
                Width = width,
                Height = height,
                Name = name,
                Font = czcionka,
                BackColor = bgColor,
                ForeColor = fColor
            };
            return tb;
        }

        public TextBox Create_TextBox(string name, int x, int y, int width, Font czcionka, Color bgColor)
        {
            TextBox tb = new TextBox
            {
                Location = new Point(x, y),
                Width = width,
                Name = name,
                Font = czcionka,
                BackColor = bgColor,
                ForeColor = bgColor,
                Text = "",
                BorderStyle = BorderStyle.FixedSingle,
                ReadOnly = true
            };
            return tb;
        }

        public TrackBar Create_TrackBar(string name, int x, int y, int min, int max)
        {
            TrackBar tbar = new TrackBar
            {
                Location = new Point(x, y),
                Minimum = min,
                Maximum = max
            };
            return tbar;
        }

        // Chart Wykres
        public Chart Create_Chart(string name, int x, int y, int width, int height, string text)
        {
            Chart chart = new Chart();
            ChartArea obszarWykresu = new ChartArea();
            Legend opisWykresu = new Legend();
            ((ISupportInitialize)(chart)).BeginInit();
            obszarWykresu.Name = "Wykres";
            chart.ChartAreas.Add(obszarWykresu);
            opisWykresu.Name = "Opis";
            chart.Legends.Add(opisWykresu);
            chart.Location = new Point(x, y);
            chart.Width = width;
            chart.Height = height;
            chart.Name = name;
            chart.Text = text;
            chart.Visible = false;

            return chart;
        }

        // DataGridView do prezentacji tabelarycznej wyników
        public DataGridView Create_DataGridView(string name, int x, int y, int width, int height)
        {
            DataGridView dgw = new DataGridView
            {
                Location = new Point(x, y),
                Width = width,
                Height = height,
                //AutoGenerateColumns = false,
                RowHeadersVisible = false
            };
            //dgw.BringToFront();
            dgw.ScrollBars = ScrollBars.Vertical;
            dgw.AllowUserToAddRows = false;
            dgw.ColumnCount = 6;
            dgw.ColumnHeadersHeight = 65;
            dgw.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgw.Columns[0].Name = "Numer";
            dgw.Columns[0].DataPropertyName = "Numer";
            dgw.Columns[0].Width = 40;
            dgw.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgw.Columns[1].Name = "Liczba operacji";
            dgw.Columns[1].DataPropertyName = "Liczba operacji";
            dgw.Columns[1].Width = 60;
            dgw.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgw.Columns[2].Name = "Czas sortowania";
            dgw.Columns[2].DataPropertyName = "Czas sortowania";
            dgw.Columns[2].Width = 80;
            dgw.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgw.Columns[3].Name = "Złożoność analityczna";
            dgw.Columns[3].DataPropertyName = "Złożoność analityczna";
            dgw.Columns[3].Width = 75;
            dgw.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgw.Columns[4].Name = "Stosunek rozmiaru tablicy do ilości iteracji";
            dgw.Columns[4].DataPropertyName = "Stosunek rozmiaru tablicy do ilości iteracji";
            dgw.Columns[4].Width = 90;
            dgw.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgw.Columns[5].Name = "Stosunek rozmiaru tablicy do Złożoności Analitycznej";
            dgw.Columns[5].DataPropertyName = "Stosunek rozmiaru tablicy do Złożoności Analitycznej";
            dgw.Columns[5].Width = 100;
            //dgw.Visible = false;

            return dgw;
        }
    }
}
