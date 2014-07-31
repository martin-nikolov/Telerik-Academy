namespace Mediator
{
    using System;

    /// <summary>
    /// A 'ConcreteColleague' class
    /// </summary>
    internal class NonBeetle : Participant
    {
        public NonBeetle(string name)
            : base(name)
        {
        }

        public override void Receive(string from, string message)
        {
            Console.Write("To a non-Beetle: ");
            base.Receive(from, message);
        }
    }
}
