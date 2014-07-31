using System;

namespace CompositePattern
{
    public class Person : PersonComponent
    {
        public Person(string name)
            : base(name)
        {
        }

        public override void Add(PersonComponent page)
        {
            Console.WriteLine("Cannot add to a person");
        }

        public override void Remove(PersonComponent page)
        {
            Console.WriteLine("Cannot remove from a person");
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);
        }
    }
}