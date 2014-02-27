using System;

namespace CodingPractice.LinkedList
{
    public class SortedLinkedList : LinkedList
    {
        #region Overrides of LinkedList

        public override bool isThere(IComparable item)
        {
            bool found = false;
            ListNode location = list;
            bool moreToSearch = (location != null);

            while (moreToSearch && !found)
            {
                if (item.CompareTo(location.info) == 0)
                    found = true;
                else if (item.CompareTo(location.info) < 0)
                {
                    moreToSearch = false;
                }
                else
                {
                    location = location.next;
                    moreToSearch = (location != null);
                }
            }

            return found;
        }

        public override void insert(IComparable item)
        {
            var newNode = new ListNode();
            var location = new ListNode();
            ListNode prevLocation = null;


            location = list; // start from the first element.

            bool moreToSearch = (location != null);

            while (moreToSearch)
            {
                if (item.CompareTo(location.info) < 0) // item is less than list element
                    moreToSearch = false;
                else
                {
                    prevLocation = location; //keep prevLocation behind location
                    location = location.next; // move ahead
                    moreToSearch = (location != null);
                }
            }

            //prepare to add new item
            newNode.info = item;

            //no nodes exists currently
            if (prevLocation == null)
            {
                //insert as first
                newNode.next = list;
                list = newNode;
            }
            else
            {
                //general insert
                newNode.next = location;
                prevLocation.next = newNode;
            }
            numItems++;
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


        public void reverseKth(int k)
        {
            list = reverseKth(list, k);
        }

        private ListNode reverseKth(ListNode head, int k)
        {
            var curNode = new ListNode();
            var nextNode = new ListNode();
            ListNode prevNode = null;
            curNode = head; //first node in the list
            int count = 0;

            while (curNode != null && count < k)
            {
                nextNode = curNode.next; // get the next node
                curNode.next = prevNode;
                prevNode = curNode;
                curNode = nextNode; // get value of current node 
                count++;
            }

            if (nextNode != null)
            {
                head.next = reverseKth(nextNode, k);
            }

            return prevNode;
        }

        public void printReversed()
        {
            revPrint(list);
        }

        private void revPrint(ListNode node)
        {
            if (node == null) return;
            revPrint(node.next);
            Console.WriteLine(node.info);
        }

        #endregion

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