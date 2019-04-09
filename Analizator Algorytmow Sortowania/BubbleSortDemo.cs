using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;

namespace Analizator_Algorytmow_Sortowania
{
    public partial class BubbleSortDemo : Form
    {
        public static Graphics bubbleSortDemo;
        public static Color kolorObiektu;
        public static BubbleSortDemo bubblesortDemoPanel;

        Random liczbaDemo = new Random();
        List<CM_ElementyDemo> listaElementówDemo = new List<CM_ElementyDemo>(0);

        private int startX;
        private int startY;
        private int promien;
        private int wylosowanaLiczba;

        protected int[] liczbyDoDemo = new int[10];
        public static int index = -1;

        // manual thread management variable
        private Thread demoThread;
        private bool bubbleDemoStatus = false;
        private bool posortowana;
        private bool koniec = false;
        private ManualResetEvent resetEvent = new ManualResetEvent(true);

        Controls crl = new Controls();

        public BubbleSortDemo()
        {
            InitializeComponent();

            bubblesortDemoPanel = this;
            this.Width = (int)(1000);
            this.Height = (int)(600);

            // Zdefiniowanie koloru tła formularza
            this.BackColor = Color.Ivory;

            // Ustawienie obramowania jako dialog box
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void BubbleSortDemo_Paint(object sender, PaintEventArgs e)
        {
            // Przypisanie całej powierzchni formy jako pola graficznego na którym będzie wykonywana animacja
            bubbleSortDemo = e.Graphics;

            // Zapobieżenie migotaniu ekranu przy wyświetlaniu animacji
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            this.DoubleBuffered = true;

            // Wypisanie na powierzchni formularza nazwy DEMO
            SolidBrush pedzelNazwaDemoFront = new SolidBrush(Color.Blue);
            SolidBrush pedzelNazwaDemoBack = new SolidBrush(Color.Black);
            Font fontOpisDemo = new Font("Times New Roman", 24, FontStyle.Bold);
            PointF pozycjaNapisDemoFront = new Point(10, 10);
            PointF pozycjaNapisDemoBack = new Point(11, 11);
            bubbleSortDemo.DrawString("Bubble Sort Demo", fontOpisDemo, pedzelNazwaDemoBack, pozycjaNapisDemoBack);
            bubbleSortDemo.DrawString("Bubble Sort Demo", fontOpisDemo, pedzelNazwaDemoFront, pozycjaNapisDemoFront);

            pedzelNazwaDemoBack.Dispose();
            pedzelNazwaDemoFront.Dispose();
            bubbleSortDemo.Dispose();
        }


        private void ArrowRight(Graphics plansza)
        {
            Pen pen = new Pen(Color.Red, 9.0f);
            Point[] arrowhead = new Point[]
            {
                new Point((this.Width / 2) + 20, (this.Height / 2) - 15),
                new Point((this.Width / 2) + 40, (this.Height / 2) - 30),
                new Point((this.Width / 2) + 20, (this.Height / 2) - 45)
            };
            Point[] line = new Point[]
            {
                new Point((this.Width / 2) - 40, (this.Height / 2) - 30),
                new Point((this.Width / 2) + 36, (this.Height / 2) - 30)
            };
            plansza.DrawLines(pen, arrowhead);
            plansza.DrawLines(pen, line);

            pen.Dispose();
        }

        private void ArrowBoth(Graphics plansza)
        {
            Pen penB = new Pen(Color.Orange, 5.0f);
            Pen penS = new Pen(Color.Orange, 5.0f);
            Point[] arrowheadL = new Point[]
{
                new Point((this.Width / 2) - 20, (this.Height / 2) - 15),
                new Point((this.Width / 2) - 40, (this.Height / 2) - 30),
                new Point((this.Width / 2) - 20, (this.Height / 2) - 45)
};
            Point[] arrowheadR = new Point[]
            {
                new Point((this.Width / 2) + 20, (this.Height / 2) - 15),
                new Point((this.Width / 2) + 40, (this.Height / 2) - 30),
                new Point((this.Width / 2) + 20, (this.Height / 2) - 45)
            };
            Point[] lineU = new Point[]
            {
                new Point((this.Width / 2) - 20, (this.Height / 2) - 25),
                new Point((this.Width / 2) + 20, (this.Height / 2) - 25)
            };
            Point[] lineL = new Point[]
{
                new Point((this.Width / 2) - 20, (this.Height / 2) - 35),
                new Point((this.Width / 2) + 20, (this.Height / 2) - 35)
            };
            plansza.DrawLines(penB, arrowheadL);
            plansza.DrawLines(penB, arrowheadR);
            plansza.DrawLines(penS, lineU);
            plansza.DrawLines(penS, lineL);

            penB.Dispose();
            penS.Dispose();
        }

        private void SameBoth(Graphics plansza)
        {
            Pen penS = new Pen(Color.Green, 5.0f);
            Point[] lineU = new Point[]
            {
                new Point((this.Width / 2) - 20, (this.Height / 2) - 25),
                new Point((this.Width / 2) + 20, (this.Height / 2) - 25)
            };
            Point[] lineL = new Point[]
{
                new Point((this.Width / 2) - 20, (this.Height / 2) - 35),
                new Point((this.Width / 2) + 20, (this.Height / 2) - 35)
            };
            plansza.DrawLines(penS, lineU);
            plansza.DrawLines(penS, lineL);

            penS.Dispose();
        }

        private void OK(Graphics plansza)
        {
            Font font = new Font("Arial", 36, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Green);
            plansza.DrawString("OK!", font, brush, ((this.Width / 2) - 50), ((this.Height / 2) - 58));

            brush.Dispose();
        }

        private void ClearCenter(Graphics plansza)
        {
            SolidBrush tlo = new SolidBrush(Color.Ivory);
            plansza.FillRectangle(tlo, (this.Width / 2) - (90 / 2), (this.Height / 2) - 70, 90, 70);

            tlo.Dispose();
        }

        private void Posortowana(Graphics plansza)
        {
            SolidBrush pedzel = new SolidBrush(Color.Blue);
            Font font = new Font("Microsoft Sans Serif", 48, FontStyle.Bold);
            PointF pozycja = new Point((this.Width / 2) - 200, (this.Height / 2) - 70);

            plansza.DrawString("posortowana", font, pedzel, pozycja);

            pedzel.Dispose();
        }

        public void StartDemo()
        {
            if (!this.bubbleDemoStatus)
            {
                return;
            }
            else
            {
                bubbleSortDemo = pbDemo.CreateGraphics();

                DrawBaseElements(bubbleSortDemo);
                GenerateRandomNumbers(bubbleSortDemo);
                PrintRandomNumbers(bubbleSortDemo);
                BubbleSort(bubbleSortDemo);
            }
        }


        private void DrawBaseElements(Graphics plansza)
        {
            startX = 185;
            startY = 80;
            promien = 25;
            index = 0;
            kolorObiektu = Color.LightBlue;

            pbDemo.CreateGraphics().SmoothingMode = SmoothingMode.AntiAlias;

            for (int i = 0; i < 10; i++)
            {
                listaElementówDemo.Add(new C_Kola(startX, startY, plansza, kolorObiektu, promien));
                listaElementówDemo[index].CM_Draw();
                startX = (startX + 70);
                index++;
                Thread.Sleep(300);
                resetEvent.WaitOne();
            }
            Thread.Sleep(1000);
        }

        private void GenerateRandomNumbers(Graphics plansza)
        {
            SolidBrush pedzel = new SolidBrush(Color.Black);
            Font font = new Font("Times New Roman", 48, FontStyle.Bold);
            PointF pozycja = new Point((this.Width / 2) - (83 / 2), (this.Height / 2) - 70);

            for (int i = 0; i < 10; i++)
            {
                wylosowanaLiczba = liczbaDemo.Next(20, 99);
                liczbyDoDemo[i] = wylosowanaLiczba;
                ClearCenter(plansza);
                plansza.DrawString(Convert.ToString(wylosowanaLiczba), font, pedzel, pozycja);
                Thread.Sleep(500);
                resetEvent.WaitOne();
            }
            ClearCenter(plansza);
            pedzel.Dispose();
            Thread.Sleep(500);
        }

        private void PrintRandomNumbers(Graphics plansza)
        {
            startX = 174;
            startY = 72;
            promien = 25;
            string liczba;
            Font czcionka = new Font("Arial", 24);
            Color kolorCzcionki = Color.Black;

            for (int i = 10; i < 20; i++)
            {
                liczba = Convert.ToString(liczbyDoDemo[i - 10]);
                index++;
                listaElementówDemo.Add(new C_Liczby(startX, startY, liczba, plansza, czcionka, kolorCzcionki, promien));
                listaElementówDemo[index - 1].CM_Draw();
                startX = startX + 70;
                Thread.Sleep(200);
                resetEvent.WaitOne();
            }
        }

        private void BubbleSort(Graphics plansza)
        {
            int x1, x2, xk1, xk2;
            int y1, y2, yk1, yk2;

            for (int i = 0; i < liczbyDoDemo.Length - 1; i++)
            {
                posortowana = true;
                for (int j = 0; j < liczbyDoDemo.Length - 1; j++)
                {
                    // pobrac wspolrzedne tylko liczb
                    xk1 = listaElementówDemo[j].pozycjaX;
                    yk1 = listaElementówDemo[j].pozycjaY;
                    xk2 = listaElementówDemo[j + 1].pozycjaX;
                    yk2 = listaElementówDemo[j + 1].pozycjaY;

                    x1 = listaElementówDemo[j + 10].pozycjaX;
                    y1 = listaElementówDemo[j + 10].pozycjaY;
                    x2 = listaElementówDemo[j + 11].pozycjaX;
                    y2 = listaElementówDemo[j + 11].pozycjaY;

                    listaElementówDemo[j].CM_Move(((this.Width / 2) -100), ((this.Height / 2) - 33));
                    listaElementówDemo[j + 10].CM_Move(((this.Width / 2) - 112), ((this.Height / 2) - 40));
                    listaElementówDemo[j + 1].CM_Move(((this.Width / 2) + 100), ((this.Height / 2) - 33));
                    listaElementówDemo[j + 11].CM_Move(((this.Width / 2) + 88), ((this.Height / 2) - 40));
                    resetEvent.WaitOne();


                    if (liczbyDoDemo[j] < liczbyDoDemo[j + 1])
                    {
                        ArrowBoth(plansza);
                        resetEvent.WaitOne();
                        Thread.Sleep(300);
                        resetEvent.WaitOne();
                        ClearCenter(plansza);
                        resetEvent.WaitOne();
                        OK(plansza);
                        resetEvent.WaitOne();
                        Thread.Sleep(500);
                        resetEvent.WaitOne();
                        ClearCenter(plansza);
                        resetEvent.WaitOne();

                        listaElementówDemo[j].CM_Move(xk1, yk1);
                        listaElementówDemo[j + 1].CM_Move(xk2, yk2);
                        listaElementówDemo[j + 10].CM_Move(x1, y1);
                        listaElementówDemo[j + 11].CM_Move(x2, y2);
                        resetEvent.WaitOne();
                        Thread.Sleep(300);
                        resetEvent.WaitOne();
                    }
                    else
                        if (liczbyDoDemo[j] == liczbyDoDemo[j + 1])
                    {
                        ArrowBoth(plansza);
                        resetEvent.WaitOne();
                        Thread.Sleep(300);
                        resetEvent.WaitOne();
                        ClearCenter(plansza);
                        resetEvent.WaitOne();
                        SameBoth(plansza);
                        resetEvent.WaitOne();
                        Thread.Sleep(500);
                        resetEvent.WaitOne();
                        ClearCenter(plansza);
                        resetEvent.WaitOne();

                        listaElementówDemo[j].CM_Move(xk1, yk1);
                        listaElementówDemo[j + 1].CM_Move(xk2, yk2);
                        listaElementówDemo[j + 10].CM_Move(x1, y1);
                        listaElementówDemo[j + 11].CM_Move(x2, y2);
                        resetEvent.WaitOne();
                        Thread.Sleep(300);
                        resetEvent.WaitOne();
                    }
                    else
                            if (liczbyDoDemo[j] > liczbyDoDemo[j + 1])
                    {
                        ArrowBoth(plansza);
                        resetEvent.WaitOne();
                        Thread.Sleep(300);
                        resetEvent.WaitOne();
                        ClearCenter(plansza);
                        resetEvent.WaitOne();
                        ArrowRight(plansza);
                        resetEvent.WaitOne();
                        Thread.Sleep(500);
                        resetEvent.WaitOne();
                        resetEvent.WaitOne();

                        int leftUp_x = (this.Width / 2) - 100;
                        int leftUp_y = (this.Height / 2) - 33;
                        int rightUp_x = (this.Width / 2) + 100;
                        int rightUp_y = (this.Height / 2) - 33;
                        int rightDown_x = (this.Width / 2) - 112;
                        int rightDown_y = (this.Height / 2) - 40;
                        int leftDown_x = (this.Width / 2) + 88;
                        int leftDown_y = (this.Height / 2) - 40;

                        do
                        {
                            listaElementówDemo[j].CM_Move(leftUp_x, leftUp_y);
                            listaElementówDemo[j + 10].CM_Move(rightDown_x, rightDown_y);
                            resetEvent.WaitOne();
                            listaElementówDemo[j + 1].CM_Move(rightUp_x, rightUp_y);
                            listaElementówDemo[j + 11].CM_Move(leftDown_x, leftDown_y);
                            resetEvent.WaitOne();
                            leftUp_y = leftUp_y - 2;
                            rightUp_y = rightUp_y + 2;
                            rightDown_y = rightDown_y - 2;
                            leftDown_y = leftDown_y + 2;
                            resetEvent.WaitOne();
                        }
                        while (leftUp_y != (this.Height / 2) - 93);

                        do
                        {
                            listaElementówDemo[j].CM_Move(leftUp_x, leftUp_y);
                            listaElementówDemo[j + 10].CM_Move(rightDown_x, rightDown_y);
                            resetEvent.WaitOne();
                            listaElementówDemo[j + 1].CM_Move(rightUp_x, rightUp_y);
                            listaElementówDemo[j + 11].CM_Move(leftDown_x, leftDown_y);
                            resetEvent.WaitOne();
                            leftUp_x = leftUp_x + 2;
                            rightUp_x = rightUp_x - 2;
                            rightDown_x = rightDown_x + 2;
                            leftDown_x = leftDown_x - 2;
                            resetEvent.WaitOne();
                        }
                        while (leftUp_x != (this.Width / 2) + 100);

                        do
                        {
                            listaElementówDemo[j].CM_Move(leftUp_x, leftUp_y);
                            listaElementówDemo[j + 10].CM_Move(rightDown_x, rightDown_y);
                            resetEvent.WaitOne();
                            listaElementówDemo[j + 1].CM_Move(rightUp_x, rightUp_y);
                            listaElementówDemo[j + 11].CM_Move(leftDown_x, leftDown_y);
                            resetEvent.WaitOne();
                            leftUp_y = leftUp_y + 2;
                            rightUp_y = rightUp_y - 2;
                            rightDown_y = rightDown_y + 2;
                            leftDown_y = leftDown_y - 2;
                            resetEvent.WaitOne();
                        }
                        while (leftUp_y != (this.Height / 2) - 33);

                        Thread.Sleep(50);
                        resetEvent.WaitOne();
                        listaElementówDemo[j].CM_Move(leftUp_x, leftUp_y);
                        listaElementówDemo[j + 10].CM_Move(rightDown_x, rightDown_y);
                        resetEvent.WaitOne();
                        listaElementówDemo[j + 1].CM_Move(rightUp_x, rightUp_y);
                        listaElementówDemo[j + 11].CM_Move(leftDown_x, leftDown_y);
                        resetEvent.WaitOne();
                        Thread.Sleep(500);
                        resetEvent.WaitOne();
                        ClearCenter(plansza);

                        resetEvent.WaitOne();
                        listaElementówDemo[j].CM_Move(xk1, yk1);
                        listaElementówDemo[j + 1].CM_Move(xk2, yk2);

                        listaElementówDemo[j + 10].CM_Move(x1, y1, Convert.ToString(liczbyDoDemo[j + 1]));
                        listaElementówDemo[j + 11].CM_Move(x2, y2, Convert.ToString(liczbyDoDemo[j]));

                        int przechowajWartość = liczbyDoDemo[j];
                        liczbyDoDemo[j] = liczbyDoDemo[j + 1];
                        liczbyDoDemo[j + 1] = przechowajWartość;
                        posortowana = false;
                        resetEvent.WaitOne();
                        Thread.Sleep(300);
                        resetEvent.WaitOne();
                    }
                }
                if (posortowana)
                {
                    koniec = true;
                    Posortowana(plansza);
                    Invoke(new Action(() =>
                    {
                        btDemoStatus.Text = "Click to EXIT";
                    }));
                    StopPosortowana(plansza);
                    resetEvent.WaitOne();
                }
            }
        }

        private void BtDemoStatus_Click(object sender, EventArgs e)
        {
            if (koniec)
                Stop();
            else
                DemoControll();
        }

        private void PbDemo_Click(object sender, EventArgs e)
        {
            DemoControll();
        }


        private void DemoControll()
        {
            if (koniec)
            {
                Stop();
            }
            else
            {
                if (bubbleDemoStatus == false)
                {
                    if (demoThread == null)
                    {
                        bubbleDemoStatus = true;
                        btDemoStatus.Text = "Click to pause DEMO";
                        demoThread = new Thread(StartDemo);
                        demoThread.Start();
                    }
                    else
                    {
                        bubbleDemoStatus = true;
                        Invoke(new Action(() =>
                        {
                            btDemoStatus.Text = "Click to pause DEMO";
                        }));
                        Resume();
                    }

                }
                else
                if (bubbleDemoStatus == true)
                {
                    if (demoThread == null)
                    {
                        return;
                    }

                    bubbleDemoStatus = false;
                    Invoke(new Action(() =>
                    {
                        btDemoStatus.Text = "Click to resume DEMO";
                    }));
                    Pause();
                }
            }
        }

        private void StopProcess()
        {
            if (demoThread == null)
            {
                return;
            }

            Stop();
        }

        private void BubbleSortDemo_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopProcess();
        }

        public void Pause()
        {
            // unset the reset event which will cause the loop to pause
            this.resetEvent.Reset();
        }

        public void Resume()
        {
            // set the reset event which will cause the loop to continue
            this.resetEvent.Set();
        }

        public void Stop()
        {
            // set a flag that will abort the loop
            this.bubbleDemoStatus = false;

            // set the event incase we are currently paused
            this.resetEvent.Set();

            // wait for the thread to finish
            this.demoThread.Abort();

            Dispose();

            Analizator.demoStatus = false;
            Analizator.demoThread.Join();
        }

        public void StopPosortowana(Graphics plansza)
        {
            // set a flag that will abort the loop
            this.bubbleDemoStatus = false;

            // set the event incase we are currently paused
            this.resetEvent.Set();

            // wait for the thread to finish
            this.demoThread.Join();
        }
    }
}
