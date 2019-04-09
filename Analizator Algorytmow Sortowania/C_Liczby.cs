using System.Drawing;

namespace Analizator_Algorytmow_Sortowania
{
    class C_Liczby : CM_ElementyDemo
    {
        // deklaracka konstruktora klasy C_Liczby z odwolaniem do 6 elementowego konstruktora w klasie nadrzędnej
        public C_Liczby(int pozX_C, int pozY_C, string napis_C, Graphics planszaGraficzna, Font czcionka_C, Color kolor_C, int promien_C)
            : base(pozX_C, pozY_C, napis_C, planszaGraficzna, czcionka_C, kolor_C, promien_C)
        {
            BubbleSortDemo.bubbleSortDemo = planszaGraficzna;
        }

        // metoda rysujaca obiekt nadpisująca metodę rysuj w klasie nadrzdej
        public override void CM_Draw()
        {
            SolidBrush pedzel = new SolidBrush(Color.Black);
            BubbleSortDemo.bubbleSortDemo.DrawString(napisCM, czcionkaCM, pedzel, pozycjaX - 11, pozycjaY - 9);
            pedzel.Dispose();
        }

        // metoda wymazująca obiekt nadpisująca metodę z klasy nadrzędnej
        public override void CM_Erase()
        {

        }
    }
}
