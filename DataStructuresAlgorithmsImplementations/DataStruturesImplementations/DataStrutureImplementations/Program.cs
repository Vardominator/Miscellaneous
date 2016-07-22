using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class Program
    {
        
        static void Main(string[] args)
        {


            SinglyLinkedList<int> testList = new SinglyLinkedList<int>();
            testList.AddToEnd(1);
            testList.AddToEnd(2);
            testList.AddToEnd(10);
            testList.AddToEnd(15);
            testList.AddToEnd(25);

            testList.RemoveFromEnd();
            //testList.RemoveAt(3);

            //Console.WriteLine(testList);



            DLList<int> testDList = new DLList<int>();
            for (int i = 0; i < 10; i++)
            {

                testDList.AddToEnd(i);

            }

            Console.WriteLine(testDList);
            //testDList.AddToFront(55);
            testDList.AddAt(2, 25);
            Console.WriteLine(testDList);
            testDList.RemoveAt(4);
            Console.WriteLine(testDList);

            BST<int> testTree = new BST<int>();

            testTree.Insert(testTree, new TNode<int>(5, 5));
            testTree.Insert(testTree, new TNode<int>(2, 2));
            testTree.Insert(testTree, new TNode<int>(8, 8));
            testTree.Insert(testTree, new TNode<int>(1, 1));
            testTree.Insert(testTree, new TNode<int>(3, 3));
            testTree.Insert(testTree, new TNode<int>(7, 7));
            testTree.Insert(testTree, new TNode<int>(10, 10));

            //Console.WriteLine("In order traversal:");
            //testTree.InOrderTraverse(testTree.Root);
            //Console.WriteLine();

            //Console.WriteLine("Pre order traversal: ");
            //testTree.PreOrderTraverse(testTree.Root);
            //Console.WriteLine();

            //Console.WriteLine("Post order traversal: ");
            //testTree.PostOrderTraverse(testTree.Root);

            Console.ReadKey();

        }

    }
}
