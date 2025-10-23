using MyLibrary;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_03_Naloge
    {
        Naloga311 = 1,
        Naloga312 = 2,
        Naloga313 = 3,
        Naloga321 = 5,
        Naloga322 = 6,
        Naloga323 = 7

    }

    /// <summary>
    /// Rešitve vaj - 13. oktober 2025
    /// </summary>
    public class Vaje_03
    {
        public static void Naloga311_312()
        {
            ZapiskiPredavanj zapiskiProg = new ZapiskiPredavanj();
            ZapiskiPredavanj zapiskiDM = new ZapiskiPredavanj("diskretna matematika");
            ZapiskiPredavanj zapiskiSUV = new ZapiskiPredavanj(false, "SUV", new List<string>() { "Angular", "HTML" });

            zapiskiProg.predmet = "Programiranje";

            zapiskiProg.seznamPoglavij = new List<string> { "Uvod", "Objekti", "Link" };
            zapiskiDM.seznamPoglavij.Add("Prestevanja");
            zapiskiDM.seznamPoglavij.Add("Razbitja");

            zapiskiProg.IzpisPoglavij();
            zapiskiDM.IzpisPoglavij();
            zapiskiSUV.IzpisPoglavij();
        }

        public static void Naloga313()
        {
            ZapiskiPredavanj2 zapiskiAlg = new ZapiskiPredavanj2("algoritmi");

            Poglavje pog1 = new Poglavje("Deli in vladaj");
            pog1.stStrani = 8;
            pog1.reference.Add("Erickson");
            zapiskiAlg.seznamPoglavij.Add(pog1);

            zapiskiAlg.IzpisPoglavij();
        }

        public static void Naloga321_323()
        {
            Avto mojAvto = new Avto();
            mojAvto.VnesiPodatke();
            Console.WriteLine($"Moj avto je: {mojAvto.ToString()}");
        }
    }

    public class ZapiskiPredavanj
    {
        // Prazen konstruktor
        public ZapiskiPredavanj() { }

        // Konstruktor z enim parametrom
        public ZapiskiPredavanj(string pr)
        {
            predmet = pr;
        }

        // Konstruktor s tremi parametri
        public ZapiskiPredavanj(bool imajoResitve, string predmet, List<string> seznamPoglavij)
        {
            this.imajoResitve = imajoResitve;
            this.predmet = predmet;
            this.seznamPoglavij = seznamPoglavij;
        }

        // Polja
        public bool imajoResitve;

        public string predmet;

        public List<string> seznamPoglavij = new List<string>();

        // Funkcija za izpis poglavij
        public void IzpisPoglavij()
        {
            Console.WriteLine($"Predmet: {predmet}");

            foreach (string poglavje in seznamPoglavij)
            {
                Console.WriteLine($"Poglavje: {poglavje}");
            }
            Console.WriteLine();
        }
    }

    public class Poglavje
    {
        public Poglavje(string naslov)
        {
            this.naslov = naslov;
        }

        public string naslov;

        public int stStrani;

        public List<string> reference = new List<string>();

        public override string ToString()
        {
            string izpis = $"Naslov poglavja je: {naslov}, \n število strani {stStrani}, \n reference so: ";

            foreach (string refe in reference) { izpis += $"{refe}, "; }

            return izpis;
        }
    }

    /// <summary>
    /// Drug razred, ki uporablja razred Poglavja namesto string
    /// </summary>
    public class ZapiskiPredavanj2
    {
        public ZapiskiPredavanj2() { }

        public ZapiskiPredavanj2(string pr)
        {
            predmet = pr;
        }

        public ZapiskiPredavanj2(bool imajoResitve, string predmet, List<Poglavje> seznamPoglavij)
        {
            this.imajoResitve = imajoResitve;
            this.predmet = predmet;
            this.seznamPoglavij = seznamPoglavij;
        }

        public bool imajoResitve;

        public string predmet;

        public List<Poglavje> seznamPoglavij = new List<Poglavje>();

        public void IzpisPoglavij()
        {
            Console.WriteLine($"Predmet: {predmet}");

            foreach (Poglavje poglavje in seznamPoglavij)
            {
                Console.WriteLine($"Poglavje: {poglavje.ToString()}");
            }
            Console.WriteLine();
        }
    }

    public class PrometnaIzkaznica
    {
        public string StSasije { get; set; }
        public DateTime DatumVeljavnosti { get; set; }
        public int Kilovati { get; set; }

        public void VnesiPodatke()
        {
            Console.WriteLine("Vnesi številko šasije: ");
            this.StSasije = Console.ReadLine();
            Console.WriteLine("Vnesi datum veljavnosti: ");
            this.DatumVeljavnosti = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Vnesi kilovate: ");
            this.Kilovati = int.Parse(Console.ReadLine());
        }

        public override string ToString()
        {
            string izpis = $"Stevilka sasije: {StSasije}, \nDatum veljavnosti registracije: {DatumVeljavnosti}, \nKilovati: {Kilovati}";
            return izpis;
        }
    }

    public class Avto
    {
        public Avto()
        {
            znamka = "Renault";
            koncHitrost = 310;
            Barva = "Bela";
            StSedezev = 5;
            RezKolo = false;
            PrometnaIzkaznica = new PrometnaIzkaznica()
            { 
                StSasije = "000DDAEAE123", 
                DatumVeljavnosti = DateTime.Now, 
                Kilovati = 100 
            };
        }

        public PrometnaIzkaznica PrometnaIzkaznica { get; set; }

        public void VnesiPodatke()
        {
            Console.WriteLine("Vnesi znamko: ");
            this.Znamka = Console.ReadLine();
            Console.WriteLine("Končna hitrost: ");
            this.KoncHitrost = int.Parse(Console.ReadLine());
            Console.WriteLine("Barva: ");
            this.Barva = Console.ReadLine();
            Console.WriteLine("St sedežev: ");
            this.StSedezev = int.Parse(Console.ReadLine());
            //Console.WriteLine("Rezerno kolo (0 = ne, 1 = da): ");
            //this.RezKolo = Console.ReadLine() == "1" ? true : false; 
            this.PrometnaIzkaznica.VnesiPodatke();
        }

        public override string ToString()
        {
            string izpis = $"Znamka: {znamka}, \nKončna hitrost: {KoncHitrost}, \nBarva: {Barva}, " +
                $"\nStevilo sedezev: {StSedezev}, \nRezervno kolo: {RezKolo} " +
                $"\nPodatki prometne izkaznice: {PrometnaIzkaznica.ToString()}";
            return izpis;
        }

        private string znamka;

        public string Znamka
        {
            get
            {
                return znamka;
            }

            set
            {
                znamka = value;
                znamka = char.ToUpper(znamka[0]) + znamka.Substring(1);
            }
        }

        private int koncHitrost;

        public int maxSpeed = 220;

        public int KoncHitrost
        {
            get
            {
                return koncHitrost;
            }

            set
            {
                koncHitrost = Math.Min(value, maxSpeed);
            }
        }

        public string Barva { get; set; }

        public int StSedezev { get; set; }

        public bool RezKolo { get; }
    }
}
