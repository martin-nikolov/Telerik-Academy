namespace SimpleFactory.CoffeeShop
{
    public class Coffee
    {
        public int MilkContent { get; set; }

        public int CoffeeContent { get; set; }

        public Coffee(int milk, int coffee)
        {
            this.MilkContent = milk;
            this.CoffeeContent = coffee;
        }
    }
}
