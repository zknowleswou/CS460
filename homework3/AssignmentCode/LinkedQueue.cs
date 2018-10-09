using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3
{
    public class LinkedQueue<T> : IQueueInterface<T>
    {
        private Node<T> _front;
        private Node<T> _rear;

        public LinkedQueue()
        {
            _front = null;
            _rear = null;
        }
        public T Push(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            if (IsEmpty())
            {
                Node<T> tmp = new Node<T>(element, null);
                _rear = _front = tmp;
            }
            else
            {
                // General case
                Node<T> tmp = new Node<T>(element, null);
                _rear.Next = tmp;
                _rear = tmp;
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
            else if (_front == _rear)
            {   // one item in queue
                tmp = _front.Data;
                _front = null;
                _rear = null;
            }
            else
            {
                // General case
                tmp = _front.Data;
                _front = _front.Next;
            }

            return tmp;
        }

        public bool IsEmpty()
        {
            if (_front == null && _rear == null)
                return true;

            return false;
        }
    }
}
