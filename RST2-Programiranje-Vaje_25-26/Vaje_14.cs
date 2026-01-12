using System.Diagnostics;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_14_Naloge
    {
        Naloga811 = 1,
        Naloga832 = 2
    }

    /// <summary>
    /// Rešitve vaj - 12. januar 2025
    /// </summary>
    public class Vaje_14
    {

        /// <summary>
        /// Napišite program, ki hkrati izvaja dva procesa. 
        /// Prvi proces vsakih 7 stotink sekunde poveča dani kot za 1 radian,
        /// drugi proces pa vsakih 11 stotink sekunde poveča dani kot za 4 radiane. 
        /// Uporabniku se prikazujeta oba kota z modulom 2 Pi, 
        /// torej na nek način kot kota dveh urinih kazalcev. 
        /// Uporabnik ima možnost prekinitve programa. 
        /// Ko ga prekine, se mu izpiše razlika med kotoma. 
        /// Cilj je, da gumb pritisne ob čim manjši razliki. 
        /// Analizirajte, kako hitro se program odziva na prekinitev.
        /// </summary>
        public static void Naloga811()
        {
            CancellationTokenSource token = new();

            // Spodnja taska prejmeta rezultat funkcije, zato moramo paziti,
            // da njunega tipa ne označimo kot Task, ampak kot Task<double> (ali samo z var)!
            Task<double> taskAlpha = Task.Run(() => PovecajRadiane(1, 70, token));
            Task<double> taskBeta = Task.Run(() => PovecajRadiane(4, 110, token));

            Console.ReadLine();
            Console.WriteLine($"Prekinitev programa: {DateTime.Now:HH:mm:ss.fff}");
            token.Cancel();
            var alpha = taskAlpha.Result;
            Console.WriteLine($"Razlika med kotoma: {Math.Abs(taskAlpha.Result - taskBeta.Result)}");

        }

        private static double PovecajRadiane(int increment, int timeout, CancellationTokenSource token)
        {
            double angle = 0;
            while (!token.IsCancellationRequested)
            {
                angle = (angle + increment) % (2 * Math.PI);
                Thread.Sleep(timeout);
            }
            Console.WriteLine($"Prekinitev metode {nameof(PovecajRadiane)}: {DateTime.Now:HH:mm:ss.fff}");
            return angle;
        }

        /// <summary>
        /// Napišite funkcijo, ki poišče najmanjše število z natanko 200 delitelji. 
        /// Implementirajte jo zaporedno in vzporedno in primerjajte čas izvajanja.
        /// </summary>
        public static void Naloga832()
        {
            int listSize = int.MaxValue; //1_000_000; //10_000_000;
            int numDivs = 100;

            var lstNums = Enumerable.Range(1, listSize);

            // Zaporedno
            Stopwatch sw = Stopwatch.StartNew();
            // First najde prvi element in zaključi funkcijo
            int minSerial = lstNums.First(x => NumDivisors(x) == numDivs);

            /* Ali ekvivalentno:
            int minSerial = 0;
            foreach (int num in lstNums)
            {
                if(NumDivisors(num) == numDivs)
                {
                    minSerial = num;
                    break;
                }
            }
            */
            Console.WriteLine($"Zaporedno: prvo število s {numDivs} delitelji je {minSerial}. Čas: {sw.Elapsed.TotalSeconds:0.00}");

            // Paralelno
            sw.Restart();

            // Uporaba == je bistveno počasnejša od >=, razloga še ne poznam
            // Sta pa v primerih numDivs = 100 in numDivs = 200 rezultata enaka, ampak v splošnem to ne bo nujno res.
            //int minParallel = lstNums.AsParallel().AsOrdered().First(x => NumDivisors(x) == numDivs);
            int minParallel = lstNums.AsParallel().AsOrdered().First(x => NumDivisors(x) >= numDivs);
            Console.WriteLine($"Paralelno: prvo število s {numDivs} delitelji je {minParallel}. " +
                    $"Čas: {sw.Elapsed.TotalSeconds:0.00}");
        }

        private static int NumDivisors(int n)
        {
            int count = 0;
            int sqrt = (int)Math.Sqrt(n);

            for (int i = 1; i <= sqrt; i++)
            {
                if (n % i == 0)
                {
                    count++;
                    if (i != n / i) // Prištejemo še deliteljev par 
                        count++;
                }
            }
            return count;
        }
    }
}
