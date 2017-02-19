using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrassenAlgorithm
{
    class Program
    {

        static void Main(string[] args)
        {

            int[,] TestM = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            int[,] TestM2 = { { 6, 2, 5, 1 }, { 9, 2, 0, 1 }, { 1, 5, 3, 9 }, { 7, 2, 1, 9 } };

            int n = TestM.GetLength(0);

            int[,] subTestM = SubMatrix(TestM, 0, 0);


            int[,] A = { { 1, 3, 5}, { 7, 5, 4 }, { 9, 3, 1 } };
            int[,] B = { { 6, 8, 3}, { 4, 2, 1 }, { 3, 5, 0 } };

            int[,] C = SquareMatrixMultiply(TestM, TestM2);


            for (int i = 0; i < C.GetLength(0); i++)
            {
                for (int j = 0; j < C.GetLength(0); j++)
                {
                    Console.Write(C[i, j] + " ");
                }
                Console.WriteLine();
            }

        }
        
        public static int[,] SquareMatrixMultiply(int[,] A, int[,] B)
        {
            // Length of Rows
            int n = A.GetLength(0);

            // Resulting matrix
            int[,] C = new int[n, n];

            if (n == 2)
            {
                int[] P = PVals(A, B);
                C[0, 0] = P[4] + P[3] - P[1] + P[5];
                C[0, 1] = P[0] + P[1];
                C[1, 0] = P[2] + P[3];
                C[1, 1] = P[4] + P[0] - P[2] - P[6];

                return C;
            }
            else
            {

                int[,] A00 = SubMatrix(A, 0, 0);
                int[,] B00 = SubMatrix(B, 0, 0);
                int[,] A01 = SubMatrix(A, 0, n - n / 2);
                int[,] B01 = SubMatrix(B, 0, n - n / 2);
                int[,] A10 = SubMatrix(A, n / 2, 0);
                int[,] B10 = SubMatrix(B, n / 2, 0);
                int[,] A11 = SubMatrix(A, n / 2, n / 2);
                int[,] B11 = SubMatrix(B, n / 2, n / 2);

                int[,] C00 = AddMatrices(SquareMatrixMultiply(A00, B00), 
                                            SquareMatrixMultiply(A01, B10));
                
                int[,] C01 = AddMatrices(SquareMatrixMultiply(A00, B01),
                                            SquareMatrixMultiply(A01, B11));

                int[,] C10 = AddMatrices(SquareMatrixMultiply(A10, B00),
                                            SquareMatrixMultiply(A11, B10));

                int[,] C11 = AddMatrices(SquareMatrixMultiply(A10, B01),
                                            SquareMatrixMultiply(A11, B11));

                return CombineMatrices(C00, C01, C10, C11);
            }

        }

        public static int[,] CombineMatrices(int[,] C00, int[,] C01, int[,] C10, int[,] C11)
        {
            int n = C00.GetLength(0) * 2;
            int[,] C = new int[n, n];

            for(int i = 0; i < n / 2; i++)
            {
                for(int j = 0; j < n / 2; j++)
                {
                    C[i, j] = C00[i, j];
                }
            }

            for(int i = 0; i < n / 2; i++)
            {
                for(int j = n / 2; j < n; j++)
                {
                    C[i, j] = C01[i, j - n / 2];
                }
            }

            for (int i = n / 2; i < n; i++)
            {
                for (int j = 0; j < n / 2; j++)
                {
                    C[i, j] = C01[i - n / 2, j];
                }
            }

            for (int i = n / 2; i < n; i++)
            {
                for (int j = n / 2; j < n; j++)
                {
                    C[i, j] = C01[i - n / 2, j - n / 2];
                }
            }

            return C;

        }

        public static int[,] AddMatrices(int[, ] A, int[, ] B)
        {
            int n = A.GetLength(0);
            int[,] C = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    C[i, j] = A[i, j] + B[i, j];
                }
            }

            return C;
        }

        public static int[,] SubMatrix(int[, ] M, int x, int y)
        {

            int n = M.GetLength(0) / 2;
            int[,] subM = new int[n, n];

            for(int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    subM[i, j] = M[i + x, j + y];
                }
            }

            return subM;

        }

        public static int[] PVals(int[,] A, int[,] B)
        {
            int[] S = SMatrices(A, B);

            int[] P = new int[7];

            P[0] = A[0, 0] * S[0];
            P[1] = S[1] * B[1, 1];
            P[2] = S[2] * B[0, 0];
            P[3] = A[1, 1] * S[3];
            P[4] = S[4] * S[5];
            P[5] = S[6] * S[7];
            P[6] = S[8] * S[9];

            return P;
        }

        public static int[] SMatrices(int[,] A, int[,] B)
        {
            int[] S = new int[10];

            S[0] = B[0, 1] - B[1, 1];
            S[1] = A[0, 0] + A[0, 1];
            S[2] = A[1, 0] + A[1, 1];
            S[3] = B[1, 0] - B[0, 0];
            S[4] = A[0, 0] + A[1, 1];
            S[5] = B[0, 0] + B[1, 1];
            S[6] = A[0, 1] - A[1, 1];
            S[7] = B[1, 0] + B[1, 1];
            S[8] = A[0, 0] - A[1, 0];
            S[9] = B[0, 0] + B[0, 1];

            return S;
        }

    }
}
