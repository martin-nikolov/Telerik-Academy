namespace CodingPractice.Stacks
{
    public interface IStack
    {
        void push(object item);
        void pop();
        object top();
        bool isEmpty();
        bool isFull();
    }
}