using DataStruturesImplementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class BinaryTree<T>
    {
        private Node<T> root;
        public Node<T> Root { get { return root; } }

        private int size;
        public int Size { get { return size; } }

        private int depth;
        public int Depth { get { return depth; } }

        public BinaryTree()
        {
            root = null;
            size = 0;
            depth = 0;
        }
        
        public BinaryTree(T rootValue)
        {
            root = new Node<T>(rootValue);
            size = 1;
            depth = 1;
        }

        public BinaryTree(Node<T> root)
        {
            this.root = root;
            size = 1;
            depth = 1;
        }

        public bool IsEmpty()
        {
            return root == null;
        }

        public void InOrderTraverse(Node<T> root)
        {
            if(root != null)
            {
                InOrderTraverse(root.Left);
                Console.WriteLine(root.Value);
                InOrderTraverse(root.Right);
            }
        }

        public void PreOrderTraverse(Node<T> root)
        {
            if(root != null)
            {
                PreOrderTraverse(root.Left);
                Console.WriteLine(root.Value);
                PreOrderTraverse(root.Right);
            }
        }

        public void PostOrderTraverse(Node<T> root)
        {
            if(root != null)
            {
                Console.WriteLine(root.Value);
                PostOrderTraverse(root.Left);
                PostOrderTraverse(root.Right);
            }
        }

        public void Insert(Node<T> node, string child, T value)
        {

            if (root == null)
            {
                root = node;
                node.Parent = null;
            }
            else
            {
                Node<T> newNode = new Node<T>(value);
           
                if(child == "left")
                {
                    node.Left = newNode;
                }
                else if(child == "right")
                {
                    node.Right = newNode;
                }
                else
                {
                    throw new ArgumentException("Child can either be \"left\" or \"right\".");
                }

                newNode.Parent = node;
            }
            size++;
        }

    }
}
