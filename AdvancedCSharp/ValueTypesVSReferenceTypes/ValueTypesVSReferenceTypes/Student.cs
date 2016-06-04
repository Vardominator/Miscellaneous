using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValueTypesVSReferenceTypes
{
    class Student
    {

        int id;

        public int Id { get; set; }

        string name;

        public string Name { get; set; }

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

    }
}
