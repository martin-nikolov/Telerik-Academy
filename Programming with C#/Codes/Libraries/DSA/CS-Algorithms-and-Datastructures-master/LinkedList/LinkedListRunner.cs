namespace CodingPractice.LinkedList
{
    public static class LinkedListRunner
    {
        public static void run()
        {
            //var unsortedLinkedList = new UnsortedLinkedList();
            //unsortedLinkedList.insert(5);
            //unsortedLinkedList.insert(55);
            //unsortedLinkedList.insert(15);

            //Console.WriteLine(unsortedLinkedList.isThere(55));
            //Console.WriteLine(unsortedLinkedList.isThere(554));

            var linkedList = new CircularSortedLinkedList();
            linkedList.insert(8);
            linkedList.insert(4);
            linkedList.insert(16);
            linkedList.insert(6);
      

            //Console.WriteLine(sortedLinkedList.isThere(55));
            //Console.WriteLine(sortedLinkedList.isThere(554));
            //sortedLinkedList.reverse();
            //sortedLinkedList.printList();
            //sortedLinkedList.printReversed();

            //sortedLinkedList.printReversed();

            //var sortedLinkedList = new CircularSortedLinkedList();
            //sortedLinkedList.insert(5);
            //sortedLinkedList.insert(55);
            //sortedLinkedList.insert(15);
            //sortedLinkedList.insert(10);

            //Console.WriteLine(sortedLinkedList.isThere(55));
            //Console.WriteLine(sortedLinkedList.isThere(554));
        }
    }
}