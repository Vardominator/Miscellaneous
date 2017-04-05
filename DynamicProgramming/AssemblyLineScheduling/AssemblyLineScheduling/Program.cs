using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyLineScheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            int LINES = 2;
            int STATIONS = 5;

            // station costs
            int[,] a = { { 7, 9, 3, 4, 8 }, { 8, 5, 6, 4, 5 } };

            // transfer costs
            int[,] t = { { 2, 3, 1, 3 }, { 2, 1, 2, 2 } };

            // line 1 entry and exit costs
            int e1 = 2;
            int x1 = 3;

            // line 2 entry and exit costs
            int e2 = 4;
            int x2 = 6;

            // Optimal values
            int[,] f = new int[LINES, STATIONS];

            f[0, 0] = e1 + a[0, 0];
            f[1, 0] = e2 + a[1, 0];

            for (int j = 1; j < STATIONS; j++)
            {
                f[0, j] = Math.Min(f[0, j - 1] + a[0, j], f[1, j - 1] + a[0, j]);
                f[1, j] = Math.Min(f[1, j - 1] + a[1, j], f[0, j - 1] + a[1, j]);
            }

            int optimalSolution = Math.Min(f[0, STATIONS - 1] + x1, f[1, STATIONS - 1] + x2);

            Console.WriteLine($"Optimal solution: {optimalSolution}");

        }
    }
}
