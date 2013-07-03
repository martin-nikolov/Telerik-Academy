using System;

namespace DefinitionOfClass
{
    public class Cat
    {
        //Fields, States, Member-variables
        private string name;
        private string color;

        //Properties
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        //Properties - Reach for changes
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        //Default constructor
        public Cat()
        {
            this.name = "unnamed";
            this.color = "grey";
        }

        //Constructor with parameters
        public Cat(string name, string color)
        {
            this.name = name;
            this.color = color;
        }

        //Methods, Behaviors
        public static void Miau()
        {
            Console.WriteLine("Miauuuu");
        }
    }

    public class Sequence
    {
        //Static field, holding the current sequence value
        private static int currentValue = 0;

        //Intentionally deny instantiation of this class
        private Sequence()
        {
        }

        //Method
        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Sequence.NextValue()); // 1
            Console.WriteLine(Sequence.NextValue()); // 2
        }
    }
}