namespace Memento
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var sale = new SalesProspect { Name = "Noel van Halen", Phone = "(412) 256-0990", Budget = 25000.0 };

            // Store internal state
            var memory = new ProspectMemory();
            memory.Memento = sale.SaveMemento();

            // Continue changing originator
            sale.Name = "Leo Welch";
            sale.Phone = "(310) 209-7111";
            sale.Budget = 1000000.0;

            // Restore saved state
            sale.RestoreMemento(memory.Memento);
        }
    }
}
