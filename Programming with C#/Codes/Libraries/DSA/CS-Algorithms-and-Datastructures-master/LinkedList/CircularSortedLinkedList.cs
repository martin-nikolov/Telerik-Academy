using System;

namespace CodingPractice.LinkedList
{
	public class CircularSortedLinkedList : LinkedList
	{
		public override bool isThere(IComparable item)
		{
			int holdCompare;
			ListNode location = list;
			bool found = false;
			bool moreToSearch = (location != null);

			while (moreToSearch & !found)
			{
				holdCompare = item.CompareTo(location.next.info); // start from first element.. since list now points to last element

				if (holdCompare == 0) //found 
					found = true;
				else if (holdCompare < 0) // item is smaller than list element
					moreToSearch = false;
				else
				{
					location = location.next; // move ahead
					moreToSearch = (location != list); // this makes sure we dont loop around till the world comes to an end.
				}
			}

			return found;
		}

		public override void insert(IComparable item)
		{
			var newNode = new ListNode {info = item};

			if (list == null) //insert into an empty list
			{
				list = newNode; // first node
				newNode.next = newNode; // circular refernce
			}
			else
			{
				var prevLocation = new ListNode();
				var location = new ListNode();
				bool moreToSearch = true;

				location = list.next; // first element since list points to last element
				prevLocation = list; //last element

				//find insertion point
				while (moreToSearch)
				{
					if (item.CompareTo(location.info) < 0) //list element is larger than item
						moreToSearch = false;
					else
					{
						prevLocation = location; // make sure prev is one location behind
						location = location.next; // move ahead
						moreToSearch = (location != list.next); // make sure we havent reached the end.. ie completed the circle
					}
				}

				newNode.next = location; //Insert node into list
				prevLocation.next = newNode; //maintain circular reference

				if (item.CompareTo(list.info) > 0) // new item is last on this list
					list = newNode; //make sure list points to last node.. ALWAYS
			}

			numItems++;
		}
	}
}