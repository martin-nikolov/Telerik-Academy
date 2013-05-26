using System;

class AstrologicalDigits
{
    static void Main()
    {
        // Read the number and sum its digits
        ulong sumOfDigits = 0;
        while (true)
        {
            int ch = Console.Read();
            if (ch == (int)'\n' || ch == (int)'\r' || ch == -1)
            {
                // The input number is finished --> stop reading any more
                break;
            }
            if (ch >= '0' && ch <= '9')
            {
                ulong digit = (ulong)ch - (ulong)'0';
                sumOfDigits = sumOfDigits + digit;
            }
        }

        // Continue to sum the digits until a single digit is obtained
        while (sumOfDigits > 9)
        {
            ulong nextSumOfDigits = 0;
            while (sumOfDigits > 0)
            {
                ulong lastDigit = sumOfDigits % 10;
                nextSumOfDigits = nextSumOfDigits + lastDigit;
                sumOfDigits = sumOfDigits / 10;
            }
            sumOfDigits = nextSumOfDigits;
        }

        Console.WriteLine(sumOfDigits);
    }
}