using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_1_through_20
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {

            #region Problem 1
            int sum = 0;
            for(int i = 0; i < 1000; i++)
            {
                if(i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            Console.WriteLine($"Problem 1: {sum}");
            #endregion


            #region Problem 2
            int first = 1;
            int second = 2;
            int maxValue = 4000000;
            int evenSum = second;
            int currentFib = 0;
            while(currentFib < maxValue)
            {
                currentFib = first + second;

                if (currentFib < maxValue)
                {
                    if(currentFib % 2 == 0)
                    {
                        evenSum += currentFib;
                    }
                }
                

                first = second;
                second = currentFib;
            }
            Console.WriteLine($"Problem 2: {evenSum}");
            #endregion


            #region Problem 3
            //long largestPrimeFactor = 0;
            //for(long i = 2; i <= 600851475143 / 2; i++)
            //{
            //    if(600851475143 % i == 0)           // Is a factor
            //    {
            //        bool isPrime = true;
            //        for(long j = 2; j <= Math.Sqrt(i); j++)
            //        {
            //            if(i % j == 0)              // Is not prime
            //            {
            //                isPrime = false;
            //                break;
            //            }
            //        }
            //        if(isPrime && i > largestPrimeFactor)
            //        {
            //            largestPrimeFactor = i;
            //            isPrime = true;
            //            Console.WriteLine(i);
            //        }

            //    }
            //}
            //Console.WriteLine($"Problem 3: {largestPrimeFactor}");
            #endregion


            #region Problem 4
            int largestPalindrome = 0;
            for (int i = 10; i <= 99; i++)
            {
                for(int j = 10; j <= 99; j++)
                {

                    int num = i * j;
                    int reverse = 0;
                    
                    while (num > 0)
                    {
                        int digit = num % 10;
                        reverse = reverse * 10 + digit;
                        num = num / 10;
                    }
                    
                    if(reverse == i * j)
                    {
                        if (reverse > largestPalindrome)
                        {
                            largestPalindrome = reverse;
                            
                        }
                    }

                }
            }
            Console.WriteLine($"Problem 4: {largestPalindrome}");
            #endregion


            #region Problem 5
            //bool isDivisible = false;
            //int number = 0;
            //while (!isDivisible)
            //{
            //    isDivisible = true;
            //    number++;
            //    for (int i = 1; i <= 20; i++)
            //    {
            //        if(number % i != 0)
            //        {
            //            isDivisible = false;
            //            break;
            //        }
            //    }
            //}
            //Console.WriteLine($"Problem 5: {number--}");
            #endregion


            #region Problem 6
            int sumOfSquares = 0;
            int squareOfSum = 0;

            for (int i = 1; i <= 100; i++)
            {
                sumOfSquares += (int)Math.Pow(i, 2);
                squareOfSum += i;
            }

            squareOfSum = (int)Math.Pow(squareOfSum, 2);

            Console.WriteLine($"Problem 6: {squareOfSum - sumOfSquares}");
            #endregion


            #region Problem 7
            //int currentNum = 3;
            //int primeCounter = 1;
            //bool isPrime = true;

            //while (primeCounter < 10001)
            //{
                
            //    for (int i = 2; i <= Math.Sqrt(currentNum); i++)
            //    {
            //        if(currentNum % i == 0)
            //        {
            //            isPrime = false;
            //            break;
            //        }
            //    }
            //    if (isPrime)
            //    {
            //        primeCounter++;
            //    }
            //    currentNum++;
            //}

            //Console.WriteLine($"Problem 7: {--currentNum}");
            #endregion


            #region Problem 8
            StreamReader sr = new StreamReader(@"F:\GitHub\Miscellaneous\ProjectEuler\Problems_1_through_20\Problems_1_through_20\projectEulerProblem8.txt");
            StringBuilder inputNumbers = new StringBuilder(sr.ReadToEnd());

            string numString = inputNumbers.ToString();

            ulong largest13DigitProduct = 0;

            for (int i = 0; i <= inputNumbers.Length - 13; i++)
            {
                ulong product = 1;
                for(int j = i; j < i + 13; j++)
                {
                    product *= ulong.Parse(numString[j].ToString());
                }

                if(product > largest13DigitProduct)
                {
                    largest13DigitProduct = product;
                }
            }
            Console.WriteLine($"Problem 8: {largest13DigitProduct}");
            #endregion


            #region Problem 9
            for (int a = 0; a < 999; a++)
            {
                for(int b = 0; b < 999; b++)
                {
                    double aSquared = Math.Pow(a, 2);

                    double bSqaured = Math.Pow(b, 2);

                    double c = Math.Pow(aSquared + bSqaured, 0.5);


                    if (aSquared + bSqaured == Math.Pow(c, 2))
                    {
                        if(a + b + c == 1000 && a < b && b < c)
                        {
                            Console.WriteLine($"Problem 9: {a},{b},{c}; {a * b * c}");
                        }
                    }

                }

            }
            #endregion


            #region Problem 10
            long primeSum = 0;
            long currentPrime = 2;
            bool isPrime = true;

            while(currentPrime < 2000000)
            {
                isPrime = true;
                for (int i = 2; i <= Math.Sqrt(currentPrime); i++)
                {
                    if(currentPrime % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                {
                    primeSum += currentPrime;
                    isPrime = false;
                    Console.WriteLine(currentPrime);
                }
                
                currentPrime++;
            }

            Console.WriteLine($"Problem 10: {primeSum}");
            #endregion

        }
    }
}
