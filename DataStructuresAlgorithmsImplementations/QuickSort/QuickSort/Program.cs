using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
{
    class Program
    {

        /// <summary>
        /// 
        /// QuickSort is a divide-and-conquer sorting algorithm that uses a partition point
        /// to splite an array into two parts:
        ///     1. The left part: all of the elements that are lower in value than the pivot point
        ///     2. The right part: all of the values that are higher in value than the pivot point
        /// 
        /// 
        /// Worst-case partitioning occurs when the partitioning routine reduces one subproblem
        ///     with n-1 elements and one with 0 elements.  This creates a O(n^2) running time,
        ///     and it usually occurs when the array is already completely sorted. In this case,
        ///     insertion sort runs at O(n) time. 
        ///     
        /// 
        /// Best-case partitioning occurs when balanced subarrays are produces
        /// 
        /// 
        /// Average-case paritioning is much closer to the best-case than the worst-case, making
        /// quicksort a go-to choice in many cases.
        /// 
        /// 
        /// Randomized QuickSort:
        ///     Using random sampling ensures that pivot element is equally likely to be any of
        ///     the r - p + 1 elements in the subarray.  Because we choose the pivot element, we
        ///     expect the split of the input array to be reasonably well balanced on average.
        ///     A non-random partition is a dangerous scenario when dealing with a sorted or
        ///     semi-sorted array as the partitioning routine produces a subproblem with n - 1
        ///     elements and 0 elements.
        /// 
        /// </summary>
        
        static void Main(string[] args)
        {

            int[] testArray = { 20, 15, 2, 7, 25, 8, 0, 2, 3, 90, 12 };

            RandomizedQuickSort(testArray, 0, testArray.Length - 1);
            //QuickSort(testArray, 0, testArray.Length - 1);

            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }

            Console.ReadKey();

        }

        public static void QuickSort(int[] A, int p, int r)
        {
            if(A.Length == 0 || A == null)
            {
                throw new NullReferenceException("Input array is invalid.");
            }
            else if (p < r)
            {
                int q = Partition(A, p, r);
                QuickSort(A, p, q - 1);
                QuickSort(A, q + 1, r);
            }
        }

        public static int Partition(int[] A, int p, int r)
        {

            int pivot = A[r];                           // Set the pivot element
            int lPartition = p - 1;                     // Start the left partition point at the left the array
            int rPartition = p;                         // Right partition not yet set
            int temp = 0;                               // Temporary variable used to swap
            
            // Starting from the front of the array up to the second to last element
            for (rPartition = p; rPartition < r; rPartition++)
            {
                if (A[rPartition] <= pivot)              // Check to see if the right partition is less than or equal to the pivot element
                {
                    lPartition++;                        // If so, increment the left partition

                    temp = A[lPartition];                // and swap the current element with the with the element at the new left partition
                    A[lPartition] = A[rPartition];
                    A[rPartition] = temp;
                }
            }

            temp = A[lPartition + 1];               // Swap the left partition element with the pivot
            A[lPartition + 1] = A[r];
            A[r] = temp;

            return lPartition + 1;

        }


        public static void RandomizedQuickSort(int[] A, int p, int r)
        {
            if (A.Length == 0 || A == null)
            {
                throw new NullReferenceException("Input array is invalid.");
            }
            else if (p < r)
            {
                int q = RandomizedPartition(A, p, r);
                RandomizedQuickSort(A, p, q - 1);
                RandomizedQuickSort(A, q + 1, r);
            }

        }

        public static int RandomizedPartition(int[] A, int p, int r)
        {

            Random rand = new Random();
            int newPivotPoint = rand.Next(p, r + 1);

            int temp = A[newPivotPoint];
            A[newPivotPoint] = A[r];
            A[r] = temp;

            return Partition(A, p, r);

        }

    }
}
