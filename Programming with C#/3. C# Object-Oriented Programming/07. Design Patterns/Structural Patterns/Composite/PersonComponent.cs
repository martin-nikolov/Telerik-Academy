namespace CompositePattern
{
    public abstract class PersonComponent
    {
        protected string name;

        public PersonComponent(string name)
        {
            this.name = name;
        }

        public abstract void Add(PersonComponent page);

        public abstract void Remove(PersonComponent page);

        public abstract void Display(int depth);
    }
}