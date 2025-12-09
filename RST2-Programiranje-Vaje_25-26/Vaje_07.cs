namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_07_Naloge
    {
        Naloga361 = 1,
        Naloga365 = 2,
        Naloga371 = 3    
    }

    /// <summary>
    /// Rešitve vaj - 1. december 2025
    /// </summary>
    public class Vaje_07
    {
        public static void Naloga361()
        {
            Porocilo davki = new Porocilo();
            davki.Naziv = "Letno porocilo davkov";
            davki.Avtor = "Janez";
            davki.CasUstvarjeno = DateTime.Now;

            davki.Pripravljalec = new SistemskiUporabnik("Tomi123");
            davki.Pregledovalec = new SistemskiUporabnik("Toncek");
            davki.Potrjevalec = new SistemskiUporabnik("Metka");

            var opravljeno = false;
            do
            {
                Console.WriteLine($"Trenutno stanje dokumenta: {davki.TrenutniKorak}");
                opravljeno = davki.PosljiVNaslednjiKorak();
            } while (opravljeno);
        }

        public static void Naloga365()
        {
            Position ana = new Position() { X = 3, Y = 2 };
            Position bojan = new Position() { X = 3, Y = 2 };
            
            if (ana.Equals(bojan))
            {
                Console.WriteLine("Pozicija Ane in Bojana je enaka.");
            }
            else
            {
                Console.WriteLine("Pozicija Ane in Bojana ni enaka.");
            }
        }

        public static void Naloga371()
        {
            List<int> seznam = new List<int>() { 13, 1, 3, 4, -1, 19};
            Console.WriteLine(seznam.WriteList());
        }        
    }

    public struct Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public bool Equals(Position other)
        {
            if (this.X == other.X && this.Y == other.Y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        /* Metoda Equals, ki jo podedujemo iz razreda Object
        public override bool Equals(object? obj)
        {
            return base.Equals(obj);
        }
        */
    }


    /// <summary>
    /// Razred z razširitvenimi metodami
    /// </summary>
    public static class Extensions
    {
        public static string WriteList(this List<int> seznam)
        {
            string rezultat = "{";
            
            bool first = true;
            foreach (int i in seznam)
            {                
                if (!first)
                {
                    rezultat += ", ";
                }
                rezultat += i;
                first = false;
            }
            rezultat += "}";

            return rezultat;
        }
    }
}
