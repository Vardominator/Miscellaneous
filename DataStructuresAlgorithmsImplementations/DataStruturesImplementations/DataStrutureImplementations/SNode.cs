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

        public T Val { get; set; }
        public SNode<T> Next { get; set; }

        public SNode()
        {
            next = null;
        }
    }
}
