namespace SimpleFactory
{
    using System;
    using System.Linq;
    using SimpleFactory.Enums;

    public class Human
    {
        public Human(string name, int age, Sex sex)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public Sex Sex { get; set; }

        public override string ToString()
        {
            return string.Format("Name: {0} | Age: {1} | Sex: {2}", this.Name, this.Age, this.Sex);
        }
    }
}