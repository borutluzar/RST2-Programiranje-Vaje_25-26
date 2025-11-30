namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_05_Naloge
    {
        Naloga345 = 1,
        Naloga346 = 2,
        Naloga347 = 3,
    }

    /// <summary>
    /// Rešitve vaj - 7. november 2025
    /// </summary>
    public class Vaje_05
    {
        public static void Naloga345()
        {
            // Petkov menu
            Menu petek = new Menu(new DateTime(2025, 11, 7));
            
            Jed hrenovke = new Jed("Hotdog") { Cena = 5.9 };
            petek.Jedilnik.Add(hrenovke);
            
            Jed vampi = new Jed("Vampi") { Cena = 8.0 };
            petek.Jedilnik.Add(vampi);
            
            Sladica kremsnita = new Sladica("Blejska rezina") { Cena = 5.5, Kalorije = 800 };
            petek.Jedilnik.Add(kremsnita);

            // Sobotni menu
            Menu sobota = new Menu(new DateTime(2025, 11, 8));
            
            Jed rizota = new Jed("Vegi rižota") { Cena = 7.0 };
            sobota.Jedilnik.Add(rizota);

            Jed juha = new Jed("Goveja juha") { Cena = 6.0 };
            sobota.Jedilnik.Add(juha);

            Sladica tiramisu = new Sladica("Tiramisu") { Cena = 5.5, Kalorije = 600 };
            sobota.Jedilnik.Add(tiramisu);

            Console.WriteLine("JEDILNIK");
            Console.WriteLine(petek);
            Console.WriteLine($"Skupna cena menija je {petek.SkupnaCena(true)}.");

            Console.WriteLine("JEDILNIK");
            Console.WriteLine(sobota);
            Console.WriteLine($"Skupna cena menija je {sobota.SkupnaCena(true)}.");
        }

        public static void Naloga346()
        {
            // Ustvarimo primerke izdelkov Sadje
            Sadje jabolko = new Sadje("Jabolko", "Kranj", 0.99m, new DateTime(2024, 5, 20));
            Sadje mandarina = new Sadje("Mandarine", "Šenčur", 1.20m, new DateTime(2024, 3, 10));
            Sadje grozdje = new Sadje("Grozdje", "Kmetija Novak", 2.50m, new DateTime(2024, 4, 15));

            // Ustvarimo primerke izdelkov BelaTehnika
            BelaTehnika pralniStroj = new BelaTehnika("Pralni stroj", "Bosch", 499.99m, 36, "A++");
            BelaTehnika hladilnik = new BelaTehnika("Hladilnik", "Samsung", 699.99m, 24, "A++");
            BelaTehnika pomivalniStroj = new BelaTehnika("Pomivalni stroj", "Gorenje", 400.00m, 24, "A+");

            // Ustvarimo kosarico in dodamo izdelke
            Kosarica kosarica = new Kosarica();
            kosarica.DodajIzdelek(jabolko);
            kosarica.DodajIzdelek(mandarina);
            kosarica.DodajIzdelek(grozdje);
            kosarica.DodajIzdelek(pralniStroj);
            kosarica.DodajIzdelek(hladilnik);
            kosarica.DodajIzdelek(pomivalniStroj);

            // Izpišemo vsebino košarice
            Console.WriteLine(kosarica.ToString());
        }
    }


}
