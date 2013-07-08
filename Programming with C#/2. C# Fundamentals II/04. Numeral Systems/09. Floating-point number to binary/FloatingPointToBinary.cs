/*
* 9. *Write a program that shows the internal binary representation of given 32-bit signed
* floating-point number in IEEE 754 format (the C# type float). 
* Example: -27,25 -> sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.
*/

using System;

class FloatingPointToBinary
{
    static string FloatNumberToBinary(float number)
    {
        int dec = BitConverter.ToInt32(BitConverter.GetBytes(number), 0);

        return Convert.ToString(dec, 2);
    }

    static string GetExponent(string binary)
    {
        return binary.Substring(0, 8);
    }

    static string GetMantissa(string binary)
    {
        return binary.Substring(8);
    }

    static void Main()
    {
        Console.Write("Enter a floating-point number with single precision: ");
        float number = float.Parse(Console.ReadLine());

        int sign = number < 0 ? 1 : 0;
        number = Math.Abs(number);

        string binary = FloatNumberToBinary(number);

        Console.WriteLine("\nSign: {0} {1}", sign, sign == 1 ? "(minus)" : "(plus)");
        Console.WriteLine("Exponent: {0}", GetExponent(binary));
        Console.WriteLine("Mantissa: {0}\n", GetMantissa(binary));
    }
}