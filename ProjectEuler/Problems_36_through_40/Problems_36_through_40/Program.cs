﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_36_through_40
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 36: Double-base palindromes

            //int palindromeSums = 0;

            //for (int i = 1; i < 1000000; i++)
            //{
            //    string numBinary = Convert.ToString(i, 2);
            //    if (IsPalindrome(i.ToString()) && IsPalindrome(numBinary))
            //    {
            //        Console.WriteLine($"{i} => {numBinary}");
            //        palindromeSums += i;
            //    }

            //}
            //Console.WriteLine($"Problem 36: {palindromeSums}");

            #endregion


            #region Problem 37: Truncatable primes

            //int sum = 0;
            //for (int i = 11; i <= 800000; i++)
            //{
            //    bool isTruncatable = true;

            //    if (IsPrime(i))
            //    {

            //        string numStr = i.ToString();

            //        for (int j = 0; j < numStr.Length; j++)
            //        {
            //            string subNumLeft = numStr.Substring(j);

            //            //Console.WriteLine(subNumLeft);
            //            if (!IsPrime(int.Parse(subNumLeft)))
            //            {

            //                isTruncatable = false;
            //                break;
            //            }
            //        }

            //        if (isTruncatable)
            //        {
            //            for (int k = numStr.Length; k > 0; k--)
            //            {
            //                string subNumRight = numStr.Substring(0, k);
            //                //Console.WriteLine(subNumRight);
            //                if (!IsPrime(int.Parse(subNumRight)))
            //                {

            //                    isTruncatable = false;
            //                    break;
            //                }
            //            }
            //        }
            //        if (isTruncatable)
            //        {
            //            Console.WriteLine(i);
            //            sum += i;
            //        }
            //    }

            //}

            //Console.WriteLine($"Problem 37: {sum}");


            #endregion


            #region Problem 38: Pandigital multiples

            //long largestPandigital = 0;

            //for (long i = 1; i < 190000; i++)
            //{

            //    int multiple = 1;
            //    long product = i;

            //    StringBuilder result = new StringBuilder();
            //    int length = 0;
            //    while (result.Length < 9)
            //    {
            //        length++;
            //        product = i * multiple;
            //        result.Append(product);
            //        multiple++;
            //    }

            //    if (IsPandigital(result.ToString()) && length > 1)
            //    {

            //        if(long.Parse(result.ToString()) > largestPandigital)
            //        {
            //            //Console.WriteLine(i);

            //            largestPandigital = long.Parse(result.ToString());
            //           // Console.WriteLine(largestPandigital.ToString());
            //        }
            //    }
            //}
            //Console.WriteLine($"Problem 38: {largestPandigital}");
            #endregion


            #region Problem 39: Integer right triangles

            int maximumSize = 0;
            int maxP = 1;

            for (int p = 1; p <= 1000; p++)
            {

                HashSet<double> solutions = new HashSet<double>();

                for (int a = 1; a <= p / 2; a++)
                {
                    for (int b = 1; b < p / 2; b++)
                    {
                        double c = Math.Sqrt(a * a + b * b);

                        if (a + b + c == p)
                        {
                            solutions.Add(a);
                            solutions.Add(b);
                            solutions.Add(c);
                        }

                    }

                }

                if(solutions.Count/3 > maximumSize)
                {
                    maximumSize = solutions.Count / 3;
                    maxP = p;
                }
            }

            Console.WriteLine($"Problem 39: {maxP}");

            #endregion


            #region Problem 40: Champernowne's constant

            //StringBuilder sb = new StringBuilder();

            //for (int i = 0; i < 1000000; i++)
            //{
            //    sb.Append(i);
            //}

            ////Console.WriteLine(sb.Length);
            //long result = 1;

            //int numberOfDigits = 1;

            //for (int i = 1; i <= 1000000; i*=10)
            //{

            //    //for (int j = 0; j < numberOfDigits; j++)
            //    //{
            //        //Console.Write(sb[i + j]);
            //        result *= long.Parse(sb[i].ToString());

            //    //}

            //    numberOfDigits++;

            //}

            //Console.WriteLine($"Problem 40: {result}");
            #endregion



        }


        // Problem 38 helper
        public static bool IsPandigital(string number)
        {

            HashSet<char> digits = new HashSet<char>();

            for (int i = 0; i < number.Length; i++)
            {
                if (!digits.Contains(number[i]))
                {
                    digits.Add(number[i]);
                }
                else
                {
                    return false;
                }

            }

            if (digits.Contains('0'))
            {
                return false;
            }
            return true;

        }


        // Problem 37 helper
        public static bool IsPrime(int number)
        {

            if (number < 2) { return false; }

            for (int i = 2; i <= number/2; i++)
            {
                if(number % i == 0)
                {
                    return false;
                }

            }
            return true;
        }

        // Problem 36 helper
        public static bool IsPalindrome(string numStr)
        {

            StringBuilder sb = new StringBuilder();

            for (int i = numStr.Length - 1; i >= 0; i--)
            {
                sb.Append(numStr[i]);
            }

            return numStr == sb.ToString();

        }
    }
}
