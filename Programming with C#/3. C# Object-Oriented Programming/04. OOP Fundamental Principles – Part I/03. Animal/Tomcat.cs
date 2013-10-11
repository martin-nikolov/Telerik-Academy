using System;
using System.Linq;

class Tomcat : Cat
{
    public Tomcat(string name, uint age) : base(name, age, Sex.Male)
    {
    }

    public override string Sound()
    {
        return "Tomcat sounds: miauuu";
    }
}