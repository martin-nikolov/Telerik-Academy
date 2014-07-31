namespace Observer
{
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    internal class IBM : Stock
    {
        public IBM(string symbol, double price)
            : base(symbol, price)
        {
        }
    }
}
