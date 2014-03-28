using System;
using System.Collections.Generic;
using System.Linq;

class Guitar
{
    static List<int> availableSteps = new List<int>();
    static int maxVolume;

    static void Main()
    {
        int N = int.Parse(Console.ReadLine());
        var steps = new List<int>(Console.ReadLine().Split(' ').Select(int.Parse).ToArray());

        var volume = int.Parse(Console.ReadLine());
        maxVolume = int.Parse(Console.ReadLine());

        AddIfInRange(availableSteps, steps[0], volume);

        var nextAvailableSteps = new List<int>();

        for (int i = 1; i < steps.Count; i++, nextAvailableSteps.Clear())
        {
            for (int j = 0; j < availableSteps.Count; j++)
                AddIfInRange(nextAvailableSteps, steps[i], availableSteps[j]);

            availableSteps = new HashSet<int>(nextAvailableSteps).ToList();
        }

        Console.WriteLine(availableSteps.Count > 0 ? availableSteps.Max() : -1);
    }

    static void AddIfInRange(IList<int> steps, int volume, int currentStep)
    {
        var next = currentStep + volume;
        var previous = currentStep - volume;

        if (next <= maxVolume)
            steps.Add(next);

        if (previous >= 0 && previous != next)
            steps.Add(previous);
    }
}