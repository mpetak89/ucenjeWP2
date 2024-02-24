using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal class Program
    {
        public static void Izvedi()
        {
        var p = new Polaznik()
        {
            Sifra = 1,
            Ime = "Pero",
            Prezime = "Perić"
        };
            var pr1 = new Predavac();
            pr1.Ime = "Mario";
            
            var pr2 = new Predavac();
            pr2.Ime = "Mario";

            Console.WriteLine((pr1==pr2) + "," + pr1.GetHashCode()
                + "==" + pr2.GetHashCode());

            var e = new Entitet();
            e.Sifra = 2;

            string a = "osijek";
            Console.WriteLine(a.GetHashCode());
            a += " je super ";
            Console.WriteLine(a.GetHashCode());
        }

    }
}
