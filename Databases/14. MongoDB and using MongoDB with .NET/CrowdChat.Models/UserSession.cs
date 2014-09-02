namespace CrowdChat.Models
{
    using System;
    using System.Linq;

    public class UserSession
    {
        public UserSession(string name)
        {
            this.Name = name;
            this.LoggedOn = DateTime.Now;
        }

        public string Name { get; set; }

        public DateTime LoggedOn { get; set; }
    }
}