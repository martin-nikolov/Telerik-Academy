namespace Adapter
{
    using System;

    internal class Program
    {
        internal static void Main(string[] args)
        {
            ICompound water = new RichCompound("Water");
            water.Display();

            ICompound benzene = new RichCompound("Benzene");
            benzene.Display();

            ICompound ethanol = new RichCompound("Ethanol");
            ethanol.Display();
        }
    }
}
