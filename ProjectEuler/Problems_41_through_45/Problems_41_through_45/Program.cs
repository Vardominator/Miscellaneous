using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_41_through_45
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 41: Largest pandigital prime

            //long number = 0;
            //int digitCount = 1;
            //long largestPanPrime = 0;
            //HashSet<long> permutations;

            //for (int i = 1; i <= 9; i++)
            //{

            //    number = number * 10 + i;
            //    long n = number;

            //    permutations = new HashSet<long>();

            //    Permute(number.ToString().ToCharArray(), 0, digitCount - 1, permutations);

            //    foreach (long pandigitalValue in permutations)
            //    {
            //        if (IsPrime(pandigitalValue))
            //        {
            //            if(pandigitalValue > largestPanPrime)
            //            {
            //                largestPanPrime = pandigitalValue;
            //            }
            //        }
            //    }

            //    digitCount++;

            //}

            //Console.WriteLine($"Problem 41: {largestPanPrime}");

            #endregion

            #region Problem 42: Coded triangle numbers

            StreamReader sr = new StreamReader(@"C:\Users\barse\Desktop\Github\Miscellaneous\ProjectEuler\Problems_41_through_45\Problems_41_through_45\problem42words.txt");

            string[] words = sr.ReadLine().Split(',');

            int numberOfTriangleWords = 0;

            HashSet<long> triangleNumbers = new HashSet<long>();
            for (int i = 0; i < 100000; i++)
            {
                triangleNumbers.Add(triangle(i));

            }

            foreach (string word in words)
            {

                string cleanedWord = word.Trim(new char[] { '\\','"'});

                int sum = cleanedWord.Select(x => (int)(x - 64)).Sum();

                if (triangleNumbers.Contains(sum))
                {
                    numberOfTriangleWords++;
                    //Console.WriteLine(sum);
                }

            }
            Console.WriteLine($"Problem 42: {numberOfTriangleWords}");
            #endregion

        }

        #region Problem 42 helpers

        public static long triangle(long num)
        {
            return num * (num + 1) / 2;
        }

        #endregion

        #region Problem 41 helpers

        public static void Permute(char[] number, int l, int r, HashSet<long> permutations)
        {
            if (l == r) { return; }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    permutations.Add(Swap(number, l, i));
                    Permute(number, l + 1, r, permutations);
                    permutations.Add(Swap(number, l, i));
                }
            }
        }

        public static long Swap(char[] number, int a, int b)
        {
            char temp = number[a];
            number[a] = number[b];
            number[b] = temp;

            return CreateLong(number);
        }

        public static long CreateLong(char[] number)
        {
            long value = 0;

            for (int i = 0; i < number.Length; i++)
            {
                value = value * 10 + (number[i] - 48);
            }
            return value;
        }

        public static bool IsPandigital(long number)
        {
            
            HashSet<long> digits = new HashSet<long>();

            while(number > 0)
            {
                // Cannot contain zeros
                if(number % 10 == 0)
                {
                    return false;
                }
                if (digits.Contains(number % 10))
                {
                    return false;
                }
                
                digits.Add(number % 10);

                number /= 10;

            }

            return true;
        }

        public static bool IsPrime(long number)
        {

            for (long i = 2; i <= (long)Math.Sqrt(number); i++)
            {
                if(number % i == 0)
                {
                    return false;
                }
            }

            return true;

        }

        #endregion

    }
}
