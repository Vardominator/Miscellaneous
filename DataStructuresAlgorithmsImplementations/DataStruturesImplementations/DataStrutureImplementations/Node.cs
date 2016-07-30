using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class Node<T>
    {
        private T value;
        public T Value { get { return value; } set { this.value = value; } }

        private Node<T> left;
        public Node<T> Left { get { return left; } set { left = value; } }

        private Node<T> right;
        public Node<T> Right { get { return right; } set { right = value; } }

        private Node<T> parent;
        public Node<T> Parent { get { return parent; } set { parent = value; } }

        public Node(T value)
        {
            this.value = value;
        }
    }
}
