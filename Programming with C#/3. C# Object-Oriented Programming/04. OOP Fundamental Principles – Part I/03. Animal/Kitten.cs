using System;
using System.Linq;

class Kitten : Cat
{
    public Kitten(string name, uint age) : base(name, age, Sex.Female)
    {
    }

    public override string Sound()
    {
        return "Kitten sounds: miauuuuu";
    }
}