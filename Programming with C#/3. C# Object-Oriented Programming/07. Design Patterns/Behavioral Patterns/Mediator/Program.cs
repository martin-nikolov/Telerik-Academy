namespace Mediator
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var chatRoom = new ChatRoom();

            Participant george = new Beetle("George");
            Participant paul = new Beetle("Paul");
            Participant ringo = new Beetle("Ringo");
            Participant john = new Beetle("John");
            Participant yoko = new NonBeetle("Yoko");

            chatRoom.Register(george);
            chatRoom.Register(paul);
            chatRoom.Register(ringo);
            chatRoom.Register(john);
            chatRoom.Register(yoko);

            yoko.Send("John", "Hi John!");
            paul.Send("Ringo", "All you need is love");
            ringo.Send("George", "My sweet Lord");
            paul.Send("John", "Can't buy me love");
            john.Send("Yoko", "My sweet love");
        }
    }
}
