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

            // File Loading
            StreamReader fileStream = new StreamReader(@"C:\Users\barse\Desktop\Github\Miscellaneous\ProjectEuler\Problems_11_through_20\Problems_11_through_20\grid.txt");
            long[,] grid = new long[20, 20];
            int currentRow = 0;

            string[] row;
            string currentLine = fileStream.ReadLine();

            while (!fileStream.EndOfStream)
            {
                currentLine = currentLine.Trim(new char[] { '\n', '\r' });
                row = currentLine.Split(' ');

                for (int i = 0; i < 20; i++)
                {
                    grid[currentRow, i] = int.Parse(row[i]);
                }

                currentRow++;
                currentLine = fileStream.ReadLine();
            }

            row = currentLine.Split(' ');

            for (int i = 0; i < 20; i++)
            {
                grid[currentRow, i] = int.Parse(row[i]);
            }

            //Algorithm
            long maxQuadProduct = 0;

            long[] adjacentProducts = { 1, 1, 1, 1 };

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    for (int r = 0; r < 4; r++)
                    {
                        if (i <= 16)
                        {
                            adjacentProducts[0] *= grid[r + i, j];
                        }
                        if (j <= 16)
                        {
                            adjacentProducts[1] *= grid[i, r + j];
                        } 
                        if (i <= 16 && j <= 16)
                        {
                            adjacentProducts[2] *= grid[r + i, r + j];
                        }
                        if(j >= 3 && j <= 16 && i <= 16)
                        {
                            adjacentProducts[3] *= grid[r + i, j - r];
                        }
                        
                    }

                    for (int m = 0; m < adjacentProducts.Length; m++)
                    {
                        if (adjacentProducts[m] > maxQuadProduct)
                        {
                            maxQuadProduct = adjacentProducts[m];
                        }
                        adjacentProducts[m] = 1;
                    }
                }
            }
            
            Console.WriteLine($"Problem 11: {maxQuadProduct}");
            #endregion

        }
    }
}
