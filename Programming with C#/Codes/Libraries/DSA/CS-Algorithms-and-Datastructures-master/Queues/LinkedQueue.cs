namespace CodingPractice.Queues
{
    /// <summary>
    /// always add at rear and delete from front
    /// </summary>
    public class LinkedQueue : IQueue
    {
        private QueueNode front;
        private QueueNode rear;

        #region Nested type: QueueNode

        private class QueueNode
        {
            public object info;
            public QueueNode link;
        }

        #endregion

        #region Implementation of IQueue

        public void enqueue(object item)
        {
            /*var node = new QueueNode {info = item, link = rear};
            rear = node;
            
            if (front == null)
            {
                front = rear;
            }*/

            var node = new QueueNode {info = item, link = null};

            if (rear == null) // always add from rear.
                front = node;
            else
                rear.link = node;
            rear = node; // rear is always the last node added
        }


        public object dequeue()
        {
            object item = front; //always from front
            front = front.link;

            if (front == null)
                rear = null;

            return item;
        }

        public bool isEmpty()
        {
            return (front == null);
        }

        public bool isFull()
        {
            return false;
        }

        #endregion
    }
}