namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_12_Naloge
    {
        Naloga721 = 1,
        Naloga723 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 5. januar 2025
    /// </summary>
    public class Vaje_12
    {
        /// <summary>
        /// Vrsta in sklad ne implementirata metode Add.  
        /// Napišite razširitveni metodi zanju.
        /// </summary>
        public static void Naloga721()
        {
            Queue<string> q = new Queue<string>();
            q.Add("PRVI EL VRSTE");
            q.Add("DRUGI EL VRSTE");
            q.Add("TRETJI EL VRSTE");

            foreach (var elt in q)
            {
                Console.WriteLine(elt);
            }
            //stack
            Stack<string> s = new Stack<string>();
            s.Add("PRVI EL SKLAD");
            s.Add("DRUGI EL SKLAD");
            s.Add("TRETJI EL SKLAD");

            foreach (var elt in s)
            {
                Console.WriteLine(elt);
            }
        }

        /// <summary>
        /// V mapi Vaje_12_Podatki imate datoteko s seznamom pošt in poštnih številk. 
        /// Pripravite podobno igro kot v prejšnji nalogi, 
        /// kjer mora uporabnik glede na ime pošte ugotoviti njeno poštno številko.
        /// Katera podatkovna struktura bo najbolj primerna za implementacijo?
        /// </summary>
        public static void Naloga723()
        {
            Dictionary<string, string> poste = new Dictionary<string, string>();
            StreamReader sw = new StreamReader(@"resources/Vaje_12_Podatki/postnestevilke.txt");

            while (!sw.EndOfStream)
            {
                string stevilkaIme = sw.ReadLine();

                int index = stevilkaIme.IndexOf(' ');

                string postnaStevilka = stevilkaIme.Substring(0, index);

                string imePoste = stevilkaIme.Substring(index);

                poste.Add(postnaStevilka, imePoste);
            }

            sw.Close();

            Random rnd = new Random();
            int izbira = rnd.Next(0, poste.Count);
            string izbranaPostnaStevilka = poste.Keys.ToList()[izbira];
            Console.WriteLine($"Katera posta ima postno stevilko {izbranaPostnaStevilka} ");

            string odgovor = Console.ReadLine();

            if (odgovor.ToLower() == poste[izbranaPostnaStevilka].ToLower())
            {
                Console.WriteLine("Odgovor je pravilen");
            }
            else
            {
                Console.WriteLine("Odgovor je napačen! Pravilen odgovor je: " + poste[izbranaPostnaStevilka]);
            }
        }
    }

    public static class ExtensionsFunctions
    {
        public static void Add<T>(this Queue<T> q, T elt)
        {
            q.Enqueue(elt);
        }

        public static void Add<T>(this Stack<T> s, T elt)
        {
            s.Push(elt);
        }
    }
}
