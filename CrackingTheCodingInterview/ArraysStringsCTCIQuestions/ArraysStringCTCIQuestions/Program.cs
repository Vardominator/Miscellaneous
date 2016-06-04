using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysStringsCTCIQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            //string testString = "people";
            //string testString2 = "table";
            //string testString3 = "apple";

            //Console.WriteLine(isUnique(testString));
            //Console.WriteLine(isUnique(testString2));
            //Console.WriteLine(isUnique(testString3));

            //Console.WriteLine("\n");

            //string testPermute = "12345";
            //string testPermute2 = "45123";
            //string testPermute3 = "43512";

            //Console.WriteLine("\n");

            string inString = "Mr John Smith   ";
            string urlString = URLify(inString, 13);
            Console.WriteLine(urlString);

            Console.ReadKey();

        }


        // Problem 1.1
        public static bool isUnique(string str)
        {
            // Complexity: O(n)
            
            char[] cArr = str.ToCharArray();

            Dictionary<char, char> charDict = new Dictionary<char, char>();

            for (int i = 0; i < cArr.Length; i++)
            {
                if (charDict.ContainsKey(cArr[i]))
                {
                    return false;
                }
                else
                {
                    charDict.Add(cArr[i], cArr[i]);
                }
            }

            return true;
        }

        public static bool isUniqueAlt(string str)
        {
            if(str.Length > 26)
            {
                return false;
            }

            int checker = 0;
            for(int i = 0; i < str.Length; i++)
            {
                // Get integer value
                int val = str[0] - 'a';

                // 1 << val creates an integer value that has all bits zero
                // except for the valth bit. If the position val in checker
                // is already set, then this evaluates to a nonzero value and
                // we can return false.
                if((checker & (1 << val)) > 0)
                {
                    return false;
                }

                // sets the valth bit of the checker to 1
                checker = checker | (1 << val);
                
            }

            return true;

        }

        // Problem 1.2
        public static bool checkPermute(string str1, string str2)
        {

            // Simply sort the arrays and check if they are equal

            if(str1.Length != str2.Length)
            {
                return false;
            }

            char[] strArr1 = str1.ToCharArray();
            char[] strArr2 = str2.ToCharArray();

            Array.Sort(strArr1);
            Array.Sort(strArr1);

            return strArr1.Equals(strArr2);

           
        }

        public static bool checkPermuteAlt(string str1, string str2)
        {

            // Compare the character counts of the arrays

            if(str1.Length != str2.Length)
            {
                return false;
            }

            // int array that keeps a count of the number of characters in a string
            int[] letters = new int[128];

            char[] strArr = str1.ToCharArray();

            foreach(char c in strArr)
            {
                letters[c]++;
            }

            for (int i = 0; i < str2.Length; i++)
            {
                int c = (int)str2[i];
                letters[c]--;
                if(letters[c] < 0)
                {
                    return false;
                }
            }
            return true;

        }


        // Problem 1.3
        public static string URLify(string str, int length)
        {

            // Replace all blank spaces with "%20

            int spaceCount = 0, newLength = 0;

            for(int i = 0; i < length; i++)
            {
                if(str[i] == ' ')
                {
                    spaceCount++;
                }
            }

            // Since you are replacing 
            newLength = length + spaceCount * 2;

            char[] charStr = new char[newLength];

            for(int i = length - 1; i >= 0; i--)
            {
                if (str[i] == ' ')
                {
                    charStr[newLength - 1] = '0';
                    charStr[newLength - 2] = '2';
                    charStr[newLength - 3] = '%';
                    newLength -= 3;
                }
                else
                {
                    charStr[newLength - 1] = str[i];
                    newLength -= 1;
                }
            }

            return new string(charStr);

        }
        
    }
}
