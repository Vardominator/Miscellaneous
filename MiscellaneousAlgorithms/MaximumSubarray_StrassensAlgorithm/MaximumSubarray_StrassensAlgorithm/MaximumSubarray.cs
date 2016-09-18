using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumSubarray_StrassensAlgorithm
{
    public static class MaximumSubarray
    {
        public static Tuple<int, int, int> FindMaximumSubarray(int[] A, int low, int high)
        {
            if (high == low)
            {
                return Tuple.Create(low, high, A[low]);
            }
            else
            {
                int mid = (low + high) / 2;

                // left-low, left-high, left-sum
                var leftStuff = FindMaximumSubarray(A, low, mid);
                // right-low, right-high, right-sum
                var rightStuff = FindMaximumSubarray(A, mid + 1, high);
                // cross-low, cross-high, cross-sum
                var crossStuff = MaximumCrossing(A, low, mid, high);

                if (leftStuff.Item3 > rightStuff.Item3 && leftStuff.Item3 > crossStuff.Item3)
                {
                    return leftStuff;
                }
                else if (rightStuff.Item3 > leftStuff.Item3 && rightStuff.Item3 > crossStuff.Item3)
                {
                    return rightStuff;
                }
                else
                {
                    return crossStuff;
                }
            }
        }

        static Tuple<int, int, int> MaximumCrossing(int[] A, int low, int mid, int high)
        {
            int leftSum = int.MinValue;
            int sum = 0;
            int maxLeft = mid;

            for (int i = mid; i >= low; i--)
            {
                sum += A[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            int rightSum = int.MinValue;
            sum = 0;
            int maxRight = mid + 1;

            for (int j = mid + 1; j <= high; j++)
            {
                sum += A[j];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = j;
                }
            }
            return Tuple.Create(maxLeft, maxRight, leftSum + rightSum);
        }
    }
}