using System;
using System.Linq;

class PriorityQueueTest
{
    static void Main()
    {
        // Test with primitive types - Int32:
        var priorityQueueInts = new PriorityQueue<int>();

        priorityQueueInts.Add(5);
        priorityQueueInts.Add(10);
        priorityQueueInts.Add(-5);
        priorityQueueInts.Add(1);
        priorityQueueInts.Add(13);
        priorityQueueInts.Add(13);
        priorityQueueInts.Add(0);
        priorityQueueInts.Add(25);

        while (priorityQueueInts.Count > 0)
            Console.WriteLine(priorityQueueInts.RemoveFirst());

        Console.WriteLine();

        // Test with class Human implements IComparable (by Age):
        var priorityQueueHumans = new PriorityQueue<Human>();

        priorityQueueHumans.Add(new Human("Ivan", 25));
        priorityQueueHumans.Add(new Human("Georgi", 13));
        priorityQueueHumans.Add(new Human("Cvetelina", 18));
        priorityQueueHumans.Add(new Human("Plamena", 22));
        priorityQueueHumans.Add(new Human("Gergana", 23));
        priorityQueueHumans.Add(new Human("Qna", 21));

        while (priorityQueueHumans.Count > 0)
            Console.WriteLine(priorityQueueHumans.RemoveFirst());
    }

    class Human : IComparable
    {
        public Human(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Human;

            if (ReferenceEquals(other, null))
                return -1;

            return this.Age.CompareTo(other.Age);
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.Name, this.Age);
        }
    }
}