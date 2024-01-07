using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("V02")]
    public class V02ZimskoVjezbanje : ControllerBase
    {
        [HttpGet]
        [Route("zad1")]
        //Ruta ne prima niti jedan parametar i vraća zbroj prvih 100 brojeva
        public int Zad1()
        {
            int Zbroj = 0;
            for (int i = 1; i <= 100; i++)
            {
                Zbroj += i;
            }

            return Zbroj;
        }


        //Ruta ne prima niti jedan parametar i vraća niz s svim parnim brojevima od 1 do 57
        [HttpGet]
        [Route("zad2")]

        public int[] zad2()
        {
            int[] niz = new int[57 / 2];
            int n = 0;

            for (int i = 1; i < 57; i++)
            {
                if (i % 2 == 0)
                {
                    niz[n++] = i;
                }
            }
            return niz;
        }

        //Ruta ne prima niti jedan parametar i vraća zbroj svih parnih brojeva od 2 do 18
        [HttpGet]
        [Route("Zad3")]

        public int Zad3()
        {
            int suma = 0;
            for (int i = 2; i <= 18; i++)
            {
                if (i % 2 == 0)
                {
                    suma += i;
                }
            }

            return suma;
        }

        //Ruta prima jedan parametar koji je cijli broj i vraća zbroj svih brojava od 1 do primljenog broja

        [HttpGet]
        [Route("Zad4")]

        public int Zad4(int broj)
        {
            int suma = 0;

            for (int i = 0; i <= broj; i++)
            {
                suma += i;
            }
            return suma;
        }
    }
}