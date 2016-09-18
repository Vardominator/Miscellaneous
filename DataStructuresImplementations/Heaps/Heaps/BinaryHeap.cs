using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    public class BinaryHeap
    {

        /// <summary>
        /// To show why BuildMaxHeap works correction, the following loop invariant is used:
        ///     At the start of each iteration of the for loop in the BuildMaxHeap method,
        ///     each node i+1, i+2,...,n is the root of a max-heap.
        ///    
        /// 
        /// The heapsort algorithm starts by using BuildMaxHeap to build a max-heap on the
        ///     input array A[1..n], where n = A.length - 1. Since the maximum element of the
        ///     array is stored at the root A[1], we can put it into its correct final position
        ///     by excahgning it with A[n]. If we now discard node n from the heap- and we can
        ///     do so by simply decrementing heapsize - we observe that the children of the 
        ///     root remain max-heaps, but the new root element might violated the max heap
        ///     property.  We need to restore the max-heap property by using MaxHeapify.
        /// 
        /// 
        /// The heapsort procedure takes time O(n lg n) because the call to BuildMaxHeap
        ///     takes O(n) and each of the n - 1 calls to MaxHeapify takes O(lg n).
        /// </summary>


        int heapSize;

        public BinaryHeap()
        {
            heapSize = 0;
        }

        private int Parent(int i)
        {
            return i / 2;
        }

        private int Left(int i)
        {
            return 2 * i;
        }

        private int Right(int i)
        {
            return 2 * i + 1;
        }


        // Building a heap
        #region
        public void BuildMaxHeap(int[] A)
        {
            heapSize = A.Length - 1;
            for (int i = A.Length / 2; i >= 0; i--)
            {
                MaxHeapify(A, i);
            }
        }

        public void BuildMinHeap(int[] A)
        {
            heapSize = A.Length - 1;
            for (int i = A.Length / 2; i >= 0; i--)
            {
                MinHeapify(A, i);
            }
        }
        #endregion

        // Maintaining heap property
        #region
        public void MaxHeapify(int[] A, int i)
        {

            int leftIndex = Left(i);
            int rightIndex = Right(i);

            int largest;


            if (leftIndex <= heapSize && A[leftIndex] > A[i])
            {
                largest = leftIndex;
            }
            else
            {
                largest = i;
            }

            if (rightIndex <= heapSize && A[rightIndex] > A[largest])
            {
                largest = rightIndex;
            }

            if (largest != i)  // This base case checks to see if we are at a leaf
            {
                int temp = A[largest];
                A[largest] = A[i];
                A[i] = temp;
                MaxHeapify(A, largest);
            }

        }

        public void MinHeapify(int[] A, int i)
        {

            int leftIndex = Left(i);
            int rightIndex = Right(i);
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
