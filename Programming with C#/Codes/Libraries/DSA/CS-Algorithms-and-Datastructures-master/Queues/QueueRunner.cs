namespace CodingPractice.Queues
{
    public static class QueueRunner
    {
        public static void run()
        {
            /*IQueue queue = new LinkedQueue();
            queue.enqueue(5);
            queue.enqueue(10);
            queue.enqueue(20);
            queue.enqueue(1);*/

            IQueue queue = new ArrayQueue();
            queue.enqueue(5);
            queue.enqueue(10);
            queue.enqueue(20);
            queue.enqueue(1);
        }
    }
}