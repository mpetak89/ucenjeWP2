using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UcenjeCS
{
    internal class E10ObradaIznimki
    {
        public static void Izvedi()
        {
            int pb = UcitajBroj("Unesi prvi broj: ");
            int db = UcitajBroj("Daj mi i drugi broj: ");

            IspisiBrojeve(pb, db);


        }

        private static void IspisiBrojeve(int pb, int db)
        {

            var Manji = pb <= db ? pb : db;
            var Veci = pb >= db ? pb : db;

            for (int i = Manji; i <= Veci; i++)
            {
                Console.WriteLine(i);
            }



        }

        private static int UcitajBroj(string v)
        {
            int pokusaj = 0;
            for (; ; )
            {
                Console.Write(v);

                try
                {
                    return int.Parse(Console.ReadLine());

                }
                catch (FormatException f)
                {

                    Console.WriteLine("Nisi unio broj" + " " + f.Message);
                    pokusaj++;
                    if (pokusaj == 3)
                    {
                        Console.WriteLine("BROJ GLUPANE");
                    }

                }
                catch (OverflowException)
                {
                    Console.WriteLine("Abandon ship!!!!!!!");

                }
                catch (Exception)
                { //ovdje hvatam bilo koju iznimku koja nije prethodno definirana  

                    Console.WriteLine("Mama rodila morona, ŠČ!!!!");

                }
                finally
                {
                    Console.WriteLine("Mojesto na koje se dolazi pukao ti ili ne!");
                }

            }
            return 0;

        }



    }
}