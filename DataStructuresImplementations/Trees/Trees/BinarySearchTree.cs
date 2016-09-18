using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    public class BinarySearchTree<T>
    {
        private TNode<T> root;
        private int size;

        public TNode<T> Root { get { return root; } set { root = value; } }
        public int Size { get { return size; } }

        public BinarySearchTree()
        {
            root = null;
            size = 0;
        }
        
        // Depth first search traversals
        #region
        public void InOrderTraverse(TNode<T> root)
        {
            if (root != null)
            {
                InOrderTraverse(root.Left);
                Console.WriteLine(root.Value);
                InOrderTraverse(root.Right);
            }
        }
        public void PreOrderTraverse(TNode<T> root)
        {
            if (root != null)
            {
                Console.WriteLine(root.Value);
                PreOrderTraverse(root.Left);
                PreOrderTraverse(root.Right);
            }
        }
        public void PostOrderTraverse(TNode<T> root)
        {
            if (root != null)
            {
                PostOrderTraverse(root.Left);
                PostOrderTraverse(root.Right);
                Console.WriteLine(root.Value);
            }
        }
        public void LevelOrderTraverse(TNode<T> root)
        {
            Queue<TNode<T>> queue = new Queue<TNode<T>>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                TNode<T> node = queue.Dequeue();

                if (node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if (node.Right != null)
                {
                    queue.Enqueue(node.Right);
                }

                Console.WriteLine(node.Value);
            }
        }

        #endregion

        // Search
        #region
        public TNode<T> Search(TNode<T> root, int key)
        {
            if (root == null || root.Key == key)
            {
                return root;
            }
            if (key < root.Key)
            {
                return Search(root.Left, key);
            }
            else
            {
                return Search(root.Right, key);
            }
        }

        public TNode<T> IterativeSearch(TNode<T> root, int key)
        {

            while (root != null && root.Key != key)
            {
                if (key < root.Key)
                {
                    root = root.Left;
                }
                else
                {
                    root = root.Right;
                }
            }

            return root;

        }

        public TNode<T> Successor(TNode<T> root)
        {

            if (root.Right != null)
            {
                return Minimum(root.Right);
            }

            TNode<T> parent = root.Parent;
            while (parent != null && root == parent.Right)
            {
                root = parent;
                parent = parent.Parent;
            }
            return parent;

        }

        public TNode<T> Predecessor(TNode<T> root)
        {

            if (root.Left != null)
            {
                return Maximum(root.Left);
            }

            TNode<T> parent = root.Parent;
            while (parent != null & root == parent.Left)
            {
                root = parent;
                parent = parent.Parent;
            }

            return parent;

        }
        #endregion

        // Maximum and minimum
        #region
        public TNode<T> Minimum(TNode<T> root)
        {
            while (root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }

        public TNode<T> Maximum(TNode<T> root)
        {
            while (root.Right != null)
            {
                root = root.Right;
            }
            return root;
        }
        #endregion

        // Insertion and deletion
        #region
        public void Insert(TNode<T> newNode)
        {

            TNode<T> parent = null;
            TNode<T> current = root;

            while(current != null)
            {
                parent = current;
                if(newNode.Key < current.Key)
                {
                    current = current.Left;
                }
                else
                {
                    current = current.Right;
                }
            }

            newNode.Parent = parent;

            if(parent == null)
            {
                root = newNode;
            }
            else if(newNode.Key < parent.Key)
            {
                parent.Left = newNode;
            }
            else
            {
                parent.Right = newNode;
            }

            size++;
        }


        public void InsertRecursive(TNode<T> head, TNode<T> newNode)
        {
           
            if(head == null)
            {
                head = newNode;
            }

            else
            {
                if(newNode.Key < head.Key)
                {
                    if(head.Left == null)
                    {
                        head.Left = newNode;
                        newNode.Parent = head;
                    }
                    else
                    {
                        InsertRecursive(head.Left, newNode);
                    }
                }
                else
                {
                    if(head.Right == null)
                    {
                        head.Right = newNode;
                        newNode.Parent = head;
                    }
                    else
                    {
                        InsertRecursive(head.Right, newNode);
                    }
                }
            }

            size++;

        }

        public void Replace(TNode<T> nodeA, TNode<T> nodeB)
        {

            if (nodeA.Parent == null)
            {
                root = nodeB;
            }
            else if (nodeA == nodeA.Parent.Left)
            {
                nodeA.Parent.Left = nodeB;
            }
            else
            {
                nodeA.Parent.Right = nodeB;
            }
            if (nodeB != null)
            {
                nodeB.Parent = nodeA.Parent;
            }

        }


        public void Delete(TNode<T> nodeD)
        {

            if (nodeD.Left == null && nodeD.Right == null)
            {
                nodeD.Parent = nodeD;
            }
            else if (nodeD.Left == null)
            {
                Replace(nodeD, nodeD.Right);
            }
            else if (nodeD.Right == null)
            {
                Replace(nodeD, nodeD.Left);
            }
            else
            {

                TNode<T> S = Minimum(nodeD.Right);

                if (S.Parent != nodeD)
                {
                    Replace(S, S.Right);
                    S.Right = nodeD.Right;
                    S.Right.Parent = S;
                }

                Replace(nodeD, S);
                S.Left = nodeD.Left;
                S.Left.Parent = S;

            }

        }
        #endregion

        public bool IsEmpty()
        {
            return root == null;
        }

    }
}
