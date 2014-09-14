using System;
using System.Text;
using Wintellect.PowerCollections;

/// <summary>
/// Data Structures and Algorithms 2013 - http://bgcoder.com/Contests/Practice/Index/89
/// </summary>
/// <remarks>
/// Fast Add/Append/Insert at index -> BigList
/// Fast Add of duplicate items -> Bag
/// Fast Count/NumberOfCopies -> Bag
/// Fast Remove Range -> BigList
/// Fast Remove Many -> Bag
/// </remarks>
public class SupermarketQueue
{
    private static readonly BigList<string> queue = new BigList<string>();
    private static readonly Bag<string> names = new Bag<string>();
    private static readonly StringBuilder output = new StringBuilder();

    internal static void Main()
    {
        #if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
        #endif

        string line = Console.ReadLine();
        while (!line.StartsWith("End"))
        {
            var commands = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            ExecuteCommand(commands);
            line = Console.ReadLine();
        }

        Console.WriteLine(output.ToString().Trim() + Environment.NewLine + Environment.NewLine);
    }
 
    private static void ExecuteCommand(string[] commands)
    {
        switch (commands[0])
        {
            case "Append":
                {
                    ExecuteAppendCommand(commands);
                    break;
                }

            case "Insert":
                {
                    ExecuteInsertCommand(commands);
                    break;
                }

            case "Find":
                {
                    ExecuteFindCommand(commands);
                    break;
                }

            case "Serve":
                {
                    ExecuteServeCommand(commands);
                    break;
                }
        }
    }
 
    private static void ExecuteAppendCommand(string[] commands)
    {
        queue.Add(commands[1]);
        names.Add(commands[1]);
        PrintMessage("OK");
    }

    private static void ExecuteInsertCommand(string[] commands)
    {
        var position = int.Parse(commands[1]);
        if (position < 0 || position > queue.Count)
        {
            PrintMessage("Error");
            return;
        }

        queue.Insert(position, commands[2]);
        names.Add(commands[2]);
        PrintMessage("OK");
    }

    private static void ExecuteFindCommand(string[] commands)
    {
        PrintMessage(names.NumberOfCopies(commands[1]));
    }

    private static void ExecuteServeCommand(string[] commands)
    {
        var count = int.Parse(commands[1]);
        if (count > queue.Count)
        {
            PrintMessage("Error");
            return;
        }

        var servedPeople = queue.GetRange(0, count);
        queue.RemoveRange(0, count);
        names.RemoveMany(servedPeople);

        PrintMessage(string.Join(" ", servedPeople));
    }

    private static void PrintMessage(object message)
    {
        output.AppendLine(message.ToString());
    }
}