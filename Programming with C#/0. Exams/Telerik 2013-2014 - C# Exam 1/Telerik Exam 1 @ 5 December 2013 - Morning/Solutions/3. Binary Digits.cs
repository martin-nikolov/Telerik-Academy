using System;
using System.Linq;
using System.Text;

class BinaryDigits
{
    static string[] zero = new string[] { "###", "#.#", "#.#", "###" };
    static string[] one = new string[] { ".#.", "##.", ".#.", "###" };
    static int numberOfBits = 16;

    static void Main()
    {
        var binary = Convert.ToString(int.Parse(Console.ReadLine()), 2);
        binary = binary.Length < 16 ? binary.PadLeft(numberOfBits, '0') : binary.Substring(binary.Length - numberOfBits);

        var result = new StringBuilder();

        for (int i = 0; i < zero.Length; i++)
        {
            for (int j = 0; j < binary.Length; j++)
            {
                result.Append((binary[j] == '0' ? zero[i] : one[i]) + ".");
            }

            result.Length--;
            result.AppendLine();
        }

        Console.Write(result);
    }
}