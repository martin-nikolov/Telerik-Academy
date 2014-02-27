namespace CodingPractice.LinkedList
{
    public static class ShuffleMergeList
    {
        private static LinkedList a;
        private static LinkedList b;
        private static LinkedList.ListNode merged = new LinkedList.ListNode();

        public static void run()
        {
            a = new UnsortedLinkedList();
            a.insert(3);
            a.insert(2);
            a.insert(1);

            b = new UnsortedLinkedList();
            b.insert(1);
            b.insert(13);
            b.insert(7);
            shuffleMerge();
        }

        private static void shuffleMerge()
        {
            LinkedList.ListNode currA = a.list;
            LinkedList.ListNode currB = b.list;

            while (currA != null || currB != null)
            {
                appendNode(ref currA, ref merged);
                appendNode(ref currB, ref merged);
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