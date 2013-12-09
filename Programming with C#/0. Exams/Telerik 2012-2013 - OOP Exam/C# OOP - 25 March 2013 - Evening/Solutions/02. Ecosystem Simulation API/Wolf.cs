namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    class Wolf : Animal, ICarnivore
    {
        private const int WolfSize = 4;

        public Wolf(string name, Point location)
            : base(name, location, WolfSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= animal.Size || animal.State.Equals(AnimalState.Sleeping))
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}