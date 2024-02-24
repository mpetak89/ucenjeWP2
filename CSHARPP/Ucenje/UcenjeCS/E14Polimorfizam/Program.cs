using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E14Polimorfizam
{
    internal class Program
    {
        private List<Osoba> Osobe;
        public Program() {
            this.Osobe = new List<Osoba>();
            NapuniListu();
            PozdraviOsobe();
        }
        private void PozdraviOsobe()
        {
            Osobe.ForEach(osoba =>
            {
                Console.WriteLine(osoba.Pozdravi());
            });
        }
        private void NapuniListu()
        {
            Osobe.Add(new Polaznik()
            {
                Ime = "marko",
                Prezime = "Kas"
            }
         );
            Osobe.Add(new Predavac()
            {
                Ime = "Ivana",
                Prezime = "Kas"
            }
);
        }

        public static void Izvedi()
        {
            new Program(); // žeim pristupati klasama a kad je static, to se ne more
        }
    }
}
