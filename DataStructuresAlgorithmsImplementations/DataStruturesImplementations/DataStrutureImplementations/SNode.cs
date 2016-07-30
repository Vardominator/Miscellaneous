using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class SNode<T>
    {
        private T val;
        private SNode<T> next;

        public T Val { get { return val; } set { val = value; } }
        public SNode<T> Next { get { return next; } set { next = value; } }

        public SNode(T value)
        {
            val = value;
            next = null;
        }
    }
}
