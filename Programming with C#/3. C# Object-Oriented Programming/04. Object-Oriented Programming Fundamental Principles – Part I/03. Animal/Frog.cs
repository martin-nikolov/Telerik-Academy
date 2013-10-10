using System;
using System.Linq;

class Frog : Animal
{
    public Frog(string name, uint age, Sex sex) : base(name, age, sex)
    {
    }

    public override string Sound()
    {
        return "Frog sounds: kua-kwa-kya";
    }
}