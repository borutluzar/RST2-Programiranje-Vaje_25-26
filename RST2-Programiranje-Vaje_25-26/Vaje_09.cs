using Newtonsoft.Json;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_09_Naloge
    {
        Naloga431 = 1,
        Naloga432 = 2,
        Naloga433 = 3,
        Naloga434 = 4,
        Naloga435 = 5,
        Naloga436 = 6,
        Naloga437 = 7,
        Naloga438 = 8,
    }

    /// <summary>
    /// Rešitve vaj - 15. december 2025
    /// </summary>
    public class Vaje_09
    {
        public static void Naloga431()
        {
            List<int> numbers = new List<int>() { 4, 2, 3, 1, 6, 7, 33, 12, 14, 32, 75, 33, 2 };
            var result = numbers.Where(x => x % 2 == 0);
            Console.WriteLine(result.ToList().WriteCollection());
        }

        public static void Naloga432()
        {
            List<string> words = new List<string>() { "Danes", "je", "super", "dan", "za", "programiranje" };
            var result = words.Select(x => x.Length);
            Console.WriteLine(result.ToList().WriteCollection());
        }

        public static void Naloga433()
        {
            List<double> numbers = new List<double>() { -4.1, 2.2, -3, 10, -6, -7.32, -33.1, 12, 14, -3.12, 75, -33, 2 };
            var result = numbers.Count(x => x > 0);
            // ali
            //var result2 = numbers.Where(x => x > 0).Count();
            Console.WriteLine(result);
        }

        public static void Naloga434()
        {
            List<string> words = new List<string>() { "Danes", "je", "asuper", "ban", "za", "aprogramiranje" };
            List<string> starts = ["a", "A", "b", "B"];

            var result = words
                        .Where(x => starts.Contains(x[0].ToString()))
                        .Select(x => x.ToUpper())
                        .OrderByDescending(x => x.Length);
            Console.WriteLine(result.ToList().WriteCollection());
        }

        public static void Naloga435()
        {
            List<int> ocene = new List<int>() { 5, 6, 6, 6, 7, 8, 8, 8, 8, 9, 10, 10 };
            var result = ocene.GroupBy(ocena => ocena);

            foreach (var i in result)
            {
                Console.WriteLine(i.Key + ": " + i.Index().Count());
            }
        }

        public static void Naloga436()
        {
            StreamReader srData = new StreamReader("resources/naloga436.txt");

            while (!srData.EndOfStream)
            {
                string[] lineWords = srData.ReadLine().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

                var result = lineWords
                                .Where(word => word.Contains('A') || word.Contains('a'))
                                .OrderBy(word => word)
                                .Select(word => word.Substring(0, Math.Min(3, word.Length)));

                foreach (var output in result)
                {
                    Console.WriteLine(output);
                }
                Console.WriteLine();
            }
        }

        public static void Naloga437()
        {
            string json = File.ReadAllText("resources/naloga437.json");
                        
            var data = JsonConvert.DeserializeObject<Data>(json);

            var numDifferentBooks = data.Users
                                .SelectMany(i => i.Books)
                                .Distinct()
                                .Count();

            Console.WriteLine($"Število različnih izposojenih knjig: {numDifferentBooks}");
        }


        // Podatki za nalogo 4.3.8
        public static List<Material> materials = new List<Material>
        {
            new Material { ID = 0, NumBorrows = 3, Created = new DateTime(2025,3,21), Updated = new DateTime(2025,3,29), Name="Borut"},
            new Material { ID = 1, NumBorrows = 4, Created = new DateTime(2025,8,21), Updated = new DateTime(2025,2,20), Name="Ana"},
            new Material { ID = 2, NumBorrows = 2, Created = new DateTime(2023,3,26), Updated = new DateTime(2025,1,29), Name="Liza"},
            new Material { ID = 3, NumBorrows = 6, Created = new DateTime(2020,3,28), Updated = new DateTime(2025,8,29), Name="Ana"},
            new Material { ID = 4, NumBorrows = 8, Created = new DateTime(2024,1,2), Updated = new DateTime(2025,5,29), Name="Ana"},
            new Material { ID = 5, NumBorrows = 9, Created = new DateTime(2024,12,2), Updated = new DateTime(2025,12,29), Name="Ana"}
        };

        public static void Naloga438()
        {
            // 1. Pridobite zapis, ki je bil nazadnje spremenjen.
            var lastUpdated = materials
                .OrderByDescending(x => x.Updated)
                .First();
            Console.WriteLine("1. " + lastUpdated);

            // 2. Pridobite gradivo, ki ga je avtor, ki je prvi po abecedi, najprej ustvaril.
            var firstAuthor = materials
                .Select(x => x.Name)
                .OrderBy(x => x)
                .First();

            var createdByFirstAuthor = materials
                .Where(x => x.Name == firstAuthor)
                .OrderBy(x => x.Created)
                .First();
            Console.WriteLine("2. " + createdByFirstAuthor);

            // 3. Pridobite vsa gradiva avtorja nazadnje dodanega gradiva.
            var lastCreated = materials
                .OrderBy(x => x.Created)
                .First().Name;

            var listOfAuthorOfLastCreated = materials
                .Where(x => x.Name == lastCreated);

            Console.WriteLine("3. ");
            foreach (var item in listOfAuthorOfLastCreated)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Books { get; set; }
    }

    public class Data
    {
        public List<User> Users { get; set; }
    }

    public class Material
    {
        public int ID { get; set; }
        public int NumBorrows { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Ime: {Name},St. Izposoj: {NumBorrows}, Created: {Created:dd.MM.yyyy}, Updated: {Updated:dd.MM.yyyy}, ID: {ID}";
        }
    }
}
