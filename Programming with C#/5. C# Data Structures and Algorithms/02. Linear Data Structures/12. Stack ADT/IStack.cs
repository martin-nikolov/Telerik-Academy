namespace AbstractDataStructures
{
    public interface IStack<T>
    {
        void Push(T value);

        T Peek();

        T Pop();

        void Clear();
    }
}