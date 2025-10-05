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
            }
            Console.Read();
        }
    }
}


