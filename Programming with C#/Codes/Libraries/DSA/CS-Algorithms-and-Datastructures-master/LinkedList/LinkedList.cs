using System;

namespace CodingPractice.LinkedList
{
    internal interface ListInterface
    {
        bool isThere(IComparable item);
        void insert(IComparable item);
    }

    public abstract class LinkedList : ListInterface
    {
        protected ListNode currentPos; // current pos of iteration
        public ListNode list; // reference to first node of the list
        public int numItems; // Number of elements in the list

        protected LinkedList()
        {
            numItems = 0;
            list = null;
            currentPos = null;
        }

        #region ListInterface Members

        public abstract bool isThere(IComparable item);
        public abstract void insert(IComparable item);

        #endregion

        #region Nested type: ListNode

        public class ListNode
        {
            public IComparable info; // data in the node
            public ListNode next; // a link to next node in the list
        }

        #endregion
    }
}