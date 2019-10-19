using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS460HW3
{
    class LinkedQueue<T>
    {
        private Node<T> Front;
        private Node<T> Rear;

        public LinkedQueue()
        {
            Front = null;
            Rear = null;
        }

        public T push(T element)
        {
            if (element == null)
            {
                throw new NullPointerException();
            }

            if (isEmpty())
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

        public T pop()
        {
            T tmp = default(T);
            if (isEmpty())
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

        public T peek()
        {
            if (isEmpty())
            {
                throw new QueueUnderflowException("The queue was empty when peek was invoked.");
            }
            return Front.data;
        }

        public bool isEmpty()
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
