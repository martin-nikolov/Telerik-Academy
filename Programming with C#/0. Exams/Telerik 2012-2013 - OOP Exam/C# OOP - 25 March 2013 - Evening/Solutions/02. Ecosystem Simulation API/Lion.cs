namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    class Lion : Animal, ICarnivore
    {
        private const int LionSize = 6;

        public Lion(string name, Point location)
            : base(name, location, LionSize)
        {
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (this.Size >= animal.Size / 2)
                {
                    this.Size += 1;
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}