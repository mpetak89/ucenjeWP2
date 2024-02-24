using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class Z02Vjezba
    {
          //program učitava sve brojeve dok se ne unese broj -1
        //1. zbroj unesenih brojeva
        //2. najmanji broj
        //3. najveći broj
        //4. prosjek svih unesenih brojeva

        // KORISTITI METODE I OBRADU IZNIMKI
        public static void Izvedi()
        {
            int pb = ucitajbroj("unesi ");
            ispisibrojeve(pb);
           
        }

        private static void ispisibrojeve(int pb)
        {
  
            {
                if (pb ==-1)
                {
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine(pb + pb);
                }
            }
        }

        private static int ucitajbroj(string v)
        {
            Console.Write(v);

            for (; ; )
            {
                try
                {
                return int.Parse(Console.ReadLine());
                }
                catch (FormatException f)
                {
                    Console.WriteLine("nisi unio broj");
                }
                continue;
            }
        }
    }
}

     //        private static void ispisibroj(int broj, int drbroj)
//        {
//            int razlicit = broj = 1; broj : drbroj;
//        }

