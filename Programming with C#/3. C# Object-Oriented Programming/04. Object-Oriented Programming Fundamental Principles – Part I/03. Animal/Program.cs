/*
* 3. Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define 
* useful constructors and methods. Dogs, frogs and cats are Animals.
* All animals can produce sound (specified by the ISound interface).
* Kittens and tomcats are cats. All animals are described by age,
* name and sex. Kittens can be only female and tomcats can be only 
* male. Each animal produces a specific sound. Create arrays of 
* different kinds of animals and calculate the average age of each
* kind of animal using a static method (you may use LINQ).
*/

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var animals = new List<Animal>()
        {
            new Dog("Sharo", 4, Sex.Male),
            new Dog("SomeDog", 5, Sex.Female),
            new Frog("Crazy frog", 50, Sex.Male),
            new Frog("Sick from", 2, Sex.Female),
        };

        var cats = new List<Cat>()
        {
            new Kitten("Queen", 5),
            new Kitten("Women", 2),
            new Tomcat("King", 3),
            new Tomcat("SomeCat", 2)
        };

        // Animals
        foreach (Animal animal in animals)
            Console.WriteLine("{0} | {1}", animal, animal.Sound());

        Console.WriteLine();

        // Cats
        foreach (Cat cat in cats)
            Console.WriteLine("{0} | {1}", cat, cat.Sound());

        Console.WriteLine();

        /* ----------------- */

        Console.WriteLine("Animals average age: {0}", animals.Average(animal => animal.Age));
        Console.WriteLine("Cats average age: {0}", cats.Average(cat => cat.Age));
    }
}