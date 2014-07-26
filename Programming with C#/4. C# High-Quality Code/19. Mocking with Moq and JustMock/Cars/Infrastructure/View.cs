namespace Cars.Infrastructure
{
    using Cars.Contracts;

    public class View : IView
    {
        public View(object model = null)
        {
            this.Model = model;
        }

        public object Model { get; private set; }
    }
}