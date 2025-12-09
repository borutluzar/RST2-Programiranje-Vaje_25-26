namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_08_Naloge
    {
        Naloga411 = 1,
        Naloga412 = 2,
        Naloga423 = 3
    }

    /// <summary>
    /// Rešitve vaj - 8. december 2025
    /// </summary>
    public class Vaje_08
    {
        public static void Naloga411()
        {
            ExampleDelegate exampleDelegate = Sum;
            double result = exampleDelegate(2, 3.4);
            Console.WriteLine(result);
        }

        public delegate double ExampleDelegate(int x, double y);

        public static double Sum(int x, double y)
        {
            return x + y;
        }

        public static double Difference(int x, double y)
        {
            return x - y;
        }


        public static void Naloga412()
        {
            List<int> seznam = new List<int> { 3, 56, 7, 8, 5 };
            AnalizaSeznama(seznam, NajdiNajvecjeLihoStevilo, AritmeticnaSredina);
        }

        public static void AnalizaSeznama(List<int> seznam, IskalniDelegat iskalni, PovprecniDelegat povprecje)
        {
            int iskani = iskalni(seznam);
            Console.WriteLine($"Nasli smo: {iskani}");
            Console.WriteLine($"Povprecje je: {povprecje(seznam)}");
        }

        public delegate int IskalniDelegat(List<int> seznam);

        public static int NajdiNajvecje(List<int> seznam)
        {
            return seznam.Max();
        }

        public static int NajdiNajvecjeLihoStevilo(List<int> seznam)
        {
            int rezultat = 0;
            foreach (int i in seznam)
            {
                if (i % 2 == 1 && rezultat < i)
                {
                    rezultat = i;
                }
            }
            if (rezultat == 0)
            {
                throw new Exception("Nimamo lihega stevila");
            }
            return rezultat;
        }

        public delegate double PovprecniDelegat(List<int> seznam);

        public static double AritmeticnaSredina(List<int> seznam)
        {
            return seznam.Sum() / (double)seznam.Count();
        }

        public static double Mediana(List<int> seznam)
        {
            seznam.Sort();
            if (seznam.Count() % 2 == 0)
            {
                return (seznam[seznam.Count() / 2] + seznam[seznam.Count() / 2 - 1]) / 2.0;
            }
            else
            {
                return (double)seznam[seznam.Count() / 2];
            }
        }


        public static void Naloga423()
        {
            List<Sale> sales = new List<Sale>
            {
                new Sale { Product = "Laptop", Category = "Electronics", Quantity = 3, PricePerUnit = 900, Date = new DateTime(2025, 12, 1) },
                new Sale { Product = "Headphones", Category = "Electronics", Quantity = 10, PricePerUnit = 40, Date = new DateTime(2025, 12, 1) },
                new Sale { Product = "Chair", Category = "Furniture", Quantity = 4, PricePerUnit = 70, Date = new DateTime(2025, 12, 2) },
                new Sale { Product = "Laptop", Category = "Electronics", Quantity = 1, PricePerUnit = 920, Date = new DateTime(2025, 12, 5) },
                new Sale { Product = "Desk", Category = "Furniture", Quantity = 2, PricePerUnit = 150, Date = new DateTime(2025, 12, 5) }
            };

            // Vprašanje (a)
            var queryA = from sale in sales
                         where sale.Category == "Electronics"
                         select sale;

            foreach (Sale sale in queryA)
            {
                Console.WriteLine(sale.Product);
            }

            // Vprašanje (b)
            var queryB = from sale in sales
                         select new
                         {
                             Product = sale.Product,
                             Total = sale.Quantity * sale.PricePerUnit
                         };

            foreach (var sale in queryB)
            {
                Console.WriteLine($"{sale.Product}: {sale.Total}");
            }
        }
    }

    public class Sale
    {
        public string Product { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public double PricePerUnit { get; set; }
        public DateTime Date { get; set; }
    }
}
