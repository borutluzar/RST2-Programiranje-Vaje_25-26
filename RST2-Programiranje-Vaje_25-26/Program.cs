namespace RST2_Programiranje_Vaje_25_26
{
    internal class Program
    {
        enum Sections
        {
            Vaje_01 = 1, //  2. 10. 2025
            Vaje_02 = 2, //  6. 10. 2025
        }

        static void Main(string[] args)
        {
            switch (InterfaceFunctions.ChooseSection<Sections>())
            {
                case Sections.Vaje_01:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_01_Naloge>())
                        {
                            case Vaje_01_Naloge.Naloga121:
                                {
                                    int dan = 3;
                                    // S stavkom if
                                    Vaje_01.Naloga121_If(dan);

                                    // S stavkom switch
                                    Vaje_01.Naloga121_Switch(dan);
                                }
                                break;
                            case Vaje_01_Naloge.Naloga122:
                                {
                                    int temperatura = 14;

                                    Vaje_01.Naloga122(temperatura);
                                }
                                break;
                            case Vaje_01_Naloge.Naloga123:
                                {
                                    Console.Write("Vpišite številko meseca: ");
                                    int mesec = int.Parse(Console.ReadLine());
                                    int stDni = Vaje_01.Naloga123(mesec);
                                    Console.WriteLine($"V {mesec}. mesecu je {stDni} dni.");
                                }
                                break;
                            case Vaje_01_Naloge.Naloga131:
                                {
                                    Vaje_01.Naloga131();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_02:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_02_Naloge>())
                        {
                            case Vaje_02_Naloge.Naloga132:
                                {
                                    List<double> seznam = new List<double>() { 1, 2, 3, 4, 5, 6 };
                                    // Z zanko for
                                    var noviSeznamFor = Vaje_02.Naloga132_For(seznam);

                                    // Z zanko foreach
                                    var noviSeznamForeach = Vaje_02.Naloga132_Foreach(seznam);
                                }
                                break;
                            case Vaje_02_Naloge.Naloga135:
                                {
                                    string url = "https://www.fis.unm.si";

                                    Vaje_02.Naloga135(url);
                                }
                                break;
                            case Vaje_02_Naloge.Naloga141:
                                {
                                    int a = 12;
                                    int b = 8;

                                    (int lcm, int gcd) = Vaje_02.Naloga141(a, b);
                                    Console.WriteLine($"Za števili {a} in {b} je najmanjši skupni večkratnik {lcm}," +
                                        $" največji skupni delitelj pa {gcd}.");
                                }
                                break;
                            case Vaje_02_Naloge.Naloga142:
                                {
                                    int a = 12;
                                    int b = 8;

                                    int lcm = Vaje_02.Naloga142(a, b, out int gcd, computeGCD: true);
                                    Console.WriteLine($"Za števili {a} in {b} je najmanjši skupni večkratnik {lcm}," +
                                        $" največji skupni delitelj pa {gcd}.");
                                }
                                break;
                            case Vaje_02_Naloge.Naloga171:
                                {
                                    string fileIn = "resources/fileIn.txt";
                                    string fileOut = "fileOut.txt";

                                    Vaje_02.Naloga171(fileIn, fileOut);                                    
                                }
                                break;
                            case Vaje_02_Naloge.Naloga182:
                                {
                                    int steviloMetov = 1000;
                                    Vaje_02.Naloga182(steviloMetov);
                                }
                                break;
                        }
                    }
                    break;
            }
            Console.Read();
        }
    }
}


