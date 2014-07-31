using System;
using System.Collections.Generic;

namespace CompositePattern
{
    public class Commander : PersonComponent
    {
        private ICollection<PersonComponent> subjects;

        public Commander(string name)
            : base(name)
        {
            this.subjects = new List<PersonComponent>();
        }

        public override void Add(PersonComponent person)
        {
            this.subjects.Add(person);
        }

        public override void Remove(PersonComponent person)
        {
            this.subjects.Remove(person);
        }

        public override void Display(int depth)
        {
            Console.WriteLine(new String('-', depth) + name);

            foreach (var person in subjects)
            {
                person.Display(depth + 2);
            }
        }
    }
}