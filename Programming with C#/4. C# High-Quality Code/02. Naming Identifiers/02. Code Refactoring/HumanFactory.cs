namespace SimpleFactory
{
    using System;
    using System.Linq;
    using SimpleFactory.Enums;

    public class HumanFactory
    {
        public Human ProduceHuman(string name, int age, Sex sex)
        {
            Human human = new Human(name, age, sex);

            return human;
        }
    }
}