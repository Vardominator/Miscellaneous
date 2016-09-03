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
            double crazy = Math.Pow(2, 1000);
            string crazyStr = crazy.ToString("0." + new string('#', 339));

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(Math.Pow(2, i));
            }           
            

            #endregion

        }


    }

}
