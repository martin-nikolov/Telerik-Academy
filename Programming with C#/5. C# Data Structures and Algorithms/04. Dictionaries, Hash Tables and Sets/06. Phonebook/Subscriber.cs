namespace AbstractDataStructures
{
    public class Subscriber
    {
        public Subscriber(string name, string town, string phoneNumber)
        {
            this.Name = name;
            this.Town = town;
            this.PhoneNumber = phoneNumber;
        }

        public string Name { get; private set; }

        public string Town { get; private set; }

        public string PhoneNumber { get; private set; }

        public override string ToString()
        {
            return string.Format("{0,-25} |    {1,-10} |    {2,-10}",
                this.Name, this.Town, this.PhoneNumber);
        }
    }
}