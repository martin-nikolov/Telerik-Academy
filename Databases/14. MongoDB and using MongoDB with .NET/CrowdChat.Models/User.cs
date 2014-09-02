namespace CrowdChat.Models
{
    using System;
    using System.Linq;

    public class User
    {
        public User(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }
    }
}