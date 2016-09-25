using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems_46_through_50
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 46: Goldbach's other conjecture

            //List<long> primes = new List<long>();
            //Dictionary<long, bool> oddComps = new Dictionary<long, bool>();

            //long smallestNonExisting = long.MaxValue;

            //for (long i = 3; i < 100000; i++)
            //{
            //    if (IsOddComposite(i))
            //    {

            //        oddComps.Add(i, false);
            //    }

            //    if (IsPrime(i))
            //    {
            //        primes.Add(i);
            //    }
            //}

            //for (int i = 0; i < primes.Count; i++)
            //{
            //    for (int j = 1; j <= 1000; j++)
            //    {
            //        long value = primes[i] + 2 * (long)Math.Pow(j, 2);
            //        oddComps[value] = true;
            //    }

            //}

            //var keysWithFalse = oddComps.Where(pair => pair.Value == false)
            //                                 .Select(pair => pair.Key);

            //foreach (var item in keysWithFalse)
            //{
            //    if (item < smallestNonExisting)
            //    {
            //        smallestNonExisting = item;
            //    }
            //}

            //Console.WriteLine($"Problem 46: {smallestNonExisting}");

            #endregion

            #region Problem 47: Distinct primes factors

            //List<long> primes = new List<long>();
            //List<long> distinctNumbers = new List<long>();

            //for (int i = 2; i <= 200; i++)
            //{
            //    if (IsPrime(i))
            //    {
            //        primes.Add(i);
            //    }
            //}

            //for (int i = 0; i < primes.Count - 3; i++)
            //{
            //    for (int j = i; j < primes.Count - 2; j++)
            //    {
            //        for (int k = j; k < primes.Count - 1; k++)
            //        {
            //            for (int p = k; p < primes.Count; p++)
            //            {
            //                long result = primes[i] * primes[j] * primes[k] * primes[p];
            //                long result2 = (long)(Math.Pow(primes[i], 2)) * primes[j] * primes[k] * primes[p];
            //                distinctNumbers.Add(result);
            //                distinctNumbers.Add(result2);
            //            }
            //        }
            //    }

            //}

            //distinctNumbers.Sort();


            //for (int i = 0; i < distinctNumbers.Count - 3; i++)
            //{
            //    if (distinctNumbers[i] == (distinctNumbers[i + 1] - 1))
            //    {
            //        if(distinctNumbers[i + 1] == (distinctNumbers[i + 2] - 1))
            //        {
            //            if (distinctNumbers[i + 2] == distinctNumbers[i + 3] - 1)
            //            {
            //                Console.WriteLine(distinctNumbers[i]);
            //                Console.WriteLine(distinctNumbers[i + 1]);
            //                Console.WriteLine(distinctNumbers[i + 2]);
            //                Console.WriteLine(distinctNumbers[i + 3]);
            //            }
            //        }
            //    }
            //}

            #endregion (Not Solved)

            #region Problem 48: Self powers

            //BigInteger sum = BigInteger.Zero;

            //for (int i = 1; i <= 1000; i++)
            //{
            //    BigInteger result = BigInteger.Pow(i, i);
            //    sum += result;
            //}

            //string sumStr = sum.ToString();

            //Console.WriteLine(sumStr.Substring(sumStr.Length - 10));

            #endregion

            #region Problem 49: Prime permutations

            //int initialNum = 1234;

            ////int m = initialNum;
            ////int n = 0;

            ////while (m > 0)
            ////{
            ////    n = n * 10 + (m % 10 + 1);
            ////    m /= 10;
            ////}

            ////m = n;
            ////n = 0;

            ////while (m > 0)
            ////{
            ////    n = n * 10 + m % 10;
            ////    m /= 10;
            ////}


            //for (int i = 1; i <= 9; i++)
            //{
            //    for (int j = 1; j <= 9; j++)
            //    {
            //        for (int k = 1; k <= 9; k++)
            //        {
            //            for (int p = 1; p <= 9; p++)
            //            {
            //                int value = i * 1000 + j * 100 + k * 10 + p;
            //                HashSet<long> permutations = new HashSet<long>();
            //                PermutePrimes(value.ToString().ToCharArray(), 0, 3, permutations);

            //                List<long> primePermutations = permutations.Where(x => IsPrime(x)).ToList();

            //                if (primePermutations.Count > 2)
            //                {
            //                    //Console.WriteLine(value);
            //                    primePermutations.Sort();

            //                    for (int a = 0; a < primePermutations.Count - 2; a++)
            //                    {
            //                        for (int b = a+1; b < primePermutations.Count - 1; b++)
            //                        {
            //                            for (int c = b+1; c < primePermutations.Count; c++)
            //                            {

            //                                long left = primePermutations[a];
            //                                long middle = primePermutations[b];
            //                                long right = primePermutations[c];

            //                                if (Math.Abs(left - middle) == Math.Abs(right - middle))
            //                                {
            //                                    Console.WriteLine($"{left}, {middle}, {right}");
            //                                }

            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            #endregion

            #region Problem 50: Consecutive prime sum

            //List<long> primes = new List<long>();

            //for (int i = 2; i <= 5000; i++)
            //{
            //    if (IsPrime(i))
            //    {
            //        primes.Add(i);
            //    }
            //}

            //long largestPrime = 0;
            //int largestConsective = 0;
            //long maxValue = 1000;

            //for (int i = 0; i < primes.Count; i++)
            //{
            //    long sum = 0;
            //    for (int j = i; j < primes.Count; j++)
            //    {
            //        sum += primes[j];
            //        if (IsPrime(sum) && (j-i) > largestConsective && sum < 1000000)
            //        {
            //            largestConsective = j - i;
            //            largestPrime = sum;
            //            Console.WriteLine(sum);
            //            //Console.WriteLine(largestConsective);
            //        }
            //    }

            //}
            

            //for (int i = 0; i < primes.Count; i++)
            //{
            //    long sum = 0;
            //    for (int j = 0; j <= i; j++)
            //    {
            //        sum += primes[j];
            //        if (IsPrime(sum) && j > largestConsective && sum < 1000000)
            //        {
            //            largestPrime = sum;
            //            largestConsective = j;
            //            Console.WriteLine(sum);
            //            //Console.WriteLine(largestConsective);
            //        }
            //    }
            //}


            #endregion

        }

        public static void CombinationRepetitionUtil(long[] temp, List<long> primes, int index, int r, int start, int end, long[] largestPrime)
        {
            if(index == r)
            {
                long currentSum = 0;

                for (int i = 0; i < r; i++)
                {
                    currentSum += temp[i];
                    
                }

                if (currentSum > largestPrime[0] && IsPrime(currentSum))
                {
                    
                    Console.WriteLine(largestPrime[0]);
                    largestPrime[0] = currentSum;
                }

                return;
            }

            for (int i = start; i <= end; i++)
            {
                temp[index] = i;
                CombinationRepetitionUtil(temp, primes, index + 1, r, i, end, largestPrime);
            }

            return;
        }


        public static void CombinationRepetition(List<long> primes, int n, int r, long[] largestPrime)
        {
            long[] temp = new long[r + 1];

            CombinationRepetitionUtil(temp, primes, 0, r, 0, n - 1, largestPrime);
        }
   

        public static void PermutePrimes(char[] number, int l, int r, HashSet<long> permutations)
        {
            if (l == r) { return; }
            else
            {
                for (int i = l; i <= r; i++)
                {
                    //if (IsPrime(long.Parse(Swap(number, l, i))))
                    //{
                        permutations.Add(long.Parse(Swap(number, l, i)));
                    //}

                    PermutePrimes(number, l + 1, r, permutations);

                    //if (IsPrime(long.Parse(Swap(number, l, i))))
                    //{
                        permutations.Add(long.Parse(Swap(number, l, i)));
                    //}
                }
            }
        }

        public static string Swap(char[] number, int a, int b)
        {
            char temp = number[a];
            number[a] = number[b];
            number[b] = temp;

            return new string(number);
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

        public static bool IsPrime(long num)
        {
            for (int i = 2; i <= num/2; i++)
            {
                if(num % i == 0)
                {
                    return false;
                }

            }
            return true;
        }

        public static bool IsOddComposite(long num)
        {

            if(num % 2 == 0)
            {
                return false;
            }

            for (int i = 3; i <= num/2; i+=2)
            {
                if(num % i == 0)
                {
                    return true;
                }

            }
            return false;
        }

    }
}
