using System;
using System.Threading;

namespace CodingPractice.Stacks
{
    public static class StackRunner
    {
        public static void run()
        {
			//IStack stack = new LinkedStack();
			//stack.push(5);
			//stack.push(3);
			//stack.push(4);

        	IStack arrayStack = new ArrayStack();
			arrayStack.push(5);
			arrayStack.push(3);
			arrayStack.push(4);
			arrayStack.push(6);
			arrayStack.push(12);
			
			Console.WriteLine(arrayStack.top());

			arrayStack.pop();

			Console.WriteLine(arrayStack.top());

			Thread.Sleep(1000);
        }
    }
}