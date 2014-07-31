namespace Mediator
{
    using System;

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    internal class Beetle : Participant
    {
        public Beetle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a Beetle: ");
            base.Receive(from, message);
        }
    }
}
