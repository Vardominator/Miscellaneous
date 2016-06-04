using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesEventsLambdas
{
    class Program
    {

        // Any function that wants to use this delegate
        // must have a parameter list of one string and
        // a return type of void. 
        delegate string MyDelegate();

        static void Main(string[] args)
        {

            //MyDelegate del = new MyDelegate(TestFunction);
            MyDelegate del = TestFunction;  //The compiler automatically injects the new 
            // del is now pointing to TestFunction

            // You can add to an invocation list
            del += TestFunction2;
            
            string delResult = del();
            
            Console.WriteLine(delResult);

            Console.ReadKey();

        }

        static string TestFunction()
        {
            return "Hello folks";
        }

        static string TestFunction2()
        {
            return "Goodbye folks";
        }

    }
}
