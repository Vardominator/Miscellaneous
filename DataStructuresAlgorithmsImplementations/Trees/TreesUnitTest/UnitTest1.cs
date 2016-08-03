using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trees;

namespace TreesUnitTest
{
    [TestClass]
    public class TestBinarySearchTree
    {

        [TestMethod]
        public void TestRecursiveInsert()
        {
            BinarySearchTree<string> bst = new BinarySearchTree<string>();

            TNode<string> root = new TNode<string>(50, "cars");
            TNode<string> node1 = new TNode<string>(25, "electric");
            TNode<string> node2 = new TNode<string>(75, "gas");
            TNode<string> node3 = new TNode<string>(10, "tesla");
            TNode<string> node4 = new TNode<string>(95, "hummer");

            bst.InsertRecursive(root, node1);
            bst.InsertRecursive(root, node2);
            bst.InsertRecursive(root, node3);
            bst.InsertRecursive(root, node4);

            Assert.AreEqual(root.Left.Left, node3);
            Assert.AreEqual(root.Right.Right, node4);

        }
    }
}
