namespace CodingPractice.LinkedList
{
    public static class AlternateList
    {
        private static LinkedList linkedList;

        public static void run()
        {
            linkedList = new UnsortedLinkedList();
            linkedList.insert(0);
            linkedList.insert(1);
            linkedList.insert(0);
            linkedList.insert(1);
            linkedList.insert(0);
            linkedList.insert(1);
            split();
        }


        private static void split()
        {
            LinkedList.ListNode currNode = linkedList.list;
            LinkedList.ListNode a = null;
            LinkedList.ListNode b = null;

            while (currNode != null)
            {
                appendNode(ref currNode, ref a);

                if (currNode != null)
                {
                    appendNode(ref currNode, ref b);
                }
            }
        }

        private static void appendNode(ref LinkedList.ListNode currNode, ref LinkedList.ListNode source)
        {
            LinkedList.ListNode temp = currNode; // hold current node in a temp node
            currNode = currNode.next; // move ahead
            temp.next = source; // join node to the source
            source = temp; // copy node to source
        }
    }
}