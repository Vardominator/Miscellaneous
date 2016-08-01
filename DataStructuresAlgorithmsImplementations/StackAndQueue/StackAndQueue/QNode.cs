using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackAndQueue
{
    class QNode<T>
    {
        private T val;
        private QNode<T> next;

        public QNode<T> Next { get { return next; } set { next = value; } }
        public T Val { get { return val; } set { val = value; } }

        public QNode(T value)
        {
            val = value;
            next = null;
        }
    }

}
