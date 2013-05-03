using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter first number: ");
        string firstNumber = Console.ReadLine();

        Console.Write("Enter second number: ");
        string secondNumber = Console.ReadLine();

        // To check if algorithm works correctly!
        //BigInteger num = new BigInteger();
        //num = BigInteger.Parse(firstNumber) + BigInteger.Parse(secondNumber);
        //Console.WriteLine(num);

        byte[] result;
        byte carry = 0;

        if (firstNumber.Length >= secondNumber.Length)
            result = new byte[firstNumber.Length + 1];
        else
            result = new byte[secondNumber.Length + 1];

        for (int i = 0; i < result.Length; i++)
        {
            if (i < firstNumber.Length && i < secondNumber.Length)
            {
                byte a = Convert.ToByte(firstNumber[firstNumber.Length - i - 1].ToString());
                byte b = Convert.ToByte(secondNumber[secondNumber.Length - i - 1].ToString());

                result[i] = (byte)((a + b + carry) % 10);

                if ((a + b + carry) > 9)
                    carry = 1;
                else
                    carry = 0;
            }
            else if (i < firstNumber.Length)
            {
                byte a = Convert.ToByte(firstNumber[firstNumber.Length - i - 1].ToString());
                result[i] = (byte)((a + carry) % 10);

                if ((a + carry) > 9)
                    carry = 1;
                else
                    carry = 0;
            }
            else if (i < secondNumber.Length)
            {
                byte b = Convert.ToByte(secondNumber[secondNumber.Length - i - 1].ToString());
                result[i] = (byte)((b + carry) % 10);

                if ((b + carry) > 9)
                    carry = 1;
                else
                    carry = 0;
            }
            else
            {
                result[i] = carry;
            }
        }

        bool isMetNumberDifferentByZero = false;

        for (int i = result.Length - 1; i >= 0; i--)
        {
            if (result[i] != 0)
                isMetNumberDifferentByZero = true;

            if (isMetNumberDifferentByZero)
                Console.Write(result[i]);
        }

        Console.WriteLine();
    }
}
