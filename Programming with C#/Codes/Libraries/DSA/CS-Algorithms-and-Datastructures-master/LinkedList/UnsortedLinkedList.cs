using System;

namespace CodingPractice.LinkedList
{
    public class UnsortedLinkedList : LinkedList
    {
        #region Overrides of LinkedList

        public override bool isThere(IComparable item)
        {
            bool moreToSearch;
            ListNode location = list; // start from start of he list
            bool found = false;
            moreToSearch = (location != null);

            while (moreToSearch && !found)
            {
                if (item.CompareTo(location.info) == 0)
                {
                    found = true;
                }
                else
                {
                    location = location.next; //move ahead
                    moreToSearch = (location != null); // decide if we want to search more or not
                }
            }

            return found;
        }

        public override void insert(IComparable item)
        {
            var newNode = new ListNode {info = item, next = list};
            list = newNode;
            numItems++;
        }

        #endregion

        public void delete(IComparable item)
        {
            ListNode currNode = list;

            if (item.CompareTo(currNode.info) == 0)
                list = list.next; // delete first node
            else
            {
                while (item.CompareTo(currNode.next.info) != 0)
                    currNode = currNode.next; //move ahead 

                currNode.next = currNode.next.next; //delete node at a location ie delete current.next node
                numItems--;
            }
        }

        public void reverse()
        {
            var curNode = new ListNode();
            var nextNode = new ListNode();
            ListNode prevNode = null;
            curNode = list; //first node in the list

            while (curNode != null)
            {
                nextNode = curNode.next; // get the next node
                curNode.next = prevNode;
                prevNode = curNode; // copy current node to prev node
                curNode = nextNode; // get value of current node 
            }

            list = prevNode;
        }

		public void recursiveReverse()
		{
			var revNode = new ListNode();
			list = recRev(list, revNode);
		}

		public ListNode recRev(ListNode node, ListNode revNode)
		{
			if (node.next == null) // when you reach the end. BASE case
			{
				node.next = revNode;
				revNode = node;
			}
			else  //general case
			{
				revNode = recRev(node.next, revNode);
				node.next = revNode;
				revNode = node;
			}
			return revNode;
		}

        public void Print()
        {
            print(list);
        }

        private void print(ListNode node)
        {
            if (node == null) return;
            Console.WriteLine(node.info);
            print(node.next);
        }
    }
}