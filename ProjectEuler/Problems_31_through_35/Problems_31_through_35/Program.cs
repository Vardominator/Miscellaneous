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

            //long pandigitalSum = 0;

            //HashSet<long> memoizedProducts = new HashSet<long>();


            //for(long num = 1; num < 5000; num++)
            //{
            //    for(long num2 = 1; num2 < 5000; num2++)
            //    {
            //        long result = num * num2;

            //        if(IsPandigital(num, num2, result))
            //        {

            //            if (!memoizedProducts.Contains(result))
            //            {
            //                memoizedProducts.Add(result);
            //                Console.WriteLine($"{num} x {num2} = {result}");
            //                pandigitalSum += result;
            //            }

            //        }
            //    }
            //}
            //Console.WriteLine($"Problem 32: {pandigitalSum}");
            #endregion

            #region Problem 33: Digit cancelling fractions

            //HashSet<string> nontrivial = new HashSet<string>();

            //int productNum = 1;
            //int productDen = 1;

            //// numerator
            //for (int i = 10; i < 99; i++)
            //{
            //    for (int j = i + 1; j <= 99; j++)
            //    {
            //        if (i % 10 != 0 && j % 10 != 0)
            //        {
            //            int numerator = i;
            //            int denominator = j;

            //            int numeratorDigit1 = numerator / 10;
            //            int numeratorDigit2 = numerator % 10;

            //            int denominatorDigit1 = denominator / 10;
            //            int denominatorDigit2 = denominator % 10;

            //            if ((double)numeratorDigit1 / denominatorDigit2 == (double)numerator / denominator && (double)numeratorDigit2 / denominatorDigit1 == 1.0)
            //            {
            //                nontrivial.Add($"{ numeratorDigit1}/{ denominatorDigit2}");
            //                productNum *= numeratorDigit1;
            //                productDen *= denominatorDigit2;
            //            }
            //        }
            //    }

            //}

            //for(int k = 9; k >= 2; k--)
            //{
            //    while(productNum % k == 0)
            //    {
            //        productNum /= k;
            //        productDen /= k;
            //    }
            //}

            //Console.WriteLine($"Problem 33: {productDen}");

            #endregion

            #region Problem 34: Digit Factorials

            //long totalSum = 0;

            //for (int i = 3; i <= 10000000; i++)
            //{

            //    string numString = i.ToString();

            //    long factorialSum = 0;

            //    for (int j = 0; j < numString.Length; j++)
            //    {
            //        factorialSum += factorial(long.Parse(numString[j].ToString()));
            //    }

            //    if (factorialSum == i)
            //    {
            //        Console.WriteLine($"{i}: {factorialSum}");
            //        totalSum += i;
            //    }

            //}
            //Console.WriteLine($"Problem 34: {totalSum}");
            #endregion

            #region Problem 35: Circular primes

            int circularPrimes = 0;

            for (int i = 2; i <= 1000000; i++)
            {
                if (IsPrime(i))
                {

                    string NumString = i.ToString();
                    HashSet<string> rotations = new HashSet<string>();

                    bool rotationsPrime = true;

                    while (!rotations.Contains(NumString))
                    {
                        rotations.Add(NumString);
                        NumString = LeftRotateString(NumString);

                        if (!IsPrime(int.Parse(NumString)))
                        {
                            rotationsPrime = false;
                            break;
                        }

                    }

                    if (rotationsPrime)
                    {
                        Console.WriteLine(i);
                        circularPrimes++;
                    }

                }
            }

            Console.WriteLine($"Problem 35: {circularPrimes}");

            #endregion

        }
        

        // Problem 35 helpers
        public static string LeftRotateString(string str)
        {
            StringBuilder sb = new StringBuilder();

            char firstChar = str[0];

            for (int i = 1; i < str.Length; i++)
            {
                sb.Append(str[i]);
            }

            sb.Append(firstChar);

            return sb.ToString();

        }

        public static bool IsPrime(int num)
        {

            for (int i = 2; i <= num / 2; i++)
            {
                if(num % i == 0)
                {
                    return false;
                }

            }

            return true;

        }


        // Problem 34 helper
        public static long factorial(long num)
        {

            if(num < 2)
            {
                return 1;
            }
            return num * factorial(num - 1);

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
