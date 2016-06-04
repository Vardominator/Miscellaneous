using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexers
{
    class Student
    {

        public string Name { get; set; }
        public int Id { get; set; }

        private int[] myScores;

        public Student(string n, int i)
        {

            this.Name = n;
            this.Id = i;

            this.myScores = new int[3];
            this.myScores[0] = 65;
            this.myScores[1] = 75;
            this.myScores[2] = 85;

        }



        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < myScores.Length)
                {
                    return myScores[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Array out of bounds");
                }
            }
            set
            {
                if (index >= 0 && index < myScores.Length)
                {
                    this.myScores[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Array out of bounds");
                }
            }
        }



        public void Show()
        {
            for (int i = 0; i < myScores.Length; i++)
            {
                Console.WriteLine(this.myScores[i]);
            }
        }



    }
}
