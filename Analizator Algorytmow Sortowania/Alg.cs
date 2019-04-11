using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;

namespace Analizator_Algorytmow_Sortowania
{
    class Alg
    {
        public Alg()
        { }

        public static DataTable firstDataTable;
        public static DataTable secondDataTable;
        public static int LiczbaElementow;
        public static int IloscSymulacji;
        public static int MinimalnaWartosc;
        public static int MaksymalnaWartosc;
        public static int[] TablicaDoPosortowania;
        public static Color ChartBackColor { get; set; }
        public static Color ChartLinecOLOR { get; set; }
        public static int ChartLineWeight { get; set; }
        public static string AlgorytmName { get; set; }
        public static int Algorytm { get; set; }



        // Sortowanie Bąbelkowe
        public static void SortowanieBąbelkowe(int[] tablicaDoPosortowania, out int liczbaOperacji, out double czasSortowaniaTablicy)
        {
            // uruchomienie stopera
            Stopwatch stoper = new Stopwatch();
            stoper.Start();
            liczbaOperacji = 0;

            // początek algorytmu sortowania bąbelkowego
            for (int i = 0; i < tablicaDoPosortowania.Length - 1; i++)
            {
                bool posortowana = true;
                for (int j = 0; j < tablicaDoPosortowania.Length - 1; j++)
                {
                    liczbaOperacji++;

                    if (tablicaDoPosortowania[j] > tablicaDoPosortowania[j + 1])              // jeśli dana liczba jest większa od kolejnej to zamień miejscami
                    {
                        int przechowajWartość = tablicaDoPosortowania[j];
                        tablicaDoPosortowania[j] = tablicaDoPosortowania[j + 1];
                        tablicaDoPosortowania[j + 1] = przechowajWartość;
                        posortowana = false;
                    }
                }
                if (posortowana) break;
            }
            // zatrzymanie stopera
            stoper.Stop();
            czasSortowaniaTablicy = Convert.ToDouble(stoper.Elapsed.TotalMilliseconds);
        }






    }
}
