using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using UcenjeCS.E15KonzolnaAplikacija;

namespace UcenjeCS.E001MojaApl
{
    internal class Program
    {
        private List<Model.Kredit> Krediti;
        public Program() 
        {
            Krediti = new List<Model.Kredit>();
            PozdravnaPoruka();
            Izbornik();
        }   

        private void Izbornik()
        {
            Console.WriteLine("Izbornik: ");
            Console.WriteLine("1.Krediti");
            Console.WriteLine("2.Komitenti");
            Console.WriteLine("3.Posudbe");
            Console.WriteLine("4.Izlaz iz programa");
            Console.WriteLine("*********************************************");
            OdabirStavkeIzbornika();


        }
        private void OdabirStavkeIzbornika()
        {
          
            switch (Pomocno.UcitajInt("Unesi izbor: "))
            {
                case 1:
                    Console.WriteLine("Odabrali ste Kredite");
                    Console.WriteLine();
                    IzbornikRadSKreditima();
                    break;
                case 2:
                    Console.WriteLine("Odabrali ste Komitente");
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Odabrali ste Posudbe");
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Izlaz iz programa");
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Krivi odabir");
                    Console.WriteLine();
                    Izbornik();
                    break;
            }
        }

        private void IzbornikRadSKreditima()
        {
            Console.WriteLine("1.Prikaži kredite");
            Console.WriteLine("2.Dodaj kredit");
            Console.WriteLine("3.Uredi kredit");
            Console.WriteLine("4.Obriši kredit");
            Console.WriteLine("5.Povratak na glavni izbornik");
            Console.WriteLine();
            OdabirStavkeIzbornikaKredit();

        }   

        private void PozdravnaPoruka()
        {
        Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("***********************************");
            Console.WriteLine("Dobrodošli u aplikaciju Banka");
            Console.WriteLine("***********************************");
        }
        private void OdabirStavkeIzbornikaKredit()
        {
            switch (Pomocno.UcitajInt("Odaberite stavku izbornika: "))
            {
                case 1:
                    Console.WriteLine("Prikaži sve kredite");
                    Console.WriteLine();
                    PrikaziKredite();
                    Console.WriteLine();
                    IzbornikRadSKreditima();
                    Console.WriteLine();
                    break;
                case 2:
                    Console.WriteLine("Dodaj kredit");
                    Console.WriteLine();
                    DodajKredit();
                    Console.WriteLine();
                    break;
                case 3:
                    Console.WriteLine("Uredi kredit");
                    Console.WriteLine();
                    UrediKredit();
                    Console.WriteLine();
                    break;
                case 4:
                    Console.WriteLine("Obriši kredit");
                    Console.WriteLine();
                    ObrisiKredit();
                    Console.WriteLine();
                    break;
                case 5:
                    Izbornik();
                    break;
                default:
                    Console.WriteLine("Pogrešan odabir");
                    Console.WriteLine();
                    IzbornikRadSKreditima();
                    Console.WriteLine();
                    break;
            }
            
        }

        private void ObrisiKredit()
        {
                 
            Krediti.RemoveAt(Pomocno.UcitajInt("Odaberi kredit za brisanje: ") - 1);
            Console.WriteLine("Obrisali ste kredit");
            Console.WriteLine();
            IzbornikRadSKreditima(); 
            OdabirStavkeIzbornikaKredit();
        }

        private void UrediKredit()
        {
            var s = Krediti[Pomocno.UcitajInt("Odaberite kredit za promjenu: ")-1];
            s.SifraKredita = Pomocno.UcitajInt("Stara šifra: " + s.SifraKredita + "; Unesite novu šifru kredita: ");
            s.NazivKredita = Pomocno.UcitajString("Stari naziv: " + s.NazivKredita + "; Unesite novi naziv kredita: ");
            Console.WriteLine();
            PrikaziKredite();
        }

        private void PrikaziKredite()
        {
            var i = 0;
            Krediti.ForEach (s=> {Console.WriteLine(++i + ". " + s);});
            Console.WriteLine();
            IzbornikRadSKreditima();
        }

        private void DodajKredit()
        {
            Krediti.Add(new Model.Kredit()
            {
                SifraKredita = Pomocno.UcitajInt("Unesi šifru kredita: "),
                NazivKredita = Pomocno.UcitajString("Unesi naziv kredita: "),
              
            });
            Console.WriteLine();
            IzbornikRadSKreditima();
        }
    }
}
