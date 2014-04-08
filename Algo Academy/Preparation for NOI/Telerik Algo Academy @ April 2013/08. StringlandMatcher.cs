using System;
using System.Text;

class StringlandMatcher
{
    static void Main()
    {
        string searchedString = Console.ReadLine();
        int K = int.Parse(Console.ReadLine());

        string text = Console.ReadLine();

        int index = text.IndexOf(searchedString), occurs = 0;
        var result = new StringBuilder();

        while (index != -1)
        {
            occurs++;
            result.AppendFormat("index: {0} - string: {1}\n", index, searchedString);

            index = text.IndexOf(searchedString, index + 1);
        }

        if (occurs != 0)
        {
            Console.WriteLine(occurs);
            Console.WriteLine(result);
        }
        else
        {
            Console.WriteLine("Not found!");
        }
    }
}