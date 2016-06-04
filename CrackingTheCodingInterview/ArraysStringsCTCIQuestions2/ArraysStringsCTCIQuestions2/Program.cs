using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysStringsCTCIQuestions2
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(isPalindrome("racecar"));
            //Console.WriteLine(isPalindrome("apple"));
            //Console.WriteLine(isPalindrome("Tact Coa"));


            //Console.WriteLine(oneAway("apple", "appl"));
            //Console.WriteLine(oneAway("apple", "ple"));

            Console.WriteLine(CompressString("hello"));
            Console.WriteLine(CompressString("aabcccccaaa"));

            Console.ReadKey();

        }


        // Problem 1.4: Palindrome Permutation
        public static bool isPalindrome(string str)
        {

            // I am assuming all characters are letters in the alphabet

            str = str.ToLower();

            int oddCount = 0;

            char[] charStr = str.ToCharArray();

            int[] alphabetCount = new int[26];

            foreach(char c in charStr)
            {

                int x = c - 'a';

                if(x < 26 && x >= 0)
                {

                    alphabetCount[x]++;

                    if(alphabetCount[x] % 2 == 1)
                    {
                        oddCount++;
                    }
                    else
                    {
                        oddCount--;
                    }
                    
                }

            }
            
            return oddCount <= 1;

        }



        // Problem 1.5: One Away
        public static bool oneAway(string s1, string s2)
        {

            if(Math.Abs(s1.Length - s2.Length) > 1)
            {
                return false;
            }

            string firstString = s1.Length < s2.Length ? s1 : s2;
            string secondString = s1.Length < s2.Length ? s2 : s1;

            int firstIndex = 0;
            int secondIndex = 0;

            int differenceCount = 0;

            while(firstIndex < firstString.Length && secondIndex < secondString.Length)
            {

                if(firstString[firstIndex] != secondString[secondIndex])
                {

                    differenceCount++;

                    if(differenceCount > 1)
                    {
                        return false;
                    }

                }
                
                if(s1.Length < s2.Length)
                {
                    secondIndex++;
                }
                else
                {
                    firstIndex++;
                    secondIndex++;
                }
                
            }

            return true;

        }


        // Problem 1.6: String Compression
        public static string CompressString(string str)
        {

            // Using the StringBuilder class will make this algorithm much for efficient
            // as the initial capacity can be set. Setting the initial capacity to the

            StringBuilder compressedStr = new StringBuilder("", str.Length);

            char[] strChar = str.ToCharArray();
            int currCounter = 1;
            char prevChar = strChar[0];
            compressedStr.Append(prevChar);

            for (int i = 1; i < strChar.Length; i++)
            {
                
                char currChar = strChar[i];

                if(currChar == prevChar)
                {
                    currCounter++;
                }
                else
                {
                    compressedStr.Append(currCounter);
                    prevChar = currChar;
                    compressedStr.Append(prevChar);
                    currCounter = 1;
                }

            }

            compressedStr.Append(currCounter);

            if (compressedStr.Length >= str.Length)
            {
                return str;
            }

            else
            {
                return compressedStr.ToString();
            }

        }

    }
}
