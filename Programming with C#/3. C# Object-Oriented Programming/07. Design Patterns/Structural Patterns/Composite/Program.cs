namespace CompositePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Commander king = new Commander("Leonidas");

            Commander grandGeneral = new Commander("Xena The Princess Warrior");

            Commander generalProtos = new Commander("General Protos");

            Commander officerTonga = new Commander("Officer Tonga");
            officerTonga.Add(new Person("Kin"));
            officerTonga.Add(new Person("Briko"));
            officerTonga.Add(new Person("Zaler"));

            Commander officerHerin = new Commander("Officer Herin");
            officerHerin.Add(new Person("Gorok"));
            officerHerin.Add(new Person("Bozat"));
            officerHerin.Add(new Person("Koreb"));
            officerHerin.Add(new Person("Tikal"));
            officerHerin.Add(new Person("Mera"));

            Commander officerSalazar = new Commander("Officer Salazar");
            officerSalazar.Add(new Person("Kira"));
            officerSalazar.Add(new Person("Zaler"));
            officerSalazar.Add(new Person("Perin"));
            officerSalazar.Add(new Person("Subotli"));

            generalProtos.Add(officerHerin);
            generalProtos.Add(officerSalazar);
            generalProtos.Add(officerTonga);

            grandGeneral.Add(generalProtos);

            king.Add(grandGeneral);

            king.Display(1);
        }
    }
}