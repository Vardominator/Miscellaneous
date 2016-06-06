using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListQuestions
{
    class Program
    {

        
        static void Main(string[] args)
        {

            SLList<int> testList = new SLList<int>();
            testList.AddToEnd(5);
            testList.AddToEnd(9);
            testList.AddToEnd(1);
            testList.AddToEnd(5);
            testList.AddToEnd(12);
            testList.AddToEnd(12);
            testList.AddToEnd(20);
            testList.AddToEnd(1);

            Console.WriteLine(testList.ToString() + "\n");

            RemoveDuplicates(testList);
            //RemoveDuplicatesAlt(testList);
            Console.WriteLine(testList.ToString());

        }

        // Problem 2.1 Remove Dups: Write code to remove duplicates from an unsorted linked list.
        public static void RemoveDuplicates(SLList<int> list)
        {
            // Will do this using a hashset
            // This will take O(N) time and O(N) space.
            HashSet<int> uniqueSet = new HashSet<int>();


            LNode<int> previous = null;
            LNode<int> current = list.Head;


            while(current != null)
            {
                if (uniqueSet.Contains(current.Val))
                {
                    previous.Next = current.Next;
                }
                else
                {
                    uniqueSet.Add(current.Val);
                    previous = current;
                }
                current = current.Next;
            }
           

        }
        public static void RemoveDuplicatesAlt(SLList<int> list)
        {
            // An alternative to removing duplicates. This implementation
            // is O(1) space and O(N^2) time.

            LNode<int> current = list.Head;
            
            while(current != null)
            {

                LNode<int> runner = current;

                while(runner.Next != null)
                {

                    if(runner.Next.Val == current.Val)
                    {
                        runner.Next = runner.Next.Next;
                    }
                    else
                    {
                        runner = runner.Next;
                    }
                }

                current = current.Next;
            }

        }

    }
}
