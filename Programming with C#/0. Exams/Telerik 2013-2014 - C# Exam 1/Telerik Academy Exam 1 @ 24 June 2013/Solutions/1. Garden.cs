using System;
using System.Linq;

class Garden
{
    static void Main()
    {
        decimal[] amounts = new decimal[6]; // how many seeds he wants to plant
        int[] areas = new int[6]; // on what area he want to plant those seeds

        for (int i = 0; i < 5; i++)
        {
            amounts[i] = decimal.Parse(Console.ReadLine());
            areas[i] = int.Parse(Console.ReadLine());
        }
        amounts[5] = decimal.Parse(Console.ReadLine()); // beans seeds

        decimal totalCost = amounts[0] * 0.5m + amounts[1] * 0.4m + amounts[2] * 0.25m +
                            amounts[3] * 0.6m + amounts[4] * 0.3m + amounts[5] * 0.4m;

        int totalArea = areas.Sum();
        int beansArea = 250 - totalArea;

        Console.WriteLine("Total costs: {0:0.00}", totalCost);

        if (totalArea > 250)
        {
            Console.WriteLine("Insufficient area");
        }
        else if (beansArea <= 0) // calculate beans area
        {
            Console.WriteLine("No area for beans");
        }
        else
        {
            Console.WriteLine("Beans area: {0}", beansArea);
        }
    }
}