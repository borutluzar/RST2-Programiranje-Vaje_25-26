﻿namespace MyLibrary
{
    public class AuxilliaryFunctions
    {
        /// <summary>
        /// Za dani števili funkcija vrne njun največji skupni delitelj.
        /// </summary>
        public static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Za dani števili funkcija vrne njun najmanjši skupni večkratnik.
        /// </summary>
        public static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }
    }
}
