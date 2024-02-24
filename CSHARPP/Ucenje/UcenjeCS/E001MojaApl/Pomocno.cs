﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS.E001MojaApl
{
    internal class Pomocno
    {
        public static int UcitajInt(string poruka)
        {

            for (; ; )

            {
                Console.Write(poruka);
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Neispravan unos");
                }
            }
        }
        public static string UcitajString (string poruka)
        {
            string s;
        while (true)
            {
                Console.Write(poruka);
                s=Console.ReadLine();
                if (s.Trim().Length == 0 ) //ako ništa ne unesemo
                {
                    Console.WriteLine("Obavezan unos");
                    continue;
                }return s;
            }
        }
    }
}
