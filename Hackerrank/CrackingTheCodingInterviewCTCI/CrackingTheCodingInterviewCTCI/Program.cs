using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterviewCTCI
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region Arrays: Left Rotation

            /*
             * 
             * Given an array of n integers and a number d, perform left rotations
             * on the array. Then print the updated array as a single line of 
             * space-separated integers.
             * 
             */
             
            //string[] tokens_n = Console.ReadLine().Split(' ');
            //int n = Convert.ToInt32(tokens_n[0]);
            //int k = Convert.ToInt32(tokens_n[1]);
            //string[] a_temp = Console.ReadLine().Split(' ');
            //int[] a = Array.ConvertAll(a_temp, Int32.Parse);

            //if (k > n)
            //{
            //    k = k % n;
            //}

            //for (int i = k; i < a.Length; i++)
            //{
            //    Console.Write(a[i] + " ");
            //}
            //for (int i = 0; i < k; i++)
            //{
            //    Console.Write(a[i] + " ");
            //}

            #endregion

            #region Strings: Making Anagrams

            string word = "bacdc";
            string word2 = "dcbad";

            int[] counts1 = new int[26];
            int[] counts2 = new int[26];
            
            for (int i = 0; i < word.Length; i++)
            {
                counts1[word[i] - 97]++;
                
            }

            for (int j = 0; j < word2.Length; j++)
            {
                counts2[word2[j] - 97]++;
            }

            Console.WriteLine(DeleteCount(counts1, counts2));

            #endregion


        }

        // Helper methods
        public static bool IsAnagram(int[] counts1, int[] counts2)
        {
            for (int i = 0; i < counts1.Length; i++)
            {
                
                if(counts1[i] - counts2[i] != 0)
                {

                    return false;
                }

            }
            return true;
        }

        public static int DeleteCount(int[] counts1, int[] counts2)
        {
            int counts = 0;

            for (int i = 0; i < counts1.Length; i++)
            {
                //Console.WriteLine(counts1[i] - counts2[i]);
                if (counts1[i] - counts2[i] != 0)
                {
                    counts += Math.Abs(counts1[i] - counts2[i]);
                }
            }

            return counts;

        }


    }
}
