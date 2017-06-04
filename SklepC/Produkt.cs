using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public abstract class Produkt
    {
        public string Nazwa { get; set; }
        public string SpozycDo { get; set; }
        public double Waga { get; set; }
        public string Skad { get; set; }
        public List<string> ListaProduktow { get; set; }
        private static List<string> _produkty = new List<string>();
        public static List<string> Produkty { get => _produkty; set => _produkty = value; }

        protected Produkt(string nazwa, string spozycDo, double waga, string skad)
        {
            Nazwa = nazwa;
            SpozycDo = spozycDo;
            Waga = waga;
            Skad = skad;
        }

        public static void DodajProdukt()
        {
            if(Produkty.Count == 0)
            {
                Produkty = new List<string>();
            }

            Console.WriteLine("{0}Dodaj produkty do asortymentu | ESC przerywa akcję{0}", Environment.NewLine);

            List<string> addMenu = new List<string>();
            addMenu.Add("0) Anuluj dodawanie");
            addMenu.Add("1) Dodaj warzywo");
            addMenu.Add("2) Dodaj napój");
            addMenu.Add("3) Dodaj owoc");

            foreach (var kategoria in addMenu)
            {
                Console.WriteLine("│{0}└─ {1}", Environment.NewLine, kategoria);
            }

            var readkey = Console.ReadKey(true).Key;
            while (readkey != ConsoleKey.Escape)
            {
                if (readkey == ConsoleKey.Escape || readkey == ConsoleKey.D0 || readkey == ConsoleKey.NumPad0)
                {
                    Console.WriteLine("{0}Dodawanie przerwane!{0}", Environment.NewLine);
                    break;
                }

                else if (readkey == ConsoleKey.D1 || readkey == ConsoleKey.NumPad1)
                {
                    Console.WriteLine("{0}Dodaj warzywo:{0}", Environment.NewLine);
                    WybranyRodzaj(1);
                    break;
                }

                else if (readkey == ConsoleKey.D2 || readkey == ConsoleKey.NumPad2)
                {
                    Console.WriteLine("{0}Dodaj napój:{0}", Environment.NewLine);
                    WybranyRodzaj(2);
                    break;
                }

                else if (readkey == ConsoleKey.D3 || readkey == ConsoleKey.NumPad3)
                {
                    Console.WriteLine("{0}Dodaj owoc:{0}", Environment.NewLine);
                    WybranyRodzaj(3);
                    break;
                }

                else
                {
                    Console.WriteLine("{0}Proszę wybrać poprawny numer", Environment.NewLine);
                }
                readkey = Console.ReadKey(true).Key;
            }

            if (readkey == ConsoleKey.Escape)
            {
                Console.WriteLine("{0}Dodawanie przerwane!{0}", Environment.NewLine);
            }

            Program.ShowMenu();
        }

        private static void WybranyRodzaj(int menuInt)
        {
            switch (menuInt)
            {
                case 1:
                    Warzywa.WprowadzProdukt();
                    break;

                case 2:
                    Napoje.WprowadzProdukt();
                    break;
                case 3:
                    Owoce.WprowadzProdukt();
                    break;
            }
        }

        public static void WyswietlProdukty()
        {
            if (Produkty.Count == 0)
            {
                Produkty = new List<string>();
            }

            Console.WriteLine("{0}{0}Nasz asortyment:{0}", Environment.NewLine);

            Program.Show();
            Program.ShowMenu();
        }

        public abstract void PokazNazwe();
        public abstract void PokazDate();
        public abstract void PokazWage();
        public abstract void PokazSkad();
    }
}
