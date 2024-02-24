using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

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
                    IzbornikRadSKreditima();
                    break;
                case 2:
                    Console.WriteLine("Dodaj kredit");
                    Console.WriteLine();
                    DodajKredit();
                    break;
                case 3:
                    Console.WriteLine("Uredi kredit");
                    Console.WriteLine();
                    UrediKredit();
                    break;
                case 4:
                    Console.WriteLine("Obriši kredit");
                    Console.WriteLine();
                    break;
                case 5:
                    Izbornik();
                    break;
                default:
                    Console.WriteLine("Pogrešan odabir");
                    Console.WriteLine();
                    IzbornikRadSKreditima();
                    break;
            }
            
        }

        private void UrediKredit()
        {
            PrikaziKredite();
            var s = Krediti[Pomocno.UcitajInt("Odaberite kredit za izmjenu: ")];
        }

        private void PrikaziKredite()
        {
            var i = 1;
            Krediti.ForEach (s=> {Console.WriteLine(i++ + " . " + s);});
            IzbornikRadSKreditima();
        }

        private void DodajKredit()
        {
            Krediti.Add(new Model.Kredit()
            {
                SifraKredita = Pomocno.UcitajInt("Unesi šifru kredita: "),
                VrstaKredita = Pomocno.UcitajString("Unesi vrstu kredita: "),
                NazivKredita = Pomocno.UcitajString("Unesi naziv kredita: "),
              
            });
            Console.WriteLine();
            IzbornikRadSKreditima();
        }
    }
}
