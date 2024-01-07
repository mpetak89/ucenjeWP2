
namespace UcenjeCS
{
    internal class E03UvijetnaGrananja
    {
        public static void Izvedi()
        {
            int i = 7;

            bool uvjet = i == 7;

            if (uvjet)
            {
                Console.WriteLine("ušao sam u true dio if naredbe");
            }
            if (i == 7)
            {
                Console.WriteLine("isti uvjet kao i prethodno");
            }

            if (i < 5)
            {
                Console.WriteLine("i manje od 5");
            }
            else
            {
                Console.WriteLine("i nije manje od 5");
            }

            if (i == 2)
            {
                Console.WriteLine("i je 2");
            }
            else if (i == 3)
            {
                Console.WriteLine(3);
            }
            else
            {
                Console.WriteLine("i nije ni 2 ni 3");
            }
            int j = 2;
            if (i == 7)
            {
                if (j == 2)
                {
                    Console.WriteLine("oba su zadovoljena");
                }
            }

            if (i == 7 & j == 2)
            {
                Console.WriteLine("oba su zadovoljena");
            }
            if (i == 7 && j == 2)
            {
                Console.WriteLine("obas su");
            }

            if (i == 5 | j == 1)
                Console.WriteLine("docoljno da je jedan od uvjeta zadovoljen");
            if (i == 5 || j == 1)
            {
                Console.WriteLine("prvi je zadovoljen, drugi ses ne provjerava");
            }

            if ((i == 4 || j == 1) && !(i > 5 || j < 8))
            {
                Console.WriteLine("komplicirani izraz");
            }



            Console.Write("unesi cijeli broj: ");
            int broj = int.Parse(Console.ReadLine());

            if (broj > 10)
            {
                Console.WriteLine("osijek");
            }
            else
            {
                Console.WriteLine("zagreb");

            }
            Console.WriteLine(i > 10 ? "osijek" : "zagreb");

            int ocjena = 4;

            switch (ocjena)
            {
                case 1:
                    Console.WriteLine("nedovoljan");
                    break;
                case 2:
                case 3:
                    Console.WriteLine("dovoljno ili dobro");
                    break;
                case 4:
                case 5:
                    Console.WriteLine("to je ocjena");
                    break;
                default:
                    Console.WriteLine("nije ocjena");
                    break;
            }
            string ime = "pero";
            switch (ime)
            {
                case "marko":
                    Console.WriteLine("ok");
                    break;
                case "pero":
                    Console.WriteLine("super");
                    break;
            }
        }
    }
}