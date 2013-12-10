using System;
using System.Linq;
using ProgramDioptase.Interfaces.ItemDescription;

namespace ProgramDioptase.ClientDescription
{
    public abstract class Person : IComparable<Person>, IDataInitializable
    {
        public string Name { get; private set; }

        public byte Age { get; set; }

        public string Address { get; private set; }

        public string MobileNumber { get; private set; }

        public void InitializeData(string[] components)
        {
            this.Name = components[0];
            this.Age = byte.Parse(components[1]);
            this.Address = components[2];
            this.MobileNumber = components[3];
        }

        public int CompareTo(Person other)
        {
            return this.Name.ToLower().CompareTo(other.Name.ToLower());
        }
    }
}