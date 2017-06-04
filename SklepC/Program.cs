using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Program
    {
        private List<string> produkty = new List<string>();
        public List<string> Produkty { get => produkty; set => produkty = value; }
        public static List<Produkt> spisProduktow = new List<Produkt>();

        static void Main(string[] args)
        {
            
            Warzywa Warzywo = new Warzywa("Pomidor", "24.02.2017", 125.5, "Polska");
            Warzywa Warzywo2 = new Warzywa("Marchew", "01.05.2017", 57.35, "Azerbejdżan");
            Napoje Sok = new Napoje("Sok pomarańczowy", "03.05.2017", 1.5, "Tymbark");
            spisProduktow.Add(Warzywo);
            spisProduktow.Add(Warzywo2);
            spisProduktow.Add(Sok);
            ShowMenu();

            Console.WriteLine("Aby kontynuować, naciśnij dowolny przycisk...");
            Console.ReadKey();
        }

        public static void Add(Produkt nowy)
        {
            spisProduktow.Add(nowy);
        }

        public static void Show()
        {
            List<Produkt> SpisProduktow = spisProduktow;
            foreach (var produkt in spisProduktow)
            {
                produkt.PokazNazwe();
                produkt.PokazDate();
                produkt.PokazWage();
                produkt.PokazSkad();
            }
        }

        public static void ShowMenu()
        {
            Console.WriteLine("{0}----------------------------{0}{0}Witamy w naszym sklepie{0}{0}Wybierz działanie:{0}", Environment.NewLine);

            List<string> kategorieMenu = new List<string>();
            kategorieMenu.Add("0) Wyjdź ze sklepu");
            kategorieMenu.Add("1) Dodaj produkt");
            kategorieMenu.Add("2) Wyświetl produkty");

            foreach (var kategoria in kategorieMenu)
            {
                Console.WriteLine("│{0}└─ {1}", Environment.NewLine, kategoria);
            }

            Console.WriteLine("{0}----------------------------{0}", Environment.NewLine);

            var readkey = Console.ReadKey(true).Key;
            while (readkey != ConsoleKey.Escape)
            {
                if (readkey == ConsoleKey.Escape || readkey == ConsoleKey.D0 || readkey == ConsoleKey.NumPad0)
                {
                    Console.WriteLine("{0}Zapraszamy ponownie!{0}", Environment.NewLine);
                    break;
                }

                else if (readkey == ConsoleKey.D1 || readkey == ConsoleKey.NumPad1)
                {
                    WybranaKategoria(1);
                    break;
                }

                else if (readkey == ConsoleKey.D2 || readkey == ConsoleKey.NumPad2)
                {
                    WybranaKategoria(2);
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
                Console.WriteLine("{0}Zapraszamy ponownie!{0}", Environment.NewLine);
                return;
            }

        }

        private static void WybranaKategoria(int menuInt)
        {
            switch (menuInt)
            {
                case 1:
                    Produkt.DodajProdukt();
                    break;
                case 2:
                    Produkt.WyswietlProdukty();
                    break;
                default:
                    Console.WriteLine("Coś poszło nie tak, zajrzyj ponownie do menu");
                    ShowMenu();
                    break;
            }
        }

    }
}
