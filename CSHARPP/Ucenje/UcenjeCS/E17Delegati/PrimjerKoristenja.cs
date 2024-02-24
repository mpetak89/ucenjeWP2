using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E17Delegati
{
    internal class PrimjerKoristenja
    {
        public PrimjerKoristenja() 
        
        {
            var os = new ObradaSmjer();
            os.IspisSmjer(MojIspisUOvojKlasi);
         }
        private void MojIspisUOvojKlasi (Smjer s)
        {
            Console.WriteLine("1"+s.Naziv);
        }
    }
}
