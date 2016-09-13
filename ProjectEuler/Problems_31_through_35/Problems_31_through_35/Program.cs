using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_31_through_35
{
    class Program
    {

        struct Pair
        {
            long x;
            long y;
        }

        static void Main(string[] args)
        {

            #region Problem 31: Coins

            //int oneP = 1, twoP = 2, fiveP = 5, tenP = 10, twentyP = 20, fiftyP = 50;
            //int e1 = 100, e2 = 200;

            //int differentWays = 0;

            //for (int a = 0; a <= 200; a++)
            //{
            //    for (int b = 0; b <= 100; b++)
            //    {
            //        for (int c = 0; c <= 40; c++)
            //        {
            //            for (int d = 0; d <= 20; d++)
            //            {
            //                for (int e = 0; e <= 10; e++)
            //                {
            //                    for (int f = 0; f <= 4; f++)
            //                    {
            //                        for (int g = 0; g <= 2; g++)
            //                        {

            //                            int result = a * oneP + b * twoP + c * fiveP + d * tenP
            //                                       + e * twentyP + f * fiftyP + g * e1;

            //                            if(result == e2)
            //                            {
            //                                differentWays++;
            //                            }

            //                        }

            //                    }
            //                }

            //            }

            //        }

            //    }

            //}

            //Console.WriteLine($"Problem 31: {differentWays}");

            #endregion

            #region Problem 32: Pandigital products

            long pandigitalSum = 0;

            HashSet<long> memoizedProducts = new HashSet<long>();


            for(long num = 1; num < 5000; num++)
            {
                for(long num2 = 1; num2 < 5000; num2++)
                {
                    long result = num * num2;
                    
                    if(IsPandigital(num, num2, result))
                    {

                        if (!memoizedProducts.Contains(result))
                        {
                            memoizedProducts.Add(result);
                            Console.WriteLine($"{num} x {num2} = {result}");
                            pandigitalSum += result;
                        }

                    }
                }
            }
            Console.WriteLine($"Problem 32: {pandigitalSum}");
            #endregion

        }


        // Problem 32 helper
        public static bool IsPandigital(long num1, long num2, long result)
        {

            string numStr = num1.ToString() + num2.ToString() + result.ToString();

            HashSet<char> digits = new HashSet<char>();

            if(numStr.Contains('0') || numStr.Length < 9)
            {
                return false;
            }

            foreach (var digitChar in numStr)
            {

                if (!digits.Contains(digitChar))
                {
                    digits.Add(digitChar);
                }
                else
                {
                    return false;
                }

            }
            
            return true;

        }

    }
}
