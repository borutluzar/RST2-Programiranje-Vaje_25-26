using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_11_Naloge
    {
        Naloga531 = 1,
        Naloga541 = 2,
        Naloga611 = 3,
        Naloga612 = 4,
        Naloga613 = 5
    }

    /// <summary>
    /// Rešitve vaj - 20. december 2025
    /// </summary>
    public class Vaje_11
    {        
        public static void Naloga531()
        {
            Vaje_11_Exam.ExamUI();
        }

        public static void Naloga541()
        {
            Console.WriteLine("Akcije, ki jih pozna Mike:");
            Sprinter mike = new Sprinter("Mike", 23);
            mike.Running();
            mike.Throwing();
            mike.Jumping();


            Console.WriteLine("Akcije, ki jih pozna Tony:");
            Jumper tony = new Jumper("Tony", 25);
            tony.Running();
            tony.Throwing();
            tony.Jumping();

        }

        public static void Naloga611()
        {
            int a = 3;
            int b = 7;

            Console.WriteLine($"a={a}, b={b}");
            Swap(ref a, ref b);
            Console.WriteLine($"a={a}, b={b}");
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public static void Naloga612()
        {
            List<int> list = new List<int>() { 3, 8, 16, 23, 40, 5, 7, 12 };
            Console.WriteLine($"Vsota je {SumMaxK(list, 4)}");
        }

        public static void Naloga613()
        {
            int test = 2;

            // Se ne prevede, ker int ni sklicni tip
            /*Repository<int> repository1 = new Repository<int>();
            repository1.Add(test);*/

            Repository<string> repository2 = new Repository<string>();
            repository2.Add(test.ToString());
        }

        /// <summary>
        /// Uporabimo INumber za omejitev na tipe, ki poznajo lastnost Zero
        /// </summary>
        public static T SumMaxK<T>(List<T> list, int maxK) where T : INumber<T>
        {
            //3, 8, 16, 23, 40, 5, 7, 12; k = 4 => 16 + 23 + 40 + 12 = 91
            var result = list
                .OrderByDescending(x => x)
                .Take(maxK);
            T sum = T.Zero;
            foreach (var c in result)
            {
                sum += c;
            }
            return sum;
        }
    }

    public class Repository<T> where T : class
    {
        public Repository() { }

        public void Add(T item)
        {
            Console.WriteLine($"Item {item} je bil dodan");
        }
    }
}
