namespace Mediator
{
    using System;

    /// <summary>
    /// The 'AbstractColleague' class
    /// </summary>
    internal class Participant
    {
        private readonly string name;
        private ChatRoom chatRoom;

        public Participant(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return this.name; }
        }

        public ChatRoom ChatRoom
        {
            get { return this.chatRoom; }
            set { this.chatRoom = value; }
        }

        public void Send(string to, string message)
        {
            this.chatRoom.Send(this.name, to, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine("{0} to {1}: '{2}'", from, this.Name, message);
        }
    }
}
