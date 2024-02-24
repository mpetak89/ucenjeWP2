//using System;
//using System.Collections.Generic;
//using System.Diagnostics.CodeAnalysis;
//using System.Diagnostics.Metrics;
//using System.Linq;
//using System.Runtime.Intrinsics.Arm;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;
//using static System.Runtime.InteropServices.JavaScript.JSType;

//namespace UcenjeCS
//{
//    internal class LjubavniKalkulator
//    {

//        public static void Izvedi()
//        {
//            Console.WriteLine("************Ljubavni kalkulator*************");

//            Console.Write("Unesite prvo ime: ");
//            string Ime1 = Console.ReadLine();

//            Console.Write("Unesite prvo drugo: ");
//            string Ime2 = Console.ReadLine();


//            string KonacniRezultat = string.Join(" ", VratiNiz(PocetniNiz(Ime1, Ime2))); // Dobivanje konacnog rezultata kao string

//            //Ispis programa
//            Console.WriteLine($"{Ime1} i {Ime2} vole se:  {KonacniRezultat} %");
//        }



//        public static int[] Niz(string Ime1, string Ime2)
//        {
//            string ZajednoImena = Ime1 + Ime2;
//            int[] Analiza = new int[ZajednoImena.Length];
//            int i = 0;


//            // Sada cemo prebrojati koliko se puta koje slovo pojavljuje u nizu koji se sastoji od prvog i  drugog imena

//            foreach (char c in ZajednoImena)
//            {
//                int Brojac = 0;

//                foreach (char cc in ZajednoImena) //zašto tu ide cc? zašto ne c?
//                {
//                    if (c == cc) // Ako se isti znak vec pojavljuje
//                    {
//                        Brojac++;
//                    }
//                }
//                Analiza[i++] = Brojac; // što ovo znači ako se c ne ponavlja, onda se Niz za analizu povećava za jedan, a što znači da je = brojač?
//            }

//            foreach (int a in Analiza)
//            {
//                Console.Write(i);
//            }
//            Console.WriteLine();

//            return Analiza;

//        }
//    }
//    }



