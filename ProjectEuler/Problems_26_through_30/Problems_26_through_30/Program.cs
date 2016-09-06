using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems_26_through_30
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 26: Reciprocal Cycles


            //int maxRecurrenceCount = 0;
            //int maxRecurrenceNum = 0;

            //List<int> broughtDown = new List<int>();

            //for (int i = 2; i < 1000; i++)
            //{
            //    int remainder = 1 % i;

            //    int multiple = remainder * 10;

            //    while (!broughtDown.Contains(multiple))
            //    {
            //        broughtDown.Add(multiple);
            //        remainder = multiple % i;
            //        multiple = remainder * 10;
            //    }

            //    if(broughtDown.Count > maxRecurrenceCount)
            //    {
            //        maxRecurrenceCount = broughtDown.Count;
            //        maxRecurrenceNum = i;
            //        //Console.WriteLine("sup");
            //    }
            //    broughtDown.Clear();
            //}

            //Console.WriteLine($"Problem 26: {maxRecurrenceNum}");
            //Console.WriteLine(maxRecurrenceCount);

            #endregion

            #region Problem 27: Quadratic Primes

            //int maximumPrime = 0;
            //int maxA = 0;
            //int maxB = 0;

            //for (int a = -999; a <= 999; a++)
            //{

            //    for (int b = -1000; b <= 1000; b++)
            //    {

            //        int n = -1;
            //        bool isPrime = true;

            //        int result = 0;
            //        int consecutivePrimes = -1;

            //        // Find number of consecutive sums
            //        while(true)
            //        {

            //            consecutivePrimes++;
            //            n++;

            //            // Incredible formula
            //            result = n*n + a*n + b;
            //            int lastCheck = 0;

            //            if(result < 0)
            //            {
            //                lastCheck = -1 * result / 2;
            //            }
            //            else
            //            {
            //                lastCheck = result / 2;
            //            }

            //            // Check if prime
            //            for(int i = 2; i <= lastCheck; i++)
            //            {

            //                if(result % i == 0)
            //                {

            //                    isPrime = false;

            //                    if(consecutivePrimes > maximumPrime)
            //                    {
            //                        maximumPrime = consecutivePrimes;
            //                        maxA = a;
            //                        maxB = b;
            //                        Console.WriteLine($"A: {a}, B: {b}, N: {n}, A*B: {a * b}");
            //                    }

            //                    break;

            //                }

            //            }

            //            if (!isPrime)
            //            {

            //                break;
            //            }

            //        }


            //    }

            //}

            #endregion

            #region Problem 28: Number spiral diagonals

            long totalCount = 1;
            long surfaceCount = 0;
            long multiple = 0;

            long currentSum = 1;
            long currentNum = 1;
            long increment = 1;
            long step = 0;

            long row = 1001;

            while (surfaceCount <= (2*row + 2 * (row - 2)))
            {
                Console.WriteLine("Current sum: " + currentSum);
                //Console.WriteLine("items on surface: " + surfaceCount);
                totalCount = 1 + multiple * 8;
                surfaceCount += 8;

                step += 2;
               

                for (long i = 1; i <= surfaceCount; i += step)
                {
                    currentNum += step;
                    currentSum += currentNum;
                    //Console.WriteLine(currentNum);
                    
                }

                


                multiple++;
            }

            

            #endregion

        }

        private static List<char> ShowNumber(decimal number)
        {

            List<string> splitNumStr = new List<string>();
            splitNumStr.AddRange(number.ToString().Split('.').Select(x => x.Trim('0')));
            Console.WriteLine(splitNumStr[1]);
            
            List<char> recurrence = GetRecurrence(splitNumStr[1]);

            return recurrence;

        }

        private static List<char> GetRecurrence(string number)
        {

            List<char> returnRec = new List<char>();

            returnRec.Add(number[0]);

            for (int i = 1; i < number.Length; i++)
            {

                if(number[i] == number[i - 1])
                {
                    break;
                }
                else
                {
                    if (returnRec.Contains(number[i]))
                    {
                        break;
                    }
                    returnRec.Add(number[i]);
                }

            }

            return returnRec;
        }
    }
}
