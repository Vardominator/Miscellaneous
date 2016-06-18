using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class TNode<T>
    {

        private int key;
        public int Key { get { return key; } set { key = value; } }

        private T value; 
        public T Value { get { return value; } set { this.value = value; } }

        private TNode<T> left;
        public TNode<T> Left { get { return left; } set { left = value; } }

        private TNode<T> right;
        public TNode<T> Right { get { return right; } set { right = value; } }

        private TNode<T> parent;
        public TNode<T> Parent { get { return parent; } set { parent = value; } }

        public TNode(int key, T value)
        {
            this.value = value;
            this.key = key;
        }

    }
}
