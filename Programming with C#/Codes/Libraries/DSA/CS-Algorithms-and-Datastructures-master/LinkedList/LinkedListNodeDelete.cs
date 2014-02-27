using CodingPractice.LinkedList;

namespace CodingPractice
{
    public static class LinkedListNodeDelete
    {
        private static UnsortedLinkedList unsortedLinkedList;

        public static void run()
        {
            unsortedLinkedList = new UnsortedLinkedList();
            unsortedLinkedList.insert(3);
            unsortedLinkedList.insert(2);
            unsortedLinkedList.insert(6);
            unsortedLinkedList.insert(5);
            unsortedLinkedList.insert(11);
            unsortedLinkedList.insert(10);
            unsortedLinkedList.insert(16);
            unsortedLinkedList.insert(15);
            unsortedLinkedList.insert(12);
            //unsortedLinkedList.insert(17);

            //deleteNodes();
            delSelectedNodes();
            unsortedLinkedList.Print();
        }

        private static void delSelectedNodes()
        {
            unsortedLinkedList.reverse();
            LinkedList.LinkedList.ListNode curNode = unsortedLinkedList.list; // get first node of linked list
            LinkedList.LinkedList.ListNode maxMode = unsortedLinkedList.list; // get first node of linked list

            while (curNode != null && curNode.next != null)
            {
                if (curNode.next.info.CompareTo(maxMode.info) < 0)
                {
                    LinkedList.LinkedList.ListNode tempNode = curNode.next;
                    curNode.next = tempNode.next;
                }
                else
                {
                    curNode = curNode.next;
                    maxMode = curNode;
                }
            }

            unsortedLinkedList.reverse();
        }

        private static void deleteNodes()
        {
            var curNode = new LinkedList.LinkedList.ListNode();
            var nextNode = new LinkedList.LinkedList.ListNode();
            LinkedList.LinkedList.ListNode prevNode = null;

            curNode = unsortedLinkedList.list; //first node in the list


            while (curNode != null)
            {
                nextNode = curNode.next; // get the next node

                if (nextNode != null && curNode.info.CompareTo(nextNode.info) > 0) //curr > next
                {
                    nextNode = curNode.next; // get the next node
                    curNode.next = prevNode;
                    prevNode = curNode; // copy current node to prev node
                    curNode = nextNode; // get value of current node 
                }
                else
                {
                    curNode.next = nextNode;
                    curNode = nextNode;
                }

                unsortedLinkedList.list = prevNode;
            }
        }
    }
}