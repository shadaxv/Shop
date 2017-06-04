using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Owoce : Produkt
    {
        public Owoce(string nazwa, string spozycDo, double waga, string skad) : base(nazwa, spozycDo, waga, skad)
        {

        }

        public override void PokazNazwe()
        {
            Console.WriteLine("----------------------------{0}Owoc: {1}{0}", Environment.NewLine, Nazwa);
        }

        public override void PokazDate()
        {
            Console.WriteLine("Należy spożyć do: {1}{0}", Environment.NewLine, SpozycDo);
        }

        public override void PokazWage()
        {
            Console.WriteLine("Waga: {1}g{0}", Environment.NewLine, Waga);
        }

        public override void PokazSkad()
        {
            Console.WriteLine("Pochodzenie: {1}{0}----------------------------{0}", Environment.NewLine, Skad);
        }

        public static void WprowadzProdukt()
        {
            string nazwa = "";
            string spozycDo = "";
            double waga = 0.0;
            string wagaString = "";
            string skad = "";

            Console.Write("{0}Podaj nazwę owocu: ", Environment.NewLine);
            nazwa = Console.ReadLine();

            Console.Write("{0}Podaj datę ważności: ", Environment.NewLine);
            spozycDo = Console.ReadLine();

            Console.Write("{0}Podaj wagę produktu: ", Environment.NewLine);
            wagaString = Console.ReadLine();
            if (!Double.TryParse(wagaString, out waga))
            {
                string wagaString2 = wagaString.Replace(".", ",");
                if (!Double.TryParse(wagaString2, out waga))
                {
                    Console.WriteLine("{0}The wrong number was given. Changed weight to 0.0{0}", Environment.NewLine);
                    waga = 0.0;
                }
            }

            Console.Write("{0}Podaj pochodzenie produktu: ", Environment.NewLine);
            skad = Console.ReadLine();

            Owoce NowyProdukt = new Owoce(nazwa, spozycDo, waga, skad);
            Program.Add(NowyProdukt);
            Console.WriteLine("{0}{0}Pomyślnie dodano nowy produkt!{0}", Environment.NewLine);
        }
    }
}
