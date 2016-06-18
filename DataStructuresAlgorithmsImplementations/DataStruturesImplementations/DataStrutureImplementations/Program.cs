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

            BST<int> testTree = new BST<int>();

            testTree.Insert(testTree, new TNode<int>(5, 5));
            testTree.Insert(testTree, new TNode<int>(2, 2));
            testTree.Insert(testTree, new TNode<int>(8, 8));
            testTree.Insert(testTree, new TNode<int>(1, 1));
            testTree.Insert(testTree, new TNode<int>(3, 3));
            testTree.Insert(testTree, new TNode<int>(7, 7));
            testTree.Insert(testTree, new TNode<int>(10, 10));

            Console.WriteLine("In order traversal:");
            testTree.InOrderTraverse(testTree.Root);
            Console.WriteLine();

            Console.WriteLine("Pre order traversal: ");
            testTree.PreOrderTraverse(testTree.Root);
            Console.WriteLine();

            Console.WriteLine("Post order traversal: ");
            testTree.PostOrderTraverse(testTree.Root);

            Console.ReadKey();

        }

    }
}
