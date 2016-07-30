using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class BST<T> 
    {

        private TNode<T> root;
        private int size;

        public TNode<T> Root { get { return root; } set { root = value; } }
        public int Size { get { return size; } }

        public BST()
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
            if(root != null)
            {
                Console.WriteLine(root.Value);
                PreOrderTraverse(root.Left);
                PreOrderTraverse(root.Right);
            }
        }
        public void PostOrderTraverse(TNode<T> root)
        {
            if(root != null)
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

                if(node.Left != null)
                {
                    queue.Enqueue(node.Left);
                }
                if(node.Right != null)
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
            if(root == null || root.Key == key)
            {
                return root;
            }
            if(key < root.Key)
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

            // While the root is not null and key to be found is not equal to the 
            // key of the current node, check and see if the key is less than the
            // current nodes key: if it is, then traverse left; if it isn't then
            // traverse rigth.  Repeat until key is found.
           
            while(root != null && root.Key != key)
            {
                if(key < root.Key)
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
            if(root.Right != null)
            {
                return Successor(root.Right);
            }

            TNode<T> parent = root.Parent;
            while(parent != null && root == parent.Right)
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
            while(root.Left != null)
            {
                root = root.Left;
            }
            return root;
        }

        public TNode<T> Maximum(TNode<T> root)
        {
            while(root.Right != null)
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
            
            TNode<T> current = root;

            if(current == null)
            {
                root = newNode;
                newNode.Parent = null;
                size++;
                return;
            }
            else
            {
                while(current.Left != null && current.Right != null)
                {
                    if(newNode.Key < current.Key)
                    {
                        current = current.Left;
                    }
                    else
                    {
                        current = current.Right;
                    }
                }
            }
            
            newNode.Parent = current;

            if(newNode.Key < current.Key)
            {
                current.Left = newNode;
            }
            else
            {
                current.Right = newNode;
            }

            size++;
        }

        // In order to move subtrees around within a tree, we define this method
        // to replace one subtree as a child of its parent with another subtree
        public void Replace(TNode<T> nodeA, TNode<T> nodeB)
        {

            // The parent of the node to be replaced is null,
            // then set the root of the tree to be that node
            if(nodeA.Parent == null)
            {
                root = nodeB;
            }
            else if(nodeA == nodeA.Parent.Left)
            {
                nodeA.Parent.Left = nodeB;
            }
            else
            {
                nodeA.Parent.Right = nodeB;
            }
            if(nodeB != null)
            {
                nodeB.Parent = nodeA.Parent;
            }

        }


        public void Delete(TNode<T> nodeD)
        {
            ///
            /// If nodeD has no children, remove it by modifying its parent to replace
            /// nodeD with null as its child.
            /// 
            /// If nodeD has no left child, then replace nodeD with it's right child
            /// 
            /// If nodeD has no right child, then replace nodeD with it's left child
            /// 
            /// If nodeD has both left and right children, find nodeD's successor Y
            /// while lies in the nodeD's right subtree and has no left child.  Splice Y
            /// out and replace it nodeD
            /// 
            ///     If Y is nodeD's right child, replace nodeD by Y, leaving Y's right child alone
            ///     
            ///     If Y lies within nodeD's right subtreet not its not nodeD's right child,
            ///     replace Y by its own right child 
            /// 
            ///

            if(nodeD.Left == null && nodeD.Right == null)
            {
                nodeD.Parent = nodeD;
            }
            else if(nodeD.Left == null)
            {
                Replace(nodeD, nodeD.Right);
            }
            else if(nodeD.Right == null)
            {
                Replace(nodeD, nodeD.Left);
            }
            else
            {
                // Grab the successor
                TNode<T> S = Minimum(nodeD.Right);
                
                // Splice S out of its current location and replace nodeD in the tree
                if(S.Parent != nodeD)
                {
                    // Place the right child of the spliced child in the spliced child's spot
                    Replace(S, S.Right);
                    // Place the right child of the spliced child to be deleted node's right child
                    S.Right = nodeD.Right;
                    // Set the parent of the right child of the spliced child to be the spliced child
                    S.Right.Parent = S;
                }
                // Now placed the spliced child into the delected node's location
                Replace(nodeD, S);
                // Set the left of the spliced child to be the left of the delected node
                S.Left = nodeD.Left;
                // Set the parent of the left of the spliced child to be the spliced child
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
