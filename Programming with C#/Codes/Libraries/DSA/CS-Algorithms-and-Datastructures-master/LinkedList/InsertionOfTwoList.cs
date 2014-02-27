namespace CodingPractice.LinkedList
{
    public class InsertionOfTwoList
    {
        private static LinkedList firstlinkedList;
        private static LinkedList secondlinkedList;
        private static LinkedList.ListNode newLinkedlist;

        public static void run()
        {
            firstlinkedList = new SortedLinkedList();

            firstlinkedList.insert(6);
            firstlinkedList.insert(5);
            firstlinkedList.insert(4);
            firstlinkedList.insert(3);
            firstlinkedList.insert(2);
            firstlinkedList.insert(1);

            secondlinkedList = new SortedLinkedList();
            secondlinkedList.insert(8);
            secondlinkedList.insert(6);
            secondlinkedList.insert(4);
            secondlinkedList.insert(2);

            sortedIntersect();
        }

        private static void sortedIntersect()
        {
            LinkedList.ListNode firstCurrNode = firstlinkedList.list;
            LinkedList.ListNode secondCurrNode = secondlinkedList.list;

            while (firstCurrNode != null && secondCurrNode != null)
            {
                if (firstCurrNode.info.CompareTo(secondCurrNode.info) == 0) // if both element are same
                {
                    LinkedList.ListNode temp = firstCurrNode; // copy value into a temp node
                    firstCurrNode = firstCurrNode.next; // move ahead
                    secondCurrNode = secondCurrNode.next; //move ahead
                    temp.next = newLinkedlist;
                    newLinkedlist = temp;
                }
                else if (firstCurrNode.info.CompareTo(secondCurrNode.info) < 0) // first node < second node
                    firstCurrNode = firstCurrNode.next;
                else
                    secondCurrNode = secondCurrNode.next; // second node < first node
            }
        }
    }
}