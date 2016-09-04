using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problems_11_through_20
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 11

            //// File Loading
            //StreamReader fileStream = new StreamReader(@"C:\Users\barse\Desktop\Github\Miscellaneous\ProjectEuler\Problems_11_through_20\Problems_11_through_20\grid.txt");
            //long[,] grid = new long[20, 20];
            //int currentRow = 0;

            //string[] row;
            //string currentLine = fileStream.ReadLine();

            //while (!fileStream.EndOfStream)
            //{
            //    currentLine = currentLine.Trim(new char[] { '\n', '\r' });
            //    row = currentLine.Split(' ');

            //    for (int i = 0; i < 20; i++)
            //    {
            //        grid[currentRow, i] = int.Parse(row[i]);
            //    }

            //    currentRow++;
            //    currentLine = fileStream.ReadLine();
            //}

            //row = currentLine.Split(' ');

            //for (int i = 0; i < 20; i++)
            //{
            //    grid[currentRow, i] = int.Parse(row[i]);
            //}

            ////Algorithm
            //long maxQuadProduct = 0;

            //long[] adjacentProducts = { 1, 1, 1, 1 };

            //for (int i = 0; i < 20; i++)
            //{
            //    for (int j = 0; j < 20; j++)
            //    {
            //        for (int r = 0; r < 4; r++)
            //        {
            //            if (i <= 16)
            //            {
            //                adjacentProducts[0] *= grid[r + i, j];
            //            }
            //            if (j <= 16)
            //            {
            //                adjacentProducts[1] *= grid[i, r + j];
            //            } 
            //            if (i <= 16 && j <= 16)
            //            {
            //                adjacentProducts[2] *= grid[r + i, r + j];
            //            }
            //            if(j >= 3 && j <= 16 && i <= 16)
            //            {
            //                adjacentProducts[3] *= grid[r + i, j - r];
            //            }

            //        }

            //        for (int m = 0; m < adjacentProducts.Length; m++)
            //        {
            //            if (adjacentProducts[m] > maxQuadProduct)
            //            {
            //                maxQuadProduct = adjacentProducts[m];
            //            }
            //            adjacentProducts[m] = 1;
            //        }
            //    }
            //}

            //Console.WriteLine($"Problem 11: {maxQuadProduct}");
            #endregion


            #region Problem 12


            #endregion


            #region Problem 15

            //ulong pathCount = 0;

            //int x = 21;
            //int y = 21;


            //ulong[,] paths = new ulong[x, y];

<<<<<<< HEAD

            //for (int i = 0; i < x; i++)
            //{
            //    paths[i, 0] = 1;
            //}
            //for (int j = 0; j < y; j++)
            //{
            //    paths[0, j] = 1;
            //}

            //for (int i = 1; i < x; i++)
            //{
            //    for (int j = 1; j < y; j++)
            //    {
            //        paths[i, j] = paths[i - 1, j] + paths[i, j - 1];
            //    }
            //}

            //Console.WriteLine($"Problem 15: {paths[x - 1, y - 1]}");
