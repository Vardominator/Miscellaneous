using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubarray_StrassensAlgorithm
{

    /// <summary>
    /// CLRS Chapter 4: Divide-and-Conquer
    /// 
    /// Algorithms Demonstrated:
    ///     1. Maximum subarray
    ///     2. 
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

            int[] testArray = { -2, -3, 4, -1, -2, 1, 5, -3 };
            Tuple<int, int, int> maxSum = MaximumSubarray.FindMaximumSubarray(testArray, 0, testArray.Length - 1);
            
        }

        // Simple example; Divide-and-conquer approach is contained with the MaximumSubarray class
        public static Tuple<int, int, int> MaxSubarray(int[] A, int start, int end)
        {
            int MaxSoFar = 0;
            int MaxEndingHere = 0;
            int MaxLeft = start, MaxRight = start;

            for (int i = start; i <= end; i++)
            {
                MaxEndingHere += A[i];
                if(MaxEndingHere < 0)
                {
                    MaxEndingHere = 0;
                    MaxLeft++;        
                }
                else if(MaxSoFar < MaxEndingHere)
                {
                    MaxSoFar = MaxEndingHere;
                    MaxRight = i;
                }
            }
            return Tuple.Create(MaxLeft, MaxRight, MaxSoFar);
        }
        

        // Elementary square-matrix multiple
        //  As we see this thanks O(n^3) time
        public static int SquareMatrixMultiple(int[,] A, int[,] B)
        {

            int rows = A.GetLength(0);
            int[,] result = new int[rows, rows];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < rows; k++)
                    {
                        result[i, j] += A[i, k] * B[k, j];
                    }

                }
            }
            return -1;
        }

        // For Strassen's algorithm we must assume that n is an exact power of 2 in each of the nxn matrices
        // The dimensions need to be integers as they are divided at each recursive step
            `

    }

}
