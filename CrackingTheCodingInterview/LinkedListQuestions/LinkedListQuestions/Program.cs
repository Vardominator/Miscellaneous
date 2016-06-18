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

            testList.AddToEnd(6);
            testList.AddToEnd(1);
            testList.AddToEnd(7);

            SLList<int> testList2 = new SLList<int>();

            testList2.AddToEnd(2);
            testList2.AddToEnd(9);
            testList2.AddToEnd(5);

            Console.WriteLine(SumListsAlt(testList, testList2));

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


        // Problem 2.2 Return Kth to Last: Implement an algorithm to find the kth to last
        // element of a singly linked list.
        public static LNode<int> KthToLast(SLList<int> list, int k)
        {

            LNode<int> current = list.Head;

            for (int i = 0; i <= list.Count - k; i++)
            {
                current = current.Next;
            }

            return current;

        }

        
        // Problem 2.3 Delete Middle Node: Implement an algorithm to delete a node in the
        // middle of a singly linked list, given only acccess to that node.
        public static void DeleteMiddleNode(LNode<int> middleNode)
        {

            LNode<int> next = middleNode.Next;

            middleNode.Val = next.Val;
            middleNode.Next = next.Next;

        }


        // Problem 2.5 Sum Lists: You have two numbers represented by a linked list, where
        // each node contains a single digit.  The digits are stored in reverse order, such
        // that the 1's digit is at the head of the list. Write a function that adds the
        // two numbers and returns the sum as a linked list.
        public static int SumLists(SLList<int> firstList, SLList<int> secondList)
        {

            int firstSize = firstList.Count;
            int secondSize = secondList.Count;

            int multiple = 1;

            int firstNum = 0;
            int secondNum = 0;

            int total = 0;

            LNode<int> currentfirst = firstList.Head.Next;
            while(currentfirst != null)
            {
                firstNum += currentfirst.Val * multiple;
                currentfirst = currentfirst.Next;
                multiple *= 10;
            }

            multiple = 1;
            LNode<int> currentSecond = secondList.Head.Next;
            while(currentSecond != null)
            {
                secondNum += currentSecond.Val * multiple;
                currentSecond = currentSecond.Next;
                multiple *= 10;
            }

            total = firstNum + secondNum;

            return total;

        }
        public static int SumListsAlt(SLList<int> firstList, SLList<int> secondList)
        {

            int firstCount = firstList.Count;
            int secondCount = secondList.Count;

            int multiple1 = (int)Math.Pow(10, firstCount - 1);
            int multiple2 = (int)Math.Pow(10, secondCount - 1);

            LNode<int> currentFirst = firstList.Head.Next;

            int firstSum = 0;
            int secondSum = 0;

            int total = 0;

            while(currentFirst != null)
            {
                firstSum += currentFirst.Val * multiple1;
                multiple1 /= 10;
                currentFirst = currentFirst.Next;
            }


            LNode<int> currentSecond = secondList.Head.Next;
            while(currentSecond!= null)
            {
                secondSum += currentSecond.Val * multiple2;
                multiple2 /= 10;
                currentSecond = currentSecond.Next;
            }

            total = firstSum + secondSum;

            return total;

        }

    }
}
