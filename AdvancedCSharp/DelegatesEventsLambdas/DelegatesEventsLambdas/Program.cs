using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas
{
    class Program
    {

        // Part 1: Intro to delegates
        delegate string MyDelegate(string s);

        // Part 2: Parameterizing functions
        delegate bool NumOperation(int n);
        static bool LessThanFive(int n) { return n < 5; }
        static bool LessThanTen(int n) { return n < 10; }
        static bool GreaterThanThirteen(int n) { return n > 13; }

        // Part 3: Anonymous functions
        delegate void CountIt();
        delegate void CountIt2(int n);


        // Part 4: Lambdas
        delegate int Count(int a);
        delegate void Show(int a);

        static void Main(string[] args)
        {

            // Part 1
            MyDelegate del = TestFunction;
            del += TestFunction2;

            string delResult = del("sup");
            Console.WriteLine(delResult);

            // Part 2
            int[] numbers = { 2, 7, 3, 9, 5, 7, 1, 8 };
            IEnumerable<int> result = GetNumbersIf(numbers, LessThanFive);


            // Part 3
            CountIt testDel = delegate { Console.WriteLine("sup fuckers"); };
            testDel();
            CountIt2 testDel2 = delegate (int x) { Console.WriteLine(x); };
            testDel2(100);


            // Part 4
            Count lambdaTest = (int a) => (a + 5);  //expression lambdas
            int plusfive = lambdaTest(15); 
            Console.WriteLine(plusfive);
            Show lambdaTest2 = (int b) => Console.WriteLine(b);
            lambdaTest2(12);
            // statement lambdas
            Show secondLambdaTest = (int a) => { for (int i = 0; i < a; i++) { Console.WriteLine("hello"); } };

        }

        // Part 1
        static string TestFunction(string s)
        {
            return s;
        }
        static string TestFunction2(string s)
        {
            return s;
        }


        // Part 2
        static IEnumerable<int> GetNumbersIf(IEnumerable<int> numbers, NumOperation gauntlet)
        {
            foreach (int number in numbers)
            {
                if (gauntlet(number))
                {
                    yield return number;
                }
            }
        }



        // Part 3
        //static void TestFunc()
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        Console.WriteLine(i);
        //    }
        //}


    }



}
