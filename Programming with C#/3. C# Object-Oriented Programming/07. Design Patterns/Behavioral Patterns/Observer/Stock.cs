namespace Observer
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The 'Subject' abstract class
    /// </summary>
    internal abstract class Stock
    {
        private readonly List<IInvestor> investors = new List<IInvestor>();
        private readonly string symbol;
        private double price;

        protected Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public double Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (Math.Abs(this.price - value) > 0.001)
                {
                    this.price = value;
                    this.Notify();
                }
            }
        }

        public string Symbol
        {
            get { return this.symbol; }
        }

        public void Attach(IInvestor investor)
        {
            this.investors.Add(investor);
        }

        public void Detach(IInvestor investor)
        {
            this.investors.Remove(investor);
        }

        public void Notify()
        {
            foreach (IInvestor investor in this.investors)
            {
                investor.Update(this);
            }

            Console.WriteLine(string.Empty);
        }
    }
}
