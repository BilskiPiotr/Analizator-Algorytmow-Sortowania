using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analizator_Algorytmow_Sortowania
{
    class C_Kola : CM_ElementyDemo
    {
        // deklaracka konstruktora klasy Koło z odwolaniem do 5 elementowego konstruktora w klasie nadrzędnej
        public C_Kola(int pozX_C, int pozY_C, Graphics planszaGraficzna, Color kolor_C, int promien_C)
            : base(pozX_C, pozY_C, planszaGraficzna, kolor_C, promien_C)
        {
            BubbleSortDemo.bubbleSortDemo = planszaGraficzna;
        }

        // metoda rysujaca obiekt nadpisująca metodę rysuj w klasie nadrzdej
        public override void CM_Draw()
        {
            SolidBrush pedzel_C = new SolidBrush(BubbleSortDemo.kolorObiektu);
            BubbleSortDemo.bubbleSortDemo.FillEllipse(pedzel_C, pozycjaX - promienCM, pozycjaY - promienCM, promienCM * 2, promienCM * 2);
            pedzel_C.Dispose();
        }

        // metoda wymazująca obiekt nadpisująca metodę z klasy nadrzędnej
        public override void CM_Erase()
        {
            SolidBrush pedzel_C = new SolidBrush(BubbleSortDemo.bubblesortDemoPanel.BackColor);
            BubbleSortDemo.bubbleSortDemo.FillEllipse(pedzel_C, pozycjaX - (promienCM + 1), pozycjaY - (promienCM + 1), 2 * (promienCM + 2), 2 * (promienCM + 2));
            pedzel_C.Dispose();
        }
    }
}
