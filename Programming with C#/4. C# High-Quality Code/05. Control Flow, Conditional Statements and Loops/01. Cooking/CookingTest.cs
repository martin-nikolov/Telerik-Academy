namespace Cooking
{
    using System;
    using System.Linq;
    using Cooking.Food;

    internal class CookingTest
    {
        static void Main()
        {
            Chef chef = new Chef();

            {
                Potato potato = new Potato();

                if (potato == null)
                {
                    throw new ArgumentException();
                }
                
                if (potato.IsPeeled && !potato.IsRotten)
                {
                    chef.CookByProducts(potato);
                }
            }

            // ....
        }
    }
}