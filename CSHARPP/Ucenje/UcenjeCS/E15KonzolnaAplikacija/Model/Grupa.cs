using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Grupa:Entitet
    {
        public string Naziv { get; set; }
        public string Smjer { get; set; }
        public DateOnly DatumPocetka { get; set; }
        public List <Polaznik> Polaznici { get; set; }


    }
}
