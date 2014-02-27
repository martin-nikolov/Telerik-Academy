namespace CodingPractice.LinkedList
{
    public static class FrontBackSplit
    {
        private static LinkedList linkedList;

        public static void run()
        {
            linkedList = new UnsortedLinkedList();
            linkedList.insert(2);
            linkedList.insert(4);
            linkedList.insert(6);
            linkedList.insert(7);
            linkedList.insert(17);
            linkedList.insert(8);
            frontBackSplit();
        }

        public static void frontBackSplit()
        {
            int len = linkedList.numItems;
            LinkedList.ListNode front = null;
            LinkedList.ListNode back = null;

            LinkedList.ListNode currNode = linkedList.list;

            if (len < 2)
            {
                front = linkedList.list;
                back = null;
            }
            else
            {
                for (int i = 0; i < (len - 1)/2; i++)
                {
                    currNode = currNode.next;
                }

                front = linkedList.list;
                back = currNode.next;
                currNode.next = null;
            }
        }
    }
}