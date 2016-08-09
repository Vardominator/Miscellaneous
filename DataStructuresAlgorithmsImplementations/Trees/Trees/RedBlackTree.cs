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

        public RedBlackTree(int initialKey, T initialValue)
        {
            root = new TNode<T>(initialKey, initialValue);
            tail = new TNode<T>(-1, default(T));
            root = tail;
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

        void Insert(RedBlackTree<T> tree, TNode<T> newNode)
        {

            TNode<T> currentParent = null;
            TNode<T> current = tree.root;

            while (current != null)
            {
                currentParent = current;

                if (newNode.Key < current.Key)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            newNode.Parent = currentParent;

            if (newNode.Key < current.Key)
            {
                current.Left = newNode;
            }
            else
            {
                current.Right = newNode;
            }
            
            newNode.Left = tree.tail;
            newNode.Right = tree.tail;
            newNode.Color = TNode<T>.COLOR.RED;

            InsertBalance(tree, newNode);

        }


        public void InsertBalance(RedBlackTree<T> tree, TNode<T> z)
        {

            while(z.Parent.Color == TNode<T>.COLOR.RED)
            {

                if(z.Parent == z.Parent.Parent.Left)
                {
                    TNode<T> uncle = z.Parent.Parent.Right;

                    if (uncle.Color == TNode<T>.COLOR.RED)
                    {
                        uncle.Color = TNode<T>.COLOR.BLACK;
                        z.Parent.Color = TNode<T>.COLOR.BLACK;
                        z.Parent.Parent.Color = TNode<T>.COLOR.RED;
                        z = z.Parent.Parent;
                    }
                    else if (z == z.Parent.Right)
                    {
                        z = z.Parent;
                        LeftRotate(tree, z);
                    }

                    z.Parent.Color = TNode<T>.COLOR.BLACK;
                    z.Parent.Parent.Color = TNode<T>.COLOR.RED;
                    RightRotate(tree, z.Parent.Parent);

                }
                else
                {
                    TNode<T> uncle = z.Parent.Parent.Left;

                    if(uncle.Color == TNode<T>.COLOR.RED)
                    {
                        uncle.Color = TNode<T>.COLOR.BLACK;
                        z.Parent.Color = TNode<T>.COLOR.BLACK;
                        z.Parent.Parent.Color = TNode<T>.COLOR.RED;
                    }
                    else if(z == z.Parent.Left)
                    {
                        z = z.Parent;
                        RightRotate(tree, z);
                    }

                    z.Parent.Color = TNode<T>.COLOR.BLACK;
                    z.Parent.Parent.Color = TNode<T>.COLOR.RED;
                    LeftRotate(tree, z.Parent.Parent);
                }

                tree.root.Color = TNode<T>.COLOR.BLACK;

            }

        }


        public void Delete(RedBlackTree<T> tree, TNode<T> node)
        {

            TNode<T> movingNode = node;
            TNode<T>.COLOR originalColor = node.Color;

            TNode<T> movingNodeChild;

            if(node.Left == tree.tail)
            {
                movingNodeChild = node.Right;
                Replace(tree, node, movingNodeChild);
            }
            else if(node.Right == tree.tail)
            {
                movingNodeChild = node.Left;
                Replace(tree, node, movingNodeChild);
            }
            else
            {
                movingNode = Minimum(node.Right);
                originalColor = movingNode.Color;
                movingNodeChild = movingNode.Right;

                if (movingNode.Parent == node)
                {
                    movingNodeChild.Parent = movingNode;
                }
                else
                {
                    Replace(tree, movingNode, movingNode.Right);
                    movingNode.Right = node.Right;
                    movingNode.Right.Parent = movingNode;
                }

                Replace(tree, node, movingNode);
                movingNode.Left = node.Left;
                movingNode.Left.Parent = movingNode;
                movingNode.Color = node.Color;
            }

            if(movingNode.Color == TNode<T>.COLOR.BLACK)
            {
                DeleteBalance(tree, movingNodeChild);
            }
        }

        public void DeleteBalance(RedBlackTree<T> tree, TNode<T> node)
        {
            while(node != tree.root && node.Color == TNode<T>.COLOR.BLACK)
            {
                if(node == node.Parent.Left)
                {
                    TNode<T> sibling = node.Parent.Right;

                    if(sibling.Color == TNode<T>.COLOR.RED)
                    {
                        sibling.Color = TNode<T>.COLOR.BLACK;
                        node.Parent.Color = TNode<T>.COLOR.RED;
                        LeftRotate(tree, node.Parent);
                        sibling = node.Parent.Right;
                    }
                    if(sibling.Left.Color == TNode<T>.COLOR.BLACK && sibling.Right.Color == TNode<T>.COLOR.BLACK)
                    {
                        sibling.Parent.Color = TNode<T>.COLOR.RED;
                        node = node.Parent;
                    }
                    else if(sibling.Right.Color == TNode<T>.COLOR.BLACK)
                    {
                        sibling.Left.Color = TNode<T>.COLOR.BLACK;
                        sibling.Color = TNode<T>.COLOR.RED;
                        RightRotate(tree, sibling);
                    }

                    LeftRotate(tree, node.Parent);
                    sibling.Color = node.Parent.Color;
                    node.Parent.Color = TNode<T>.COLOR.BLACK;
                    sibling.Right.Color = TNode<T>.COLOR.BLACK;

                    node = tree.root;
                }
                else
                {
                    TNode<T> sibling = node.Parent.Left;

                    
                }
            }
        }

        public void Replace(RedBlackTree<T> tree, TNode<T> nodeA, TNode<T> nodeB)
        {
            if(nodeA == tree.tail)
            {
                tree.root = nodeB;
            }
            else if(nodeA == nodeA.Parent.Right)
            {
                nodeA.Parent.Right = nodeB;
            }
            else
            {
                nodeA.Parent.Left = nodeB;
            }
            nodeB.Parent = nodeA.Parent;
        }

        public TNode<T> Minimum(TNode<T> node)
        {
            while(node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }

        public TNode<T> Maximum(TNode<T> node)
        {
            while(node.Right != null)
            {
                node = node.Right;
            }
            return node;
        }

    }
}
