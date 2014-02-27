namespace CodingPractice.Stacks
{
	public class ArrayStack : IStack
	{
		private const int SIZE = 3;
		private readonly object[] stack;
		private int topStack;

		public ArrayStack()
		{
			stack = new object[SIZE];
			topStack = -1;
		}

		public void push(object item)
		{
			if(! isFull())
			{
				topStack++;
				stack[topStack] = item;
			}
		}

		public void pop()
		{
			if (!isEmpty())
			{
				stack[topStack] = null;
				topStack--;
			}
		}

		public object top()
		{
			return stack[topStack];
		}

		public bool isEmpty()
		{
			return topStack == -1;
		}

		public bool isFull()
		{
			return topStack == SIZE - 1;
		}
	}
}