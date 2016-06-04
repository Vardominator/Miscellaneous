using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypesVSReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {

            //int x = 5;
            //Change(x);

            //Console.WriteLine(x);

            //Console.ReadKey();

            Student s = new Student(id: 5, name: "Vardo");

            Change(s);

            Console.WriteLine(s.Id);
            Console.WriteLine(s.Name + "\n\n\n");

            string s1 = "hello";
            Change(s1);
            Console.WriteLine(s1);


            Console.ReadKey();

        }


        static void Change(string s)
        {
            // string is a value type
            s = "goodbye";
        }
        
        static void Change(Student s)
        {
            // passing a reference type will not copy and thus the
            // original variable will be changed
            s.Id = 10;
            s.Name = "NotVardo";
        }

        static void Change(int x)
        {
            // passing a value type will make a copy and thus the
            // original variable will be unchanged
            x = 500;
        }

        public static List<Student> GetSampleStudents()
        {
            return new List<Student>
            {
                new Student(id: 6, name: "Kevin"),
                new Student(id: 7, name: "Isaac")
            };
        }


    }
}