=======

            //for (int i = 0; i < x; i++)
            //{
            //    paths[i, 0] = 1;
            //}
            //for (int j = 0; j < y; j++)
            //{
            //    paths[0, j] = 1;
            //}

            //for (int i = 1; i < x; i++)
            //{
            //    for (int j = 1; j < y; j++)
            //    {
            //        paths[i, j] = paths[i - 1, j] + paths[i, j - 1];
            //    }
            //}

            //Console.WriteLine($"Problem 15: {paths[x - 1, y - 1]}");

            #endregion


            #region Problem 16
            BigInteger num = BigInteger.Pow(new BigInteger(2), 1000);

            int sum16 = 0;

            string numStr = num.ToString();

            for (int i = 0; i < numStr.Length; i++)
            {

                sum16 += int.Parse(numStr[i].ToString());

            }

            Console.WriteLine($"Problem 16: {sum16}");

            #endregion


            #region Problem 17
            //Dictionary<int, string> digits = new Dictionary<int, string>()
            //{
            //    {1, "one" }, {2, "two"}, {3, "three" }, {4, "four" }, {5, "five" },
            //    {6, "six" }, {7, "seven" }, {8, "eight" }, {9, "nine" }
            //};

            //Dictionary<int, string> tens = new Dictionary<int, string>()
            //{
            //    {1, "ten" },{2, "twenty" }, {3, "thirty" }, {4, "forty" }, {5, "fifty" },
            //    {6, "sixty" }, {7, "seventy" }, {8, "eighty" }, {9, "ninety" }
            //};

            //Dictionary<int, string> teens = new Dictionary<int, string>()
            //{
            //    {13, "thirteen" }, {14,"fourteen" }, {15,"fifteen" }, {16, "sixteen" },
            //    {17, "seventeen" }, {18, "eighteen" }, {19, "nineteen" }
            //};

            //Dictionary<int, string> unique = new Dictionary<int, string>()
            //{
            //    {10, "ten" }, {11, "eleven" }, {12, "twelve" }
            //};


            //StringBuilder sb = new StringBuilder();

            //int totalLength = 0;
            //int upTo = 5;

            //for (int i = 1; i <= upTo; i++)
            //{
            //    int number = i;
            //    int digit;


            //    if (number >= 1 && number <= 9)
            //    {
            //        sb.Append(digits[number]);
            //    }
            //    else if (number >= 10 && number <= 12)
            //    {
            //        sb.Append(unique[number]);
            //    }
            //    else if (number >= 13 && number <= 19)
            //    {
            //        sb.Append(teens[number]);
            //    }
            //    else
            //    {
            //        digit = number / 1000;

            //        if (digit != 0)
            //        {
            //            //Console.Write(digits[digit] + " thousand ");
            //            sb.Append(digits[digit] + "thousand");
            //        }
            //        number = number % 1000;

            //        digit = number / 100;

            //        if (digit != 0)
            //        {
            //            //Console.Write(digits[digit] + " hundred ");
            //            sb.Append(digits[digit] + "hundred");
            //        }

            //        number = number % 100;

            //        digit = number / 10;

            //        if (digit != 0)
            //        {

            //            if (sb.Length > 0)
            //            {
            //                sb.Append("and");
            //            }

            //            if (number >= 20)
            //            {

            //                sb.Append(tens[digit]);

            //                number = number % 10;

            //                if (number > 0)
            //                {
            //                    sb.Append(digits[number]);
            //                }

            //            }
            //            else if (number >= 13 && number <= 19)
            //            {
            //                sb.Append(teens[number]);
            //            }
            //            else if(number >= 10 && number <= 12)
            //            {
            //                sb.Append(unique[number]);
            //            }
            //        }
            //        else if(number > 0)
            //        {
            //            sb.Append("and" + digits[number]);
            //        }
            //    }

            //    //Console.WriteLine(sb.ToString());
            //    totalLength += sb.Length;
            //    sb.Clear();
            //   // Console.WriteLine();
            //}
            //Console.WriteLine($"Problem 17: {totalLength}");
            #endregion

            #region Problem 18

            // StreamReader pyramid = new StreamReader(@"C:\Users\barse\Desktop\Github\Miscellaneous\ProjectEuler\Problems_11_through_20\Problems_11_through_20\triangle.txt");

            // List<List<int>> pyramidGrid = new List<List<int>>();

            // // Load file
            // int i = 0;
            // while (!pyramid.EndOfStream)
            // {
            //     string currentLine = pyramid.ReadLine();
            //     string[] strNums = currentLine.Split(' ');

            //     pyramidGrid.Add(new List<int>());

            //     for (int j = 0; j < strNums.Length; j++)
            //     {
            //         pyramidGrid[i].Add(int.Parse(strNums[j]));
            //         Console.Write(pyramidGrid[i][j] + " ");
            //     }
            //     Console.WriteLine();
            //     i++;
            // }
            // Console.WriteLine();Console.WriteLine();
            // List<List<int>> pathSums = new List<List<int>>();

            // pathSums.Add(new List<int>());
            // pathSums[0].Add(pyramidGrid[0][0]);
            //// Console.WriteLine(pathSums[0][0]);



            // for (int m = 1; m < pyramidGrid.Count; m++)
            // {
            //     pathSums.Add(new List<int>());

            //     for (int n = 0; n < pyramidGrid[m].Count; n++)
            //     {
            //         //Console.Write(pyramidGrid[m][n] + " ");
            //         if(n == 0)
            //         {
            //             pathSums[m].Add(pyramidGrid[m][0] + pyramidGrid[m - 1][0]);
            //             pyramidGrid[m][n] = pathSums[m][n];
            //         }
            //         else if(n == pyramidGrid[m].Count - 1)
            //         {
            //             pathSums[m].Add(pyramidGrid[m][n] + pyramidGrid[m - 1][n - 1]);
            //         }
            //         else
            //         {
            //             int leftSum = pyramidGrid[m][n] + pyramidGrid[m - 1][n - 1];
            //             int rightSum = pyramidGrid[m][n] + pyramidGrid[m - 1][n];

            //             if (leftSum >= rightSum)
            //             {
            //                 pathSums[m].Add(leftSum);
            //             }
            //             else
            //             {
            //                 pathSums[m].Add(rightSum);
            //             }
            //         }
            //         pyramidGrid[m][n] = pathSums[m][n];
            //         Console.Write(pathSums[m][n] + " ");
            //     }
            //     Console.WriteLine();

            // }

            // int maxValue = 0;
            // for (int k = 0; k < pyramidGrid[pyramidGrid.Count - 1].Count; k++)
            // {
            //     if (pyramidGrid[pyramidGrid.Count - 1][k] > maxValue)
            //     {
            //         maxValue = pyramidGrid[pyramidGrid.Count - 1][k];
            //     }

            // }
            // Console.WriteLine($"Problem 18: {maxValue}");
            #endregion


            #region Problem 19
            int dayPosition = -1;
            int[] weekDays = { 1, 2, 3, 4, 5, 6, 7 };
            int currentYear = 2012;
            int sundaysOnTheFirst = 0;

            Dictionary<int, int> daysPerMonth = new Dictionary<int, int>();

            for (int i = 1900; i <= 2000; i++)
            {

                ConstructYear(i, daysPerMonth);
                for (int j = 1; j <= 12; j++)
                {
                    int daysInMonth = daysPerMonth[j];

                    if (dayPosition == 7 && i != 1900)
                    {
                        sundaysOnTheFirst++;
                    }

                    for (int k = 0; k < daysInMonth; k++)
                    {
                        dayPosition++;
                        if(dayPosition == 8)
                        {
                            dayPosition = 1;
                        }
                        Console.WriteLine(dayPosition);
                    }
                    
                }

                //Console.WriteLine();
                daysPerMonth.Clear();
            }
            Console.WriteLine($"Problem 19: {sundaysOnTheFirst}");
            #endregion

