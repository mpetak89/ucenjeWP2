//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using UcenjeCS.E15KonzolnaAplikacija.Model;

//namespace UcenjeCS.E15KonzolnaAplikacija
//{
//    internal class Program
//    {
//        private List<Smjer> Smjerovi;
//        public Program()
//        {
//            Smjerovi = new List<Smjer>();
//            PozdravnaPoruka();
//            Izbornik();
//        }
//        private void Izbornik()
//        {
//            Console.WriteLine("Izbornik");
//            Console.WriteLine("1. Rad sa smjerovima");
//            Console.WriteLine("2. Rad s predavačima");
//            Console.WriteLine("3. Rad s polaznicima");
//            Console.WriteLine("4. Rad s grupama");
//            Console.WriteLine("5. Izlaz iz programa");
//            OdabirstavkePocetnogizbornika();
//        }
//        private void OdabirstavkePocetnogizbornika()
//        {
//            //var izbor = Pomocno.ucitajint("unesi izbor: ");
//            switch (Pomocno.ucitajint("unesi izbor: "))
//            {
//                case 1:
//                    Console.WriteLine("odabrali ste rad sa smjerovima");
//                    Izbornikradsasmjerovima();
//                    break;
//                case 2:
//                    Console.WriteLine("odabrali ste rad s predavačima");
//                    Izbornikradaspredavacijma();
//                    break;
//                case 3:
//                    Console.WriteLine("odabrali ste rad s polaznicima");
//                    Izbornikradaspolaznicima();
//                    break;
//                case 4:
//                    Console.WriteLine("odabrali ste rad s grupama");
//                    break;
//                case 5:
//                    Console.WriteLine("Izlaz iz programa");
//                    break;
//                default:
//                    Console.WriteLine("Krivi odabir");
//                    Izbornik();
//                    break;

//                    {

//                    }
//            }
//        }

//        private void Izbornikradaspolaznicima()
//        {
//            throw new NotImplementedException();
//        }

//        private void Izbornikradaspredavacijma()
//        {
//            Console.WriteLine("Izbornik za rad s predavačima");
//            Console.WriteLine("1. Pregled postojećih predavača");
//            Console.WriteLine("2. Unos novog predavača");
//            Console.WriteLine("3. Promjena postojećeg predavača");
//            Console.WriteLine("4. Brisanje predavača");
//            Console.WriteLine("5. Povratak na glavni izbornik");
//            Console.WriteLine("**********************************************+");
//            OdabirStavkeIzbornikaPredavaca();



//        }

//        private void OdabirStavkeIzbornikaPredavaca()
//        {
//           switch (Pomocno.ucitajint("Odaberi stavku izbornika: "))
//            {
//                case 1:
//                    Console.WriteLine("Prikaži sve predavace");
//                    PrikaziSmjerove();
//                    Izbornikradsasmjerovima();
//                    break;
//                case 2:
//                    Console.WriteLine("Dodaj smjer");
//                    DodajNoviSmjer();
//                    break;
//                case 3:
//                    Console.WriteLine("Uredi smjer");
//                    UrediSmjer();
//                    break;
//                case 4:
//                    Console.WriteLine("Izbriši smjer");
//                    IzbrisiSmjer();
//                    break;
//                case 5:
//                    Izbornik();
//                    break;
//                default:
//                    Console.WriteLine("Krivi odabir");
//                    Izbornikradsasmjerovima();
//                    break;
//            }
//        }

//        private void Izbornikradsasmjerovima()
//        {

//            Console.WriteLine("1. Prikaži sve smjerove");
//            Console.WriteLine("2. Dodaj smjer");
//            Console.WriteLine("3. Uredi smjer");
//            Console.WriteLine("4. Izbriši smjer");
//            Console.WriteLine("5. Povratak na glavni izbornik");
//            OdabirStavkeIzbornikSmjera();

//        }

//        private void PozdravnaPoruka()
//        {
//            Console.WriteLine("*********************************");
//            Console.WriteLine("* Edunova konzolna aplikacija v1 *");
//            Console.WriteLine("*********************************");
//        }
//        private void OdabirStavkeIzbornikSmjera()
//        {
//            switch (Pomocno.ucitajint("Odaberi stavku izbornika: "))
//            {
//                case 1:
//                    Console.WriteLine("Prikaži sve smjerove");
//                    PrikaziSmjerove();
//                    Izbornikradsasmjerovima();
//                    break;
//                case 2:
//                    Console.WriteLine("Dodaj smjer");
//                    DodajNoviSmjer();
//                    break;
//                case 3:
//                    Console.WriteLine("Uredi smjer");
//                    UrediSmjer();
//                    break;
//                case 4:
//                    Console.WriteLine("Izbriši smjer");
//                    IzbrisiSmjer();
//                    break;
//                case 5:
//                    Izbornik();
//                    break;
//                default:
//                    Console.WriteLine("Krivi odabir");
//                    Izbornikradsasmjerovima();
//                    break;
//            }
//        }

//        private void IzbrisiSmjer()
//        {
//            PrikaziSmjerove();
//            Smjerovi.RemoveAt(Pomocno.ucitajint("Odaberi smjer za brisanje: ")-1);
//            Izbornikradsasmjerovima();
//        }

//        private void UrediSmjer()
//        {
//            PrikaziSmjerove();
//            var s = Smjerovi[Pomocno.ucitajint("Odaberi smjer za promjenu")-1];
//            s.Sifra = Pomocno.ucitajint(s.Sifra + ", Unesi promjenjenu šifru: ");
//            s.Naziv = Pomocno.ucitajstring(s.Naziv + ", Unesi promjenjenni naziv: ");
//            //promijeniti ostale vrijednosti
//            Izbornikradsasmjerovima();
//        }

//        private void PrikaziSmjerove()
//        {
//            var i = 0; //kreni od nule i svaki smjer uvećaj za jedan
//            Smjerovi.ForEach(s => { Console.WriteLine((++i) + "." + s) ; });
//             ;
//            Console.WriteLine("*****************************************");
//        }

//        private void DodajNoviSmjer()
//        {
//            Smjerovi.Add(new Smjer()
//            {
//                Sifra = Pomocno.ucitajint("unesi šifru smjera: "),
//                Naziv = Pomocno.ucitajstring ("unesi naziv smjera: "),
//                //ucitati ostale vrijednosti
//            });
//            Izbornikradsasmjerovima(); 
//        }
//    }

//}
