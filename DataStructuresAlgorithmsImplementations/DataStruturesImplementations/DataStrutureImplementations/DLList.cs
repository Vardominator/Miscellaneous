using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{

    /// <summary>
    /// Doubly linked list implementation
    /// </summary>
    class DLList<T>
    {

        LNode<T> head;
        LNode<T> tail;
        int count;

        public int Count { get { return count; } }

        public DLList()
        {
            head = new LNode<T>();
            tail = new LNode<T>();
            head.Next = tail;
            tail.Prev = head;
        }


        public void AddToEnd(T value)
        {

            LNode<T> newNode = new LNode<T>(value);

            if (head.Next == tail)
            {
                head.Next = newNode;
                newNode.Prev = head;
                newNode.Next = tail;
                tail.Prev = newNode;
            }
            else
            {
                LNode<T> lastNode = tail.Prev;
                lastNode.Next = newNode;
                newNode.Prev = lastNode;
                newNode.Next = tail;
                tail.Prev = newNode;
            }
            count++;

        }

        public void AddToFront(T value)
        {

            LNode<T> newNode = new LNode<T>(value);
            if (head.Next == tail)
            {
                head.Next = newNode;
                newNode.Prev = head;
                newNode.Next = tail;
                tail.Prev = newNode;
            }
            else
            {
                LNode<T> lastFirstNode = head.Next;
                newNode.Next = lastFirstNode;
                newNode.Prev = head;
                head.Next = newNode;
            }
            count++;

        }

        public LNode<T> RemoveEnd()
        {
            if (isEmpty())
            {
                throw new NullReferenceException("List is empty");
            }

            LNode<T> nodeToRemove = tail.Prev;
            LNode<T> newLastNode = nodeToRemove.Prev;

            newLastNode.Next = tail;
            tail.Prev = newLastNode;

            return nodeToRemove;

        }

        public LNode<T> RemoveFront()
        {

            if (isEmpty())
            {
                throw new NullReferenceException("List is empty");
            }

            LNode<T> nodeToRemove = head.Next;
            LNode<T> newFirstNode = nodeToRemove.Next;

            newFirstNode.Prev = head;
            head.Next = newFirstNode;

            return nodeToRemove;

        }

        public void Remove(T vlaue)
        {
            throw new NotImplementedException("Don't be lazy, you fuck");
        }

        public bool isEmpty()
        {
            return count == 0;
        }

        public override string ToString()
        {
            LNode<T> root = head;
            LNode<T> current = root.Next;
            string list = "";
            while(current.Next != tail)
            {
                list += current.Val + " ";
                current = current.Next;
            }
            list += current.Val;
            return list;
        }



    }
}
