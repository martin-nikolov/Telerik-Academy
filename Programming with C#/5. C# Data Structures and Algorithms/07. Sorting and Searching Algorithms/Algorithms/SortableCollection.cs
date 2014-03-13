namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("Collection cannot be null.");
            }

            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get { return this.items; }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.Items);
        }

        public int LinearSearch(T item)
        {
            return this.Items.LinearSearch(item);
        }

        public int BinarySearch(T item)
        {
            return this.Items.BinarySearch(item);
        }

        public void Shuffle()
        {
            this.Items.Shuffle();
        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}