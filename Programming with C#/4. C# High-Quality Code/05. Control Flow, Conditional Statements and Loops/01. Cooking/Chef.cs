namespace Cooking
{
    using System;
    using Cooking.Food;

    public class Chef
    {
        public void CookByProducts(params NaturalFood[] products)
        {
            Bowl bowl = this.GetBowl();

            foreach (var product in products)
            {
                bowl.Add(product);
            }

            // ...
        }

        public void CookDailySpecial()
        {
            Potato potato = this.GetPotato();
            this.Peel(potato);
            this.Cut(potato);

            Carrot carrot = this.GetCarrot();
            this.Peel(carrot);
            this.Cut(carrot);

            Bowl bowl = this.GetBowl();
            bowl.Add(carrot);       
            bowl.Add(potato);

            // ...
        }

        private Bowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private Potato GetPotato()
        {
            throw new NotImplementedException();
        }

        private void Peel(NaturalFood naturalFood)
        {
            throw new NotImplementedException();
        }

        private void Cut(NaturalFood naturalFood)
        {
            throw new NotImplementedException();
        }
    }
}