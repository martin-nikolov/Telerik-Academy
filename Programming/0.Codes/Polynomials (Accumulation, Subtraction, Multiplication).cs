using System;

class Program
{
    static void Main(string[] args)
    {
        decimal[] firstPolynomial = EnterPolynomial(out firstPolynomial);
        Console.Write("Polynomial in normal form:");
        PrintPolynomialInNormalForm(firstPolynomial);

        Console.WriteLine();

        decimal[] secondPolynomial = EnterPolynomial(out secondPolynomial);
        Console.Write("Polynomial in normal form:");
        PrintPolynomialInNormalForm(secondPolynomial);

        Àccumulation(firstPolynomial, secondPolynomial);
        Subtraction(firstPolynomial, secondPolynomial);
        Multiplication(firstPolynomial, secondPolynomial);
    }

    internal static decimal[] EnterPolynomial(out decimal[] polynomial)
    {
        Console.Write("Enter your polynomial degree: ");
        byte degree = byte.Parse(Console.ReadLine());

        polynomial = new decimal[degree + 1];

        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            Console.Write("x^" + i + ": ");
            polynomial[i] = decimal.Parse(Console.ReadLine());
        }

        return polynomial;
    }

    internal static void PrintPolynomialInNormalForm(decimal[] polynomial)
    {
        for (int i = polynomial.Length - 1; i >= 0; i--)
        {
            if (i == polynomial.Length - 1 && polynomial[i] != 0)
            {
                Console.Write("     {0}{1}x^{2} ", polynomial[i] > 0 ? "" : "-", Math.Abs(polynomial[i]), i);
            }
            else if (i == 0)
            {
                if (polynomial[i] < 0)
                {
                    Console.Write("{0}{1} ", "- ", -polynomial[i]);
                }
                else if (polynomial[i] > 0)
                {
                    Console.Write("{0}{1} ", "+ ", polynomial[i]);
                }
            }
            else
            {
                if (polynomial[i] < 0)
                {
                    Console.Write("{0}{1}x^{2} ", "- ", -polynomial[i], i);
                }
                else if (polynomial[i] > 0)
                {
                    Console.Write("{0}{1}x^{2} ", "+ ", polynomial[i], i);
                }
            }
        }

        Console.WriteLine();
    }

    internal static void Àccumulation(decimal[] firstPolynomial, decimal[] secondPolynomial)
    {
        Console.WriteLine(Environment.NewLine + new string('-', 40));
        PrintPolynomialInNormalForm(firstPolynomial);
        Console.WriteLine("   +");
        PrintPolynomialInNormalForm(secondPolynomial);
        Console.WriteLine("   =");

        byte bestLenght = 0;
        bool isFirstBigger = false;
        bool isSecondBigger = false;
        bool isZero = true;

        if (firstPolynomial.Length >= secondPolynomial.Length)
        {
            bestLenght = (byte)firstPolynomial.Length;
            isFirstBigger = true;
        }
        else
        {
            bestLenght = (byte)secondPolynomial.Length;
            isSecondBigger = true;
        }

        decimal[] result = new decimal[bestLenght];

        for (int i = 0; i < bestLenght; i++)
        {
            if (i < firstPolynomial.Length && i < secondPolynomial.Length)
            {
                result[i] = firstPolynomial[i] + secondPolynomial[i];
                if (result[i] != 0)
                    isZero = false;
            }
            else if (isFirstBigger)
            {
                result[i] = firstPolynomial[i];
            }
            else if (isSecondBigger)
            {
                result[i] = secondPolynomial[i];
            }
        }
        if (isZero)
            Console.Write("     0" + Environment.NewLine);
        else
            PrintPolynomialInNormalForm(result);
    }

    internal static void Subtraction(decimal[] firstPolynomial, decimal[] secondPolynomial)
    {
        Console.WriteLine(Environment.NewLine + new string('-', 20) + Environment.NewLine);
        PrintPolynomialInNormalForm(firstPolynomial);
        Console.WriteLine("   -");
        PrintPolynomialInNormalForm(secondPolynomial);
        Console.WriteLine("   =");

        byte bestLenght = 0;
        bool isFirstBigger = false;
        bool isSecondBigger = false;
        bool isZero = true;

        if (firstPolynomial.Length >= secondPolynomial.Length)
        {
            bestLenght = (byte)firstPolynomial.Length;
            isFirstBigger = true;
        }
        else
        {
            bestLenght = (byte)secondPolynomial.Length;
            isSecondBigger = true;
        }

        decimal[] result = new decimal[bestLenght];

        for (int i = 0; i < bestLenght; i++)
        {
            if (i < firstPolynomial.Length && i < secondPolynomial.Length)
            {
                result[i] = firstPolynomial[i] - secondPolynomial[i];

                if (result[i] != 0)
                    isZero = false;
            }
            else if (isFirstBigger)
            {
                result[i] = firstPolynomial[i];
            }
            else if (isSecondBigger)
            {
                result[i] = -secondPolynomial[i];
            }
        }

        if (isZero)
            Console.Write("     0" + Environment.NewLine);
        else
            PrintPolynomialInNormalForm(result);
    }

    internal static void Multiplication(decimal[] firstPolynomial, decimal[] secondPolynomial)
    {
        Console.WriteLine(Environment.NewLine + new string('-', 20) + Environment.NewLine);
        PrintPolynomialInNormalForm(firstPolynomial);
        Console.WriteLine("   *");
        PrintPolynomialInNormalForm(secondPolynomial);
        Console.WriteLine("   =");

        decimal[] result = new decimal[firstPolynomial.Length + secondPolynomial.Length - 1];

        for (int i = 0; i < firstPolynomial.Length; i++)
        {
            for (int j = 0; j < secondPolynomial.Length; j++)
            {
                int position = i + j;
                result[position] += (firstPolynomial[i] * secondPolynomial[j]);
            }
        }

        PrintPolynomialInNormalForm(result);

        Console.WriteLine(new string('-', 40));
    }
}
