using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            bool down = true;
            int currentPos = 0;

            currentPos += down ? 1 : -1;

            Console.WriteLine(currentPos);
            

        }
    }




}
