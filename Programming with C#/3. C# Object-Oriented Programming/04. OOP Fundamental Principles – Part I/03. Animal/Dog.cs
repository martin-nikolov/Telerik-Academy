using System;
using System.Linq;

class Dog : Animal
{
    public Dog(string name, uint age, Sex sex) : base(name, age, sex)
    {
    }

    public override string Sound()
    {
        return "Dog sounds: djaf-djaf-hhhrrrrr";
    }
}