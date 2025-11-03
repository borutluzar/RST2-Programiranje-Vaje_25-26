using MyLibrary;
using System.Diagnostics.CodeAnalysis;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_04_Naloge
    {
        Naloga331 = 1,
        Naloga332 = 2,
        Naloga344 = 3
    }

    /// <summary>
    /// Rešitve vaj - 23. oktober 2025
    /// </summary>
    public class Vaje_04
    {
        public static void Naloga331()
        {
            ZapiskiPredavanj3 zapiski = new ZapiskiPredavanj3("Programiranje");
            zapiski.seznamPoglavij.Add(new Poglavje("Uvod") { stStrani = 10, reference = new List<string> { "Arh, Awesome book on C#" } });
            zapiski.seznamPoglavij.Add(new Poglavje("Vrednostni in sklicni tipi") { stStrani = 11, reference = new List<string> { "Arh, Awesome book on C#" } });
            zapiski.seznamPoglavij.Add(new Poglavje("Objektni koncepti") { stStrani = 19, reference = new List<string> { "Arh, Awesome book on C#" } });

            Console.WriteLine(zapiski["Objektni koncepti"]);
        }

        public static void Naloga332()
        {
            Indeks student = new Indeks()
            {
                ImeStudenta = "Borut",
                PriimekStudenta = "Lužar",
                VpisnaStevilka = 1007
            };

            student[Predmet.Algoritmi] = 10;
            student[Predmet.Programiranje] = 9;
            student[Predmet.DiskretnaMatematika] = 8;

            Console.WriteLine($"Ocena študenta pri predmetu {nameof(Predmet.DiskretnaMatematika)} je {student[Predmet.DiskretnaMatematika]}");
        }

        public static void Naloga344()
        {
            NadzornaKomisija nk = new NadzornaKomisija();
            nk.seznamClanov.Add("Borut");
            nk.seznamClanov.Add("Marko");
            nk.seznamClanov.Add("Otorinolaringolog");

            Console.WriteLine($"V NadzornaKomisija: {nk.PreveriClana(nk.seznamClanov[2])}");
            Console.WriteLine($"V Komisija: {((Komisija)nk).PreveriClana(nk.seznamClanov[2])}");
        }
    }


    /// <summary>
    /// Naredimo še en razred, podobno kot na 3. vajah,
    /// le da vanj dodamo še indekser.
    /// </summary>
    public class ZapiskiPredavanj3
    {
        public ZapiskiPredavanj3() { }

        public ZapiskiPredavanj3(string pr)
        {
            predmet = pr;
        }

        public ZapiskiPredavanj3(bool imajoResitve, string predmet, List<Poglavje> seznamPoglavij)
        {
            this.imajoResitve = imajoResitve;
            this.predmet = predmet;
            this.seznamPoglavij = seznamPoglavij;
        }

        public Poglavje this[string naslov]
        {
            // Pripravimo samo get
            get
            {
                foreach (var poglavje in seznamPoglavij)
                {
                    if (poglavje.naslov == naslov)
                        return poglavje;
                }
                // Če poglavja z danim naslovom ne najdemo, vrnemo null
                return null;
            }
        }


        public bool imajoResitve;

        public string predmet;

        // Razred Poglavje imamo definiran že v datoteki s 3. vaj
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


    public class Indeks
    {
        public Indeks() { }

        public int VpisnaStevilka { get; set; }

        public string PriimekStudenta { get; set; }
        
        public string ImeStudenta { get; set; }

        private Dictionary<Predmet, int> dicOcene = new Dictionary<Predmet, int>();

        public int this[Predmet predmet]
        {
            get
            {
                if(dicOcene.ContainsKey(predmet))
                    return dicOcene[predmet];
                else
                    return 0;
            }
            set
            {
                // Dopolnite kodo še s preverjanjem, če je bila podana ocena med 5 in 10!

                if (dicOcene.ContainsKey(predmet))
                {
                    dicOcene[predmet] = value;
                }
                else
                {
                    dicOcene.Add(predmet, value);
                }
            }
        }
    }

    public enum Predmet
    {
        Programiranje,
        DiskretnaMatematika,
        Algoritmi
    }


    public class Komisija
    {
        public List<string> seznamClanov = new List<string>();

        public bool PreveriClana(string clan)
        {
            // Naredimo neko dummy logiko
            if(clan.Length > 10)
                return false;
            else
                return true;
        }
    }

    // Razred deduje iz razreda Komisija
    public class NadzornaKomisija : Komisija
    {
        // Metodo z enakim imenom lahko implementiramo,
        // uporabimo določilo new
        new public bool PreveriClana(string clan)
        {
            // Logiko obrnemo
            if (clan.Length > 10)
                return true;
            else
                return false;
        }
    }
}
