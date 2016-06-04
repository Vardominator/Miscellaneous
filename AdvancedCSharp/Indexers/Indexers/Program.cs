using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Program
    {
        static void Main(string[] args)
        {

            Student s = new Student("Bob", 50);
            s.Show();

            Console.WriteLine("\n\n");
            Console.WriteLine(s[500]);

            Console.ReadKey();

        }
    }
}
