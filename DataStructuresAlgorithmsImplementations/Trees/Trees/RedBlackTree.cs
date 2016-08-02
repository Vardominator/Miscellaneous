using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class RedBlackTree<T>
    {
        TNode<T> root;
        TNode<T> tail;

        public RedBlackTree()
        {

        }

        #region Rotations
        public void LeftRotate(RedBlackTree<T> tree, TNode<T> nodeA)
        {

            TNode<T> nodeB = nodeA.Right;

            // The sub trees must maintain their same order from left to right
            nodeA.Right = nodeB.Left;

            if(nodeB.Right != tree.tail)
            {
                nodeB.Right.Parent = nodeA;
            }

            nodeB.Parent = nodeA.Parent;

            if(nodeA.Parent == tree.tail)
            {
                tree.root = nodeB;
            }
            else if(nodeA == nodeA.Parent.Left)
            {
                nodeA.Parent.Left = nodeB;
            }
            else
            {
                nodeA.Parent.Right = nodeB;
            }

            nodeB.Left = nodeA;
            nodeA.Parent = nodeB;
            
        }

        public void RightRotate(RedBlackTree<T> tree, TNode<T> nodeA)
        {

            TNode<T> nodeB = nodeA.Left;

            // Subtrees have to maintain order
            nodeA.Left = nodeB.Right;

            // Parent of the subtree is now nodeA
            if(nodeB.Right != tree.tail)
            {
                nodeB.Right.Parent = nodeA;   
            }

            nodeB.Parent = nodeA.Parent;

            if(nodeA.Parent == tree.tail)
            {
                tree.root = nodeB;
            }
            else if(nodeA == nodeA.Parent.Left)
            {
                nodeA.Parent.Left = nodeB;
            }
            else
            {
                nodeA.Parent.Right = nodeB;
            }

            // Attach
            nodeB.Right = nodeA;
            nodeA.Parent = nodeB;

        }

        #endregion


    }
}
