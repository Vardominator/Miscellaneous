using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {

        static void Main(string[] args)
        {

            Random rand = new Random();

            int[] testArray = new int[10];  
            int[] temporary = new int[10];      // Used to store subarrays

            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = rand.Next(100);
            }

            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }

            Console.WriteLine();

            MergeSort(testArray, temporary, 0, testArray.Length - 1);
            //QuickSort(testArray, 0, testArray.Length - 1);


            for (int i = 0; i < testArray.Length; i++)
            {
                Console.WriteLine(testArray[i]);
            }
            
        }


        // Merge sort
        #region
        public static void MergeSort(int[] array, int[] temporary, int min, int max)
        {
        
            if(min < max)
            {

                int middle = (min + max) / 2;

                MergeSort(array, temporary, min, middle);
                MergeSort(array, temporary, middle + 1, max);

                Merge(array, temporary, min, middle, max);
                
            }
                
        }
        public static void Merge(int[] array, int[] temporary, int min, int middle, int max)
        {

            for (int i = min; i <= max; i++)
            {
                temporary[i] = array[i];
            }


            int left = min;
            int right = middle + 1;
            int current = left;

            while(left <= middle && right <= max)
            {
                if(temporary[left] <= temporary[right])
                {
                    array[current] = temporary[left];
                    left++;
                }
                else
                {
                    array[current] = temporary[right];
                    right++;
                }
                current++;
            }

            while(left <= middle)
            {
                array[current] = temporary[left];
                left++;
                current++;
            }
            
            while(right <= max)
            {
                array[current] = temporary[right];
                right++;
                current++;

            }
            
        }
        #endregion
        /// <summary>
        /// Merge sort is divide and conquer algorithm that takes O(n log n) time in the best
        ///     average, and worst times.  Its space complexity is O(n).
        /// </summary>


        // Quicksort
        #region
        public static void QuickSort(int[] array, int left, int right)
        {

            int splitIndex = Partition(array, left, right);

            // If there is a partition point between left and right (the subarray is not sorted)
            if(left < splitIndex - 1)
            {
                QuickSort(array, left, splitIndex - 1);
            }
            if(splitIndex < right)
            {
                QuickSort(array, splitIndex, right);

            }

        }
        public static int Partition(int[] array, int left, int right)
        {

            int pivot = array[(left + right) / 2];

            while(left <= right)
            {
                while(array[left] < pivot)
                {
                    left++;
                }
                while(array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(array, left, right);
                    left++;
                    right--;
                }
            }

            return left;
            
        }
        #endregion
        /// <summary>
        /// Quick sort is a divide and conquere algorithm that uses partition to sort an array.
        ///     It takes O(n log n) time in the best and averge case.  It takes O(n^2) in the
        ///     worst case.  Its space complexity is typically O(log n).
        /// </summary>

        public static void Swap(int[] array, int first, int second)
        {
            int temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }

    }
}
