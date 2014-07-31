namespace Adapter
{
    using System;

    /// <summary>
    /// The 'Adapter' class
    /// </summary>
    internal class RichCompound : ICompound
    {
        private readonly string chemical;
        private readonly ChemicalDatabank bank;

        private readonly float boilingPoint;
        private readonly float meltingPoint;
        private readonly double molecularWeight;
        private readonly string molecularFormula;

        public RichCompound(string chemical)
        {
            this.chemical = chemical;
            this.bank = new ChemicalDatabank();

            this.boilingPoint = this.bank.GetCriticalPoint(this.chemical, "B");
            this.meltingPoint = this.bank.GetCriticalPoint(chemical, "M");
            this.molecularWeight = this.bank.GetMolecularWeight(chemical);
            this.molecularFormula = this.bank.GetMolecularStructure(chemical);
        }

        public void Display()
        {
            Console.WriteLine("Compound: {0} ------ ", this.chemical);
            Console.WriteLine(" Formula: {0}", this.molecularFormula);
            Console.WriteLine(" Weight : {0}", this.molecularWeight);
            Console.WriteLine(" Melting Pt: {0}", this.meltingPoint);
            Console.WriteLine(" Boiling Pt: {0}", this.boilingPoint);
            Console.WriteLine();
        }
    }
}
