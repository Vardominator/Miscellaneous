using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrutureImplementations
{
    class Program
    {
        
        static void Main(string[] args)
        {

            var testList = new DataStrutureImplementations.DLList<string>();

            testList.AddToEnd("hello");
            testList.AddToEnd("folks");
            testList.AddToEnd("what's good");

            testList.RemoveEnd();
            testList.RemoveFront();

            Console.WriteLine(testList.ToString());


            var testSList = new DataStrutureImplementations.SLList<string>();

            testSList.AddToEnd("sup");
            testSList.AddToEnd("player");
            testSList.AddToEnd("hater");

            Console.WriteLine(testSList.ToString());


            Console.ReadKey();
        }

    }
}
