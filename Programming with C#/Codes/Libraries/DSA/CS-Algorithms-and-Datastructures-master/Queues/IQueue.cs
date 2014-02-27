namespace CodingPractice.Queues
{
    public interface IQueue
    {
        void enqueue(object item);
        object dequeue();
        bool isEmpty();
        bool isFull();
    }
}