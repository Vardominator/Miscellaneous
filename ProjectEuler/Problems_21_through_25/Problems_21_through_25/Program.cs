using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problems_21_through_25
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 21: Amicable numbers

            int amicableSum = 0;

            HashSet<int> amicableNumbers = new HashSet<int>();

            for (int i = 1; i < 10000; i++)
            {
                int a = i;

                int b = amicable(a);

                if (a != b && amicable(b) == a)
                {
                    amicableNumbers.Add(a);
                    amicableNumbers.Add(b);
                }

            }

            foreach (int a in amicableNumbers)
            {
                amicableSum += a;
            }

            Console.WriteLine($"Problem 21: {amicableSum}");
            #endregion


            #region Problem 22: Names scores

            StreamReader sr = new StreamReader(@"C:\Users\barse\Desktop\Github\Miscellaneous\ProjectEuler\Problems_21_through_25\Problems_21_through_25\names.txt");

            List<string> names = new List<string>();
            int total = 0;

            names.AddRange(sr.ReadLine().Split(',').Select(x => x.Trim('"')));
            names.Sort();

            for (int i = 0; i < names.Count; i++)
            {

                string name = names[i];
                int currentTotal = 0;
                
                for(int j = 0; j < name.Length; j++)
                {
                    currentTotal += name[j] - 64;
                }

                currentTotal *= (i + 1);

                total += currentTotal;

            }
            Console.WriteLine($"Problem 22: {total}");
            #endregion

        }


        // Helper for Problem 21
        public static int amicable(int number)
        {

            int divisibleSum = 0;

            for (int i = 1; i <= number/2; i++)
            {
                if(number % i == 0)
                {
                    divisibleSum += i;
                }
            }

            return divisibleSum;

        }

        // Helper for Problem 22


    }
}
