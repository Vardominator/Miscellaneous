using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStruturesImplementations
{

    /// <summary>
    /// Notes about queues from MSDN:
    ///     A queue is a circular ArrayList that is ideal for situations where
    ///     data needs to processed in a precise order in which they are receieved
    ///     If you know you will need random access, the queue is not the way to go.
    ///     The queue requires two pointers: one for adding items at one end,
    ///     and another for removing items at the other.
    /// </summary>
    ///

    public class Queue<T>
    {

        int count;                      // Number of elemtents on queue

        public int Count { get { return count; } }

        QNode<T> first;
        QNode<T> last;

        
        public Queue()
        {
            first = null;
            last = null;
            count = 0;
        }

        public void Enqueue(T value)
        {
            QNode<T> oldLast = last;   
            last = new QNode<T>(value);

            if (IsEmpty())
            {
                first = last;           
            }
            else
            {
                oldLast.Next = last;
            }
            count++;
        }

        public T Dequeue()
        {
            if (IsEmpty())
            {
                throw new NullReferenceException("Queue is empty");
            }

            T value = first.Val;       
            first = first.Next;         
            count--;

            if (IsEmpty())
            {
                last = null;
            }

            return value;
        }

        public override string ToString()
        {
            string queueString = "[";

            if (IsEmpty())
            {
                return "[]";
            }

            QNode<T> current = first;

            while(current.Next != null)
            {
                queueString += current.Val.ToString() + " ";
                current = current.Next;
            }

            queueString += current.Val.ToString();
            queueString += "]";

            return queueString;
        }
        
        public bool IsEmpty()
        {
            return first == null;
        }

    }
}
