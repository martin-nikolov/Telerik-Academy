namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    class Boar : Animal, ICarnivore, IHerbivore
    {
        private const int BiteSize = 2;
        private const int BoarSize = 4;

        public Boar(string name, Point location)
            : base(name, location, BoarSize)
        {
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                this.Size += 1;
                return plant.GetEatenQuantity(BiteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= animal.Size)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}