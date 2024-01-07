namespace UcenjeCS
{
    internal class V01ZimskoVjezbanje
    {
        public static void Izvedi()
        {
            Console.WriteLine("Napisati program koji ispisuje sve brojeve od 1 do 100");

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i + 1);
            }
            Console.WriteLine("Napisati program koji ispisuje sve brojeve od 100 do 1");

            for (int i = 101; i > 1; i--)
            {
                Console.WriteLine(i - 1);
            }
            Console.WriteLine("Napisati program koji ispisuje sve brojeve od 1 do 100 koji su cjelobrojno djeljivi s 7");

            for (int i = 7; i < 100; i += 7)

                Console.WriteLine(i);
        
            Console.WriteLine("4. Napisati program koji unosi brojeve sve dok ne unese broj veći od 100, a zatim ispisuje koliko je bilo pokušaja unosa\r\n");

            int BrojUnosa = 0;
            for (; ;)
            {
                Console.WriteLine("Unesite broj veci od 100: ");
                int UneseniBroj = int.Parse(Console.ReadLine());
                if (UneseniBroj <= 100)
                {
                    BrojUnosa++;
                }
                else
                {
                    Console.WriteLine($"Unijeli ste broj manji od 100 {BrojUnosa} puta.");
                   
                }
                break;
            }
        }
    }
}