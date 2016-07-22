﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{
    class Stack<T>
    {
        int count;
        SNode<T> first;

        public int Count { get { return count; } }

        public Stack()
        {
            first = null;
            count = 0;
        }

        public void Push(T value)
        {
            SNode<T> oldFirst = first;
            first = new SNode<T>();
            first.Val = value;
            first.Next = oldFirst;

            count++;
        }

        public T Pop()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("Stack is empty");
            }

            T poppedValue = first.Val;
            first = first.Next;
            count--;

            return poppedValue;
        }

        public T Peek()
        {
            return first.Val;
        }
        
        public bool IsEmpty()
        {
            return first == null;
        }

    }
}
