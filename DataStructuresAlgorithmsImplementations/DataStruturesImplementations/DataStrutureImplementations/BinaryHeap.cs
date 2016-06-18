using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class BinaryHeap
    {

        /// <summary>
        /// A binary heap implementation used to sort an integer array.
        /// 
        /// 1. The Max-Heapify and Min-Heapify methods maintain the heap properties.
        ///     
        /// 2. The Build-Heap methods produce the heap from an unordered array.
        /// 
        /// 3. The HeapSort methods sort the array in place and runs in O(n ln n) time.
        /// </summary>

        private int heapSize;

        public BinaryHeap()
        {
            heapSize = 0;
        }


        private int ParentIndex(int currentIndex)
        {
            return currentIndex / 2;
        }

        private int LeftIndex(int currentIndex)
        {
            return currentIndex * 2;
        }

        private int RightIndex(int currentIndex)
        {
            return currentIndex * 2 + 1;
        }


        // Building the heap
        #region
        public void BuildMaxHeap(int[] array)
        {
            heapSize = array.Length - 1;

            for(int i = array.Length / 2; i >= 0; i--)
            {
                MaxHeapify(array, i);
            }
            
        }
        public void BuildMinHeap(int[] array)
        {
            heapSize = array.Length - 1;

            for (int i = array.Length / 2; i >= 0; i--)
            {
                MinHeapify(array, i);
            }
        }
        #endregion
        
        // Maintaining heap properties
        //      MaxHeapify: Ensure that parents are larger than children
        //      MinHeapify: Ensure that children are larger than parents
        #region
        public void MaxHeapify(int[] array, int i)
        {

            int leftIndex = LeftIndex(i);
            int rightIndex = RightIndex(i);

            int largestIndex = 0;
            
            // Check to see which node in the tree subset has the largest value
            if (leftIndex <= heapSize && array[leftIndex] > array[i])
            {
                largestIndex = leftIndex;
            }
            else
            {
                largestIndex = i;
            }
            if (rightIndex <= heapSize && array[rightIndex] > array[largestIndex])
            {
                largestIndex = rightIndex;
            }
            
            // Do not make any switches if the largest node is the parent
            if(largestIndex != i)
            {
                int temp = array[largestIndex];
                array[largestIndex] = array[i];
                array[i] = temp;
                MaxHeapify(array, largestIndex);
            }

        }
        public void MinHeapify(int[] A, int i)
        {

            int leftIndex = LeftIndex(i);
            int rightIndex = RightIndex(i);
            int smallest;

            if (leftIndex <= heapSize && A[leftIndex] < A[i])
            {
                smallest = leftIndex;
            }
            else
            {
                smallest = i;
            }

            if (rightIndex <= heapSize && A[rightIndex] < A[smallest])
            {
                smallest = rightIndex;
            }

            if (smallest != i)
            {
                int temp = A[i];
                A[i] = A[smallest];
                A[smallest] = temp;
                MinHeapify(A, smallest);
            }

        }
        #endregion

        // Heapsort
        #region
        public int[] AscendingHeapSort(int[] A)
        {

            // Ensure all parents are greater than their children
            BuildMaxHeap(A);

            for (int i = A.Length - 1; i >= 0; i--)
            {
                int temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                heapSize--;
                MaxHeapify(A, 0);
            }

            return A;

        }

        public int[] DescendingHeapSort(int[] A)
        {

            // Ensure all parents are less than their children
            BuildMinHeap(A);

            for (int i = A.Length - 1; i >= 0; i--)
            {
                int temp = A[0];
                A[0] = A[i];
                A[i] = temp;
                heapSize--;
                MinHeapify(A, 0);
            }

            return A;
        }
        #endregion



    }
}
