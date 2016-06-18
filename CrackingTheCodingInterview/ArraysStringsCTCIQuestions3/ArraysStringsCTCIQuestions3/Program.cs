using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysStringsCTCIQuestions3
{
    class Program
    {
        static void Main(string[] args)
        {

            int[,] testArray = { { 1, 2, 3, 4}, { 5, 6, 7, 8}, { 9, 10, 11, 12}, { 13, 14, 0, 16} };

            int width = 4;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(testArray[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }


            Console.WriteLine("Rotated matrix:");

            //RotateMatrix(testArray);

            ZeroMatrix(testArray);

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(testArray[i, j] + "\t");
                }
                Console.WriteLine();
                Console.WriteLine();
            }



            Console.WriteLine(IsSubstring("am", "damn"));
            Console.WriteLine(IsRotation("erbottlewat", "waterbottle"));
            Console.WriteLine(IsRotation("erborglewat", "waterbottle"));

            Console.ReadKey();

        }


        /// <summary>
        /// Problem 1.6: String Compression
        ///     Implement a method to perform basic string compression using the counts
        ///     of repeated characters.
        /// </summary>
        public static void RotateMatrix(int[,] matrix)
        {

            int width = matrix.Length;

            for (int i = 0; i < width/2; i++)
            {
                int bound1 = i;
                int bound2 = width - 1 - i;

                for (int j = bound1; j < bound2; j++)
                {
                    
                    int temp = matrix[bound1, j];

                    // left to top
                    matrix[bound1, j] = matrix[bound2 - j , bound1];

                    // bottom to left
                    matrix[bound2 - j, bound1] = matrix[bound2, bound2 - j];

                    // right to bottom
                    matrix[bound2, bound2 - j] = matrix[j, bound2];

                    // top to right
                    matrix[j,bound2] = temp;

                }


            }

        }

        /// <summary>
        /// Problem 1.8: Zero Matrix
        ///     Write an algorithm such that if an element in an MxN matrix is 0,
        ///     its entire row and column are set to 0.
        ///     
        /// 
        /// This particular implementation has a space complexity of O(1)
        /// 
        /// </summary>
        public static void ZeroMatrix(int[,] matrix)
        {

            bool rowHasZero = false;
            bool colHasZero = false;

            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);


            // Check if first row has any zeros
            for (int i = 0; i < width; i++)
            {
                if(matrix[0, i] == 0)
                {
                    rowHasZero = true;
                    break;
                }
            }

            // Check if first column has any zeros
            for (int j = 0; j < height; j++)
            {
                if(matrix[j, 0] == 0)
                {
                    colHasZero = true;
                    break;
                }
            }

            // Check if any other zeros exits
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if(matrix[i,j] == 0)
                    {
                        // Set the first element of the row and the column to zero
                        matrix[i, 0] = 0;
                        matrix[0, j] = 0;
                    }
                }
            }


            // Based on the fact that the first element of the row and the column are zero
            // set the rest of that row and column to zero as well
            for (int i = 1; i < height; i++)
            {
                if(matrix[0, i] == 0)
                {
                    nullifyCol(matrix, i);
                }
            }

            for(int j = 1; j < width; j++)
            {
                if(matrix[j, 0] == 0)
                {
                    nullifyRow(matrix, j);
                }
            }


            if (rowHasZero)
            {
                nullifyRow(matrix, 0);
            }
            if (colHasZero)
            {
                nullifyCol(matrix, 0);
            }

        }

        public static void nullifyRow(int[,] matrix, int row)
        {
            int height = matrix.GetLength(1);

            for (int i = 0; i < height; i++)
            {
                matrix[row, i] = 0;
            }
        }
        public static void nullifyCol(int[,] matrix, int col)
        {
            int width = matrix.GetLength(0);

            for (int j = 0; j < width; j++)
            {
                matrix[j, col] = 0;
            }
        }



        /// <summary>
        /// 
        /// Problem 1.9: String Rotation
        ///     Write a method which checks if one word is a substring of another.
        ///     Given 2 inputs, is the second string a rotation of the other
        ///     string?
        /// 
        /// </summary>
        public static bool IsRotation(string str1, string str2)
        {

            // Checks to see if the str1 is a rotation of str2\
            StringBuilder newSB = new StringBuilder(str1);
            newSB.Append(str1);

            if(str1.Length != str2.Length)
            {
                return false;
            }

            if((IsSubstring(str2, newSB.ToString())))
            {
                return true;
            }

            return false;

        }

        public static bool IsSubstring(string str1, string str2)
        {

            // Check to see if str1 is a substring of str2

            int str1Length = str1.Length;
            int str2Length = str2.Length;

            for (int i = 0; i < str1Length; i++)
            {

                int j = i;
                int k = 0;

                while(str2[j] == str1[k])
                {
                    j++;
                    k++;

                    if(k == str1Length)
                    {
                        return true;
                    }
                }
                
            }
            
            return false;
        }


    }
}
