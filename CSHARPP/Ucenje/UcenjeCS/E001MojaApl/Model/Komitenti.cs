using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E001MojaApl.Model
{
    internal class Komitenti:Posudba   
    {
        public int SifraKomitenta {  get; set; }

        public string OIB { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Adresa { get; set; }

        public DateOnly DatumRodenja { get; set; }

    }
}
