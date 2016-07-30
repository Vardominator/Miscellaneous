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


            TNode<int> node1 = new TNode<int>(25, 25);
            var node2 = new TNode<int>(5, 5);
            var node3 = new TNode<int>(50, 50);
            var node4 = new TNode<int>(12, 12);

            BST<int> bst = new BST<int>();

            bst.Insert(node1);
            bst.Insert(node2);
            bst.Insert(node3);
            bst.Insert(node4);

            bst.LevelOrderTraverse(bst.Root);


        }

    }
}
