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


            #region Problem 24: Lexicographic permutations

            List<int> digits = Enumerable.Range(0, 10).ToList();
            IEnumerable<List<int>> permutations = Permutate(digits);


            List<long> nums = new List<long>();

           


            foreach (var permutation in permutations)
            {

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i <= 9; i++)
                {
                    sb.Append(permutation[i]);
                    //Console.Write(permutation[i]);
                    
                }
                nums.Add(long.Parse(sb.ToString()));

            }


            nums.Sort();




            Console.WriteLine($"Problem 24 {nums[1000000 - 1]}");
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

        // Helper for Problem 24
        public static IEnumerable<List<int>> Permutate(List<int> digits)
        {

            if(digits.Count == 2)
            {
                yield return new List<int>(digits);
                yield return new List<int>{ digits[1], digits[0] };
            }

            else
            {


                foreach (var digit in digits)
                {
                    List<int> placeHolder = new List<int>(digits);
                    placeHolder.Remove(digit);

                    foreach (var list in Permutate(placeHolder))
                    {

                        list.Insert(0, digit);
                        yield return list;

                    }

                }

            }

        } 

    }
}