>>>>>>> 11d2cee5c8ec61af5d7cdbbc16125183c9c8379d

            #region Problem 20

<<<<<<< HEAD

            #region Problem 16
            double crazy = Math.Pow(2, 1000);
            string crazyStr = crazy.ToString("0." + new string('#', 339));

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(Math.Pow(2, i));
            }           
            

            #endregion

=======
            //Console.WriteLine(factorial(100));
            //BigInteger
            //Console.WriteLine(Math.Sqrt(2 * Math.PI * 20) * Math.Pow(20 / Math.E, 20));

            BigInteger sum = factorial(100);
            
            string sumStr = sum.ToString();

            int sumOfDigits = 0;

            for (int i = 0; i < sumStr.Length; i++)
            {
                //Console.WriteLine(sumStr[i]);
                sumOfDigits += int.Parse(sumStr[i].ToString());
            }

            Console.WriteLine($"Problem 20: {sumOfDigits}");
            #endregion

        }

        public static void ConstructYear(int year, Dictionary<int,int> daysPerMonth)
        {
            // Take care of fucking February
            if(year % 400 == 0)
            {
                daysPerMonth.Add(2, 29);
            }
            else if(year % 100 != 0)
            {
                if(year % 4 == 0)
                {
                    daysPerMonth.Add(2, 29);
                }
                else
                {
                    daysPerMonth.Add(2, 28);
                }
            }


            // September, April, June and November (30)
            daysPerMonth.Add(4, 30);
            daysPerMonth.Add(6, 30);
            daysPerMonth.Add(9, 30);
            daysPerMonth.Add(11, 30);

            // January, March, May, July, August, October, December
            for (int i = 1; i <= 12; i++)
            {
                if (!daysPerMonth.ContainsKey(i))
                {
                    daysPerMonth.Add(i, 31);
                }

            }

            
>>>>>>> 11d2cee5c8ec61af5d7cdbbc16125183c9c8379d
        }
        

<<<<<<< HEAD

=======
        public static BigInteger factorial(BigInteger n)
        {
            if(n.Equals(BigInteger.One))
            {
                return BigInteger.One;
            }

            return BigInteger.Multiply(n, factorial(BigInteger.Subtract(n, BigInteger.One)));
        }
         
>>>>>>> 11d2cee5c8ec61af5d7cdbbc16125183c9c8379d
    }

}
