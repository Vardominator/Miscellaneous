using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problems_26_through_30
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Problem 26: Reciprocal Cycles

            
            int maxRecurrenceCount = 0;
            int maxRecurrenceNum = 0;

            List<int> broughtDown = new List<int>();

            for (int i = 2; i < 1000; i++)
            {
                int remainder = 1 % i;

                int multiple = remainder * 10;

                while (!broughtDown.Contains(multiple))
                {
                    broughtDown.Add(multiple);
                    remainder = multiple % i;
                    multiple = remainder * 10;
                }

                if(broughtDown.Count > maxRecurrenceCount)
                {
                    maxRecurrenceCount = broughtDown.Count;
                    maxRecurrenceNum = i;
                    //Console.WriteLine("sup");
                }
                broughtDown.Clear();
            }

            Console.WriteLine($"Problem 26: {maxRecurrenceNum}");
            Console.WriteLine(maxRecurrenceCount);

            #endregion

            #region Problem 27: Quadratic Primes



            #endregion

        }

        private static List<char> ShowNumber(decimal number)
        {

            List<string> splitNumStr = new List<string>();
            splitNumStr.AddRange(number.ToString().Split('.').Select(x => x.Trim('0')));
            Console.WriteLine(splitNumStr[1]);
            
            List<char> recurrence = GetRecurrence(splitNumStr[1]);

            return recurrence;

        }

        private static List<char> GetRecurrence(string number)
        {

            List<char> returnRec = new List<char>();

            returnRec.Add(number[0]);

            for (int i = 1; i < number.Length; i++)
            {

                if(number[i] == number[i - 1])
                {
                    break;
                }
                else
                {
                    if (returnRec.Contains(number[i]))
                    {
                        break;
                    }
                    returnRec.Add(number[i]);
                }

            }

            return returnRec;
        }
    }
}
