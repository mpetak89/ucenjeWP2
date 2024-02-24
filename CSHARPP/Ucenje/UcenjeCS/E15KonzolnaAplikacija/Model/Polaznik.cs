using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E15KonzolnaAplikacija.Model
{
    internal class Polaznik:Entitet
    {
        public string Ime {  get; set; }

        public string Prezime { get; set; }

        public string oib { get; set; }

        public string email { get; set; }

        public override string ToString()
        {
            return  Ime + " " + Prezime;
        }
    }
    }
