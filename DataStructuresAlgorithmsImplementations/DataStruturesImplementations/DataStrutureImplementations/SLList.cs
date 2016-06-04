using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrutureImplementations
{

    /// <summary>
    /// Singly Linked list implementation without a tail
    /// </summary>
    /// <typeparam name="T"></typeparam>

    class SLList<T>
    {

        LNode<T> head;
        int count;

        public int Count { get { return count; } }

        public SLList()
        {
            head = new LNode<T>();
            head.Next = null;
            count = 0;
        }

        public void AddToEnd(T value)
        {

            LNode<T> newNode = new LNode<T>(value);

            if(head.Next == null)
            {
                head.Next = newNode;
            }

            else
            {

                LNode<T> current = head;

                while(current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;
            
            }

        }

        public void AddToFront(T value)
        {

        }


        public override string ToString()
        {

            LNode<T> current = head.Next;
            string list = "";
            while (current.Next != null)
            {
                list += current.Val + " ";
                current = current.Next;
            }
            list += current.Val;
            return list;
        }

    }
}
