using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E001MojaApl.Model
{
    internal class Kredit
    {
        public int SifraKredita { get; set; }
        public string NazivKredita { get; set; }
        public string VrstaKredita { get; set; }
        public override string ToString()
        {
            return NazivKredita; 

        }
    }
}
    
