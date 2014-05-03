namespace SimpleFactory
{
    using System;
    using System.Linq;
    using SimpleFactory.Enums;

    public class HumanFactoryDemo
    {
        public static void Main()
        {
            HumanFactory humanFactory = new HumanFactory();

            Human human = humanFactory.ProduceHuman("Ivan", 25, Sex.Male);

            Console.WriteLine(human);
        }
    }
}