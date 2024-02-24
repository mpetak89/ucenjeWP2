using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E13Nasljedivanje
{
    internal abstract class OsobaImpl:Polaznik
    {
        public int Sifra { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string oib { get; set; }

        public string email { get; set; }

        
    }
}

