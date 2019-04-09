using System.Drawing;

namespace Analizator_Algorytmow_Sortowania
{
    class CM_ElementyDemo 
    {

        // wywołanie i ustanienie niezbędnych zmiennych wspólnych dla wszystkich klas
        public int pozycjaX;
        public int pozycjaY;
        protected int promienCM;
        protected Color kolorTlaCM;
        protected string napisCM;
        protected Font czcionkaCM;


        


        // przypisanie pobranych wartości do zmiennych dla klas pochodnych 5 elementowych
        public CM_ElementyDemo(int pozX_C, int pozY_C, Graphics planszaGraficzna, Color kolor_C, int promien_C)
        {
            BubbleSortDemo.bubbleSortDemo = planszaGraficzna;
            this.pozycjaX = pozX_C;
            this.pozycjaY = pozY_C;
            this.kolorTlaCM = kolor_C;
            this.promienCM = promien_C;
        }


        // przypisanie pobranych wartości do zmiennych dla klas pochodnych 6 elementowych
        public CM_ElementyDemo(int pozX_C, int pozY_C, string napis_C, Graphics planszaGraficzna, Font czcionka_C, Color kolor_C)
        {
            this.pozycjaX = pozX_C;
            this.pozycjaY = pozY_C;
            this.kolorTlaCM = kolor_C;
            this.napisCM = napis_C;
            this.czcionkaCM = czcionka_C;
            BubbleSortDemo.bubbleSortDemo = planszaGraficzna;
        }


        // przypisanie pobranych wartości do zmiennych dla klas pochodnych 7 elementowych
        public CM_ElementyDemo(int pozX_C, int pozY_C, string napis_C, Graphics planszaGraficzna, Font czcionka_C, Color kolor_C, int promien_C)
        {
            this.pozycjaX = pozX_C;
            this.pozycjaY = pozY_C;
            this.kolorTlaCM = kolor_C;
            this.promienCM = promien_C;
            this.napisCM = napis_C;
            this.czcionkaCM = czcionka_C;
            BubbleSortDemo.bubbleSortDemo = planszaGraficzna;
        }

        // metoda virtualna rysowania obiektu
        public virtual void CM_Draw()
        { }

        // metoda virtualna usuwania wybranego obiektu
        public virtual void CM_Erase()
        { }

        // zmiana parametrów położenia
        public void CM_Radius(int pozX_C, int pozY_C, string napis_C)
        {
            pozycjaX = pozX_C;
            pozycjaY = pozY_C;
            napisCM = napis_C;
        }

        public void CM_Substitute(int pozX_C, int pozY_C)
        {
            pozycjaX = pozX_C;
            pozycjaY = pozY_C;
        }

        // przeniesienie figury
        public void CM_Move(int pozX_C, int pozY_C, string napis_C)
        {
            CM_Erase();
            CM_Radius(pozX_C, pozY_C, napis_C);
            CM_Draw();
        }

        public void CM_Move(int pozX_C, int pozY_C)
        {
            CM_Erase();
            CM_Substitute(pozX_C, pozY_C);
            CM_Draw();
        }
    }
}
