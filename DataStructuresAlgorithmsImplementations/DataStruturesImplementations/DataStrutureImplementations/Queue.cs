using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStrutureImplementations
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

        QNode<T> first;
        QNode<T> last;



        public Queue()
        {

            first = null;
            last = null;
            Count = 0;
            
        }

        public void Enqueue(T value)
        {

            QNode<T> oldLast = last;    // Set the old last to a temp      
            last = new QNode<T>();      // Add new node to the end
            last.Val = value;           // Set its value
            last.Next = null;           // Set its next as null


            if (isEmpty())
            {
                // If the queue is empty, make first and last point to
                // the same node
                first = last;           
            }
            else
            {
                // Make the previous last point to the new item
                oldLast.Next = last;
            }
            Count++;

        }

        public T Dequeue()
        {

            if (isEmpty())
            {
                throw new NullReferenceException("Queue is empty");
            }

            T value = first.Val;        // Value to dequeue is the first value in the queue
            first = first.Next;         // Set the first node equal to the next of the first
            Count--;

            if (isEmpty())
            {
                last = null;
            }

            return value;

        }

        public override String ToString()
        {

            String queueString = "[";

            if (isEmpty())
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

        public int Count
        {
            get
            {
                return count;
            }
            set
            {
                count = value;
            }
        }

        public int size()
        {
            return Count;
        }

        public Boolean isEmpty()
        {
            return first == null;
        }

    }
}
