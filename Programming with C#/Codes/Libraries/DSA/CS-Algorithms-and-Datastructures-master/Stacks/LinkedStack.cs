using System;

namespace CodingPractice.Stacks
{
    public class LinkedStack : IStack
    {
        private StackNode top; // reference to the top of this stack

        public LinkedStack()
        {
            top = null;
        }

    	public void push(object item)
        {
            var node = new StackNode {info = item, link = top};
            top = node;
        }

        public void pop()
        {
            if (!isEmpty())
                top = top.link;
            else
                throw new Exception("Pop Attemped on an empty stack");
        }

        object IStack.top()
        {
            if (!isEmpty())
                return top.info;
            throw new Exception("Top Attemped on an empty stack");
        }

        public bool isEmpty()
        {
            return (top == null);
        }

        public bool isFull()
        {
            return false;
        }

    	#region Nested type: StackNode

        private class StackNode
        {
            public object info;
            public StackNode link;
        }

        #endregion
    }
}