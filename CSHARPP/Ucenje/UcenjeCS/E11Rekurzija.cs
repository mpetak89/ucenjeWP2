using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E11Rekurzija
    {
        public static void Izvedi()
        {
            // rekurzija je kada metoda zove samu sebe
            // Izvedi();  // Dobijemo Stackoverflow iznimku

            Console.WriteLine(Zbroj(100));

        }

        private static int Zbroj(int v)
        {
            // uvjet prekida rekurzije
            if (v == 1)
            {
                return 1;
            }

            return v + Zbroj(v - 1);
        }
    }
}