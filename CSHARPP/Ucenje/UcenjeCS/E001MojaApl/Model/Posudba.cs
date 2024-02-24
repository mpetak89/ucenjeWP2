using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E001MojaApl.Model
{
    internal class Posudba:Kredit
    {
        public int SifraPosudbe {  get; set; }

        public DateOnly DatumPodizanja { get; set; }

        public DateOnly DatumVracanja { get; set; }
        public decimal IznosPosudbe { get; set; }
        public float Kamata { get; set; }
    }
}
