using System;

namespace CodingPractice.Queues
{
    public class ArrayQueue : IQueue
    {
        private readonly int capacity;
        private readonly object[] queue;
        private int front = -1;
        private int numItems;
        private int rear;

        public ArrayQueue()
        {
            capacity = 100;
            queue = new object[capacity];
        }

        #region Implementation of IQueue

        public void enqueue(object item)
        {
            front = (front + 1)%capacity;
            queue[front] = item;
            numItems++;
        }

        public object dequeue()
        {
            object objectToReturn = queue[rear];
            queue[rear] = null;
            rear = (rear + 1)%capacity;
            numItems--;
            return objectToReturn;
        }

        public bool isEmpty()
        {
            return (front == -1);
        }

        public bool isFull()
        {
            return (rear == Int32.MaxValue - 1);
        }

        #endregion
    }
}