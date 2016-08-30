using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            //int num = 25;
            //StringBuilder sb = new StringBuilder();
            //while(num > 1)
            //{
            //    for (int i = 9; i > 1; i--)
            //    {

            //        while (num % i == 0 && num > 1)
            //        {
            //            num /= i;
            //            sb.Append(i);
            //        }

            //    }
            //}

            //Console.WriteLine(sb.ToString());
            #endregion


            #region Problem 17
            Dictionary<int, string> digits = new Dictionary<int, string>()
            {
                {1, "one" }, {2, "two"}, {3, "three" }, {4, "four" }, {5, "five" },
                {6, "six" }, {7, "seven" }, {8, "eight" }, {9, "nine" }
            };

            Dictionary<int, string> tens = new Dictionary<int, string>()
            {
                {1, "ten" },{2, "twenty" }, {3, "thirty" }, {4, "forty" }, {5, "fifty" },
                {6, "sixty" }, {7, "seventy" }, {8, "eighty" }, {9, "ninety" }
            };

            Dictionary<int, string> teens = new Dictionary<int, string>()
            {
                {13, "thirteen" }, {14,"fourteen" }, {15,"fifteen" }, {16, "sixteen" },
                {17, "seventeen" }, {18, "eighteen" }, {19, "nineteen" }
            };

            Dictionary<int, string> unique = new Dictionary<int, string>()
            {
                {10, "ten" }, {11, "eleven" }, {12, "twelve" }
            };


            StringBuilder sb = new StringBuilder();

            int totalLength = 0;
            int upTo = 5;

            for (int i = 1; i <= upTo; i++)
            {
                int number = i;
                int digit;


                if (number >= 1 && number <= 9)
                {
                    sb.Append(digits[number]);
                }
                else if (number >= 10 && number <= 12)
                {
                    sb.Append(unique[number]);
                }
                else if (number >= 13 && number <= 19)
                {
                    sb.Append(teens[number]);
                }
                else
                {
                    digit = number / 1000;
                    
                    if (digit != 0)
                    {
                        //Console.Write(digits[digit] + " thousand ");
                        sb.Append(digits[digit] + "thousand");
                    }
                    number = number % 1000;

                    digit = number / 100;
                    
                    if (digit != 0)
                    {
                        //Console.Write(digits[digit] + " hundred ");
                        sb.Append(digits[digit] + "hundred");
                    }

                    number = number % 100;

                    digit = number / 10;
                    
                    if (digit != 0)
                    {

                        if (sb.Length > 0)
                        {
                            sb.Append("and");
                        }

                        if (number >= 20)
                        {

                            sb.Append(tens[digit]);

                            number = number % 10;

                            if (number > 0)
                            {
                                sb.Append(digits[number]);
                            }

                        }
                        else if (number >= 13 && number <= 19)
                        {
                            sb.Append(teens[number]);
                        }
                        else if(number >= 10 && number <= 12)
                        {
                            sb.Append(unique[number]);
                        }
                    }
                    else if(number > 0)
                    {
                        sb.Append("and" + digits[number]);
                    }
                }

                //Console.WriteLine(sb.ToString());
                totalLength += sb.Length;
                sb.Clear();
               // Console.WriteLine();
            }
            Console.WriteLine($"Problem 17: {totalLength}");
            #endregion

            #region Problem 18

            StreamReader pyramid = new StreamReader(@"C:\Users\barse\Desktop\Github\Miscellaneous\ProjectEuler\Problems_11_through_20\Problems_11_through_20\problem18.txt");

            List<List<int>> pyramidGrid = new List<List<int>>();

            while (!pyramid.EndOfStream)
            {
                string currentLine = pyramid.ReadLine();



            }

       

            #endregion

        }

    }

}
