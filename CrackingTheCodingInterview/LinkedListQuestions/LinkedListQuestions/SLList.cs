using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListQuestions
{
    /// <summary>
    /// Singly Linked list implementation without a tail
    /// </summary>
    /// <typeparam name="T"></typeparam>

    class SLList<T>
    {

        LNode<T> head;
        int count;

        public LNode<T> Head { get { return head; } }
        public int Count { get { return count; } set { count = value; } }

        public SLList()
        {
            head = new LNode<T>();
            head.Next = null;
            count = 0;
        }

        public void AddToEnd(T value)
        {

            LNode<T> newNode = new LNode<T>(value);

            if (head.Next == null)
            {
                head.Next = newNode;
            }

            else
            {

                LNode<T> current = head;

                while (current.Next != null)
                {
                    current = current.Next;
                }

                current.Next = newNode;

            }
            count++;

        }

        public void AddToEnd(LNode<T> newNode)
        {

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

            LNode<T> newNode = new LNode<T>(value);
            
            if (head.Next == null)
            {
                head.Next = newNode;
            }

            LNode<T> oldFirstNode = head.Next;

            head.Next = newNode;
            newNode.Next = oldFirstNode;

            count++;

        }

        public void AddToFront(LNode<T> newNode)
        {
     
            if(head.Next == null)
            {
                head.Next = newNode;
            }

            LNode<T> oldFirstNode = head.Next;
            head.Next = newNode;
            newNode.Next = oldFirstNode;

            count++;

        }


        public void Remove(T value)
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
