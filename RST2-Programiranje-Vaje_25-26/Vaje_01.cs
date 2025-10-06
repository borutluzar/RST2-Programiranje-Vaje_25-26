namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_01_Naloge
    {
        Naloga121 = 1,
        Naloga122 = 2,
        Naloga123 = 3,
        Naloga131 = 4,
    }

    /// <summary>
    /// Rešitve vaj - 2. oktober 2025
    /// </summary>
    public class Vaje_01
    {
        /// <summary>
        /// Zapišite metodo, ki kot parameter dobi dan v tednu kot celo število, 
        /// nato pa izpiše dan z ustreznim imenom.
        /// Funkcijo implementirajte na dva načina: z uporabo if ter switch.
        /// </summary>
        public static void Naloga121_If(int dan)
        {
            // Za vsak dan bomo uporabili ločen if-else stavek.
            if(dan == 1) 
            {  
                Console.WriteLine("Ponedeljek"); 
            }
            else if (dan == 2)
            {
                Console.WriteLine("Torek");
            }
            else if (dan == 3)
            {
                Console.WriteLine("Sreda");
            }
            else if (dan == 4)
            {
                Console.WriteLine("Četrtek");
            }
            else if (dan == 5)
            {
                Console.WriteLine("Petek");
            }
            else if (dan == 6)
            {
                Console.WriteLine("Sobota");
            }
            else if (dan == 7)
            {
                Console.WriteLine("Nedelja");
            }
            else
            {
                Console.WriteLine($"Za število {dan} nimamo predpisanega dneva!");
            }
        }

        /// <summary>
        /// Zapišite metodo, ki kot parameter dobi dan v tednu kot celo število, 
        /// nato pa izpiše dan z ustreznim imenom.
        /// Funkcijo implementirajte na dva načina: z uporabo if ter switch.
        /// 
        /// Razmislite, kateri od obeh načinov je primernejši!
        /// </summary>
        public static void Naloga121_Switch(int dan)
        {
            switch (dan)
            {
                case 1:
                    Console.WriteLine("Ponedeljek");
                    break;
                case 2:
                    Console.WriteLine("Torek");
                    break;
                case 3:
                    Console.WriteLine("Sreda");
                    break;
                case 4:
                    Console.WriteLine("Četrtek");
                    break;
                case 5:
                    Console.WriteLine("Petek");
                    break;
                case 6:
                    Console.WriteLine("Sobota");
                    break;
                case 7:
                    Console.WriteLine("Nedelja");
                    break;
                default:
                    Console.WriteLine($"Za število {dan} nimamo predpisanega dneva!");
                    break;
            }
        }

        /// <summary>
        /// Zapišite funkcijo, ki uporablja stavek if za izpis uporabe primernega
        /// oblačila glede na zunanjo temperaturo.
        /// Uporabite vsaj štiri različne tipe oblačil.
        /// Razmislite, ali bi nalogo lahko rešili z uporabo stavka switch.
        /// </summary>
        public static void Naloga122(double temperatura)
        {
            if(temperatura > 30)
            {
                Console.WriteLine("Obleci kopalke!");
            }
            else if (temperatura > 20) // Uporabimo lahko 'else if', saj zmanjšujemo mejo in v primeru temp. višje od 30 izvedemo zgornji stavek, tega pa preskočimo
            {
                Console.WriteLine("Obleci kratko majico in hlače!");
            }
            else if(temperatura > 10)
            {
                Console.WriteLine("Obleci jopo!");
            }
            else
            {
                Console.WriteLine("Obleci plašč!");
            }
        }

        /// <summary>
        /// Zapišite funkcijo, ki uporablja stavek switch, da se odloči 
        /// za izpis števila dni v danem mesecu. 
        /// Predpostavite lahko, da nismo v prestopnem letu. 
        /// Možnosti, ki vrnejo enako vrednost, združite.
        /// </summary>
        public static int Naloga123(int mesec)
        {
            switch (mesec)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 2:
                    return 28;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                default: // Če številka meseca ni na interalu med 1 in 12, vrnemo 0
                    return 0;
            }
        }

        /// <summary>
        /// Zapišite metodo, ki izpisuje trenutni čas,  
        /// dokler produkt ur, minut in sekund ni deljiv s 17.
        /// Uporabite lastnost Now razreda DateTime.
        /// </summary>
        public static void Naloga131()
        {
            // Pridobimo trenutni čas
            DateTime trenutniCas = DateTime.Now;

            // Ponavljamo, dokler produkt ni deljiv s 17
            while ((trenutniCas.Hour * trenutniCas.Minute * trenutniCas.Second) % 17 != 0)
            {
                // Uporabimo formatiranje v interpolaciji
                Console.WriteLine($"{trenutniCas:HH:mm:ss}");

                // Po vsakem izpisu počakamo 900 ms
                Thread.Sleep(900);
                
                trenutniCas = DateTime.Now;
            }
            Console.WriteLine($"{trenutniCas:HH:mm:ss} je deljivo s 17.");
        }
    }
}
