namespace AcademyEcosystem
{
    using System;
    using System.Linq;

    public interface ICarnivore
    {
        int TryEatAnimal(Animal animal);
    }
}