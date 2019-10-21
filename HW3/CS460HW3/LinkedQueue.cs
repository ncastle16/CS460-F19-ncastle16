using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460HW3
{
   class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> Front;
        private Node<T> Rear;

        public LinkedQueue()
        {
            Front = null;
            Rear = null;
        }

        public T Push(T element)
        {
            if (element == null)
            {
                throw new NullReferenceException();
            }

            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                Rear = Front = tmp;
            }
            else
            {
                Node<T> tmp = new Node<T>(element, null);
                Rear.next = tmp;
                Rear = tmp;
            }
            return element;
        }

        public T Pop()
        {
            T tmp = default(T);
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when pop was invoked.");
            }
            else if (Front == Rear)
            {   // one item in queue
                tmp = Front.data;
                Front = null;
                Rear = null;
            }
            else
            {
                // General case
                tmp = Front.data;
                Front = Front.next;
            }

            return tmp;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }
            return Front.data;
        }

        public bool IsEmpty()
        {
            if (Front == null && Rear == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
