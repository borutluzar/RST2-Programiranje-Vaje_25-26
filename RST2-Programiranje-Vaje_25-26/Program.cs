namespace RST2_Programiranje_Vaje_25_26
{
    internal class Program
    {
        enum Sections
        {
            Vaje_01 = 1, //   2. 10. 2025
            Vaje_02 = 2, //   6. 10. 2025
            Vaje_03 = 3, //  13. 10. 2025
            Vaje_04 = 4, //  23. 10. 2025
            Vaje_05 = 5, //   7. 11. 2025
            Vaje_06 = 6, //  11. 11. 2025
            Vaje_07 = 7, //   1. 12. 2025
            Vaje_08 = 8, //   8. 12. 2025
            Vaje_09 = 9, //  15. 12. 2025
            Vaje_10 = 10, // 18. 12. 2025
            Vaje_11 = 11, // 20. 12. 2025
            Vaje_12 = 12, //  5.  1. 2025
            Vaje_13 = 13, //  7.  1. 2025
            Vaje_14 = 14, // 12.  1. 2025
            Vaje_15 = 15, // 14.  1. 2025
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
                                    // Z zanko foreach
                                    List<double> seznam1 = new List<double>() { 1, 2, 3, 4, 5, 6 };
                                    var noviSeznamForeach = Vaje_02.Naloga132_Foreach(seznam1);

                                    // Z zanko for
                                    List<double> seznam2 = new List<double>() { 1, 2, 3, 4, 5, 6 };
                                    var noviSeznamFor = Vaje_02.Naloga132_For(seznam2);
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

                case Sections.Vaje_03:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_03_Naloge>())
                        {
                            case Vaje_03_Naloge.Naloga311:
                            case Vaje_03_Naloge.Naloga312:
                                {
                                    Vaje_03.Naloga311_312();
                                }
                                break;
                            case Vaje_03_Naloge.Naloga313:
                                {
                                    Vaje_03.Naloga313();
                                }
                                break;
                            case Vaje_03_Naloge.Naloga321:
                            case Vaje_03_Naloge.Naloga322:
                            case Vaje_03_Naloge.Naloga323:
                                {
                                    Vaje_03.Naloga321_323();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_04:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_04_Naloge>())
                        {
                            case Vaje_04_Naloge.Naloga331:
                                {
                                    Vaje_04.Naloga331();
                                }
                                break;
                            case Vaje_04_Naloge.Naloga332:
                                {
                                    Vaje_04.Naloga332();
                                }
                                break;
                            case Vaje_04_Naloge.Naloga344:
                                {
                                    Vaje_04.Naloga344();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_05:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_05_Naloge>())
                        {
                            case Vaje_05_Naloge.Naloga345:
                                {
                                    Vaje_05.Naloga345();
                                }
                                break;
                            case Vaje_05_Naloge.Naloga346:
                                {
                                    Vaje_05.Naloga346();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_06:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_06_Naloge>())
                        {
                            case Vaje_06_Naloge.Naloga351:
                                {
                                    Vaje_06.Naloga351();
                                }
                                break;
                            case Vaje_06_Naloge.Naloga354:
                                {
                                    Vaje_06.Naloga354();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_07:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_07_Naloge>())
                        {
                            case Vaje_07_Naloge.Naloga361:
                                {
                                    Vaje_07.Naloga361();
                                }
                                break;

                            case Vaje_07_Naloge.Naloga365:
                                {
                                    Vaje_07.Naloga365();
                                }
                                break;

                            case Vaje_07_Naloge.Naloga371:
                                {
                                    Vaje_07.Naloga371();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_08:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_08_Naloge>())
                        {
                            case Vaje_08_Naloge.Naloga411:
                                {
                                    Vaje_08.Naloga411();
                                }
                                break;

                            case Vaje_08_Naloge.Naloga412:
                                {
                                    Vaje_08.Naloga412();
                                }
                                break;

                            case Vaje_08_Naloge.Naloga423:
                                {
                                 Vaje_08.Naloga423();   
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_09:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_09_Naloge>())
                        {
                            case Vaje_09_Naloge.Naloga431:
                                {
                                    Vaje_09.Naloga431();
                                }
                                break;

                            case Vaje_09_Naloge.Naloga432:
                                {
                                    Vaje_09.Naloga432();
                                }
                                break;

                            case Vaje_09_Naloge.Naloga433:
                                {
                                    Vaje_09.Naloga433();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga434:
                                {
                                    Vaje_09.Naloga434();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga435:
                                {
                                    Vaje_09.Naloga435();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga436:
                                {
                                    Vaje_09.Naloga436();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga437:
                                {
                                    Vaje_09.Naloga437();
                                }
                                break;
                            case Vaje_09_Naloge.Naloga438:
                                {
                                    Vaje_09.Naloga438();
                                }
                                break;
                        }
                    }
                    break;

                case Sections.Vaje_10:
                    {
                        switch (InterfaceFunctions.ChooseSection<Vaje_10_Naloge>())
                        {
                            case Vaje_10_Naloge.Naloga521:
                                {
                                    Vaje_10.Naloga521();
                                }
                                break;

                            case Vaje_10_Naloge.Naloga522:
                                {
                                    Vaje_10.Naloga522();
                                }
                                break;

                            case Vaje_10_Naloge.Naloga532:
                                {
                                    Vaje_10.Naloga532();
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


