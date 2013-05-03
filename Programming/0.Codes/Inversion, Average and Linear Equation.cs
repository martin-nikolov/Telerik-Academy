using System;

class Program
{
    //Inversion
    static void InvertNumber(long number)
    {
        long invNumber = 0;
        int pow = 10;

        while (number != 0)
        {
            invNumber = invNumber * pow + number % 10;
            number = number / 10;
        }

        Console.WriteLine("Inverted number -> " + invNumber);
    }

    //Average of sequence numbers
    static void AverageSequenceNumbers(double[] arrNumbers)
    {
        double sum = 0;

        for (int i = 0; i < arrNumbers.Length; i++)
        {
            sum = sum + arrNumbers[i];
        }

        Console.WriteLine("Avarage of " + sum + " is " + sum / arrNumbers.Length);
    }

    //Linear equation
    static void LinearEquation(double a, double b)
    {
        Console.WriteLine("Result - > x = {0}", -b / a);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Enter: ");
        Console.WriteLine("     1 - for Inversion of integer number");
        Console.WriteLine("     2 - for Average of sequence numbers");
        Console.WriteLine("     3 - for Linear equation -> a * x + b" + "\n");

        Console.Write("Enter your choice: ");
        string choice = Console.ReadLine();
        Console.WriteLine();

        if (choice == "1") //Inversion
        {
            long number;
            bool validNumber;

            do
            {
                Console.Write("Enter integer number bigger than 0: ");
                //Check for valid input (number)
                validNumber = Int64.TryParse(Console.ReadLine(), out number);

                if (!validNumber || number < 0)
                {
                    Console.WriteLine("Invalid number! Enter number again...");
                    Console.WriteLine();
                }
            }
            while (validNumber != true || number < 0);

            //Call Method
            InvertNumber(number);
        }
        else if (choice == "2") //Average
        {
            long length;
            bool validLength;

            do
            {
                Console.Write("Number of digits (number bigger than 0): ");
                //Check for valid input (number).
                validLength = Int64.TryParse(Console.ReadLine(), out length);

                if (!validLength || length <= 0)
                {
                    Console.WriteLine("Invalid number! Enter number again...");
                    Console.WriteLine();
                }
            }
            while (validLength != true || length <= 0);

            double[] arrNumbers = new double[length];

            //Initialization
            Console.WriteLine("\n" + "Enter numbers bigger than 0...");
            for (int i = 0; i < arrNumbers.Length; i++)
            {
                bool validNumber;

                do
                {
                    Console.Write("Number[{0}] = ", i + 1);
                    //Check for valid input (number).
                    validNumber = double.TryParse(Console.ReadLine(), out arrNumbers[i]);

                    if (!validNumber)
                    {
                        Console.WriteLine("Invalid number! Enter number again...");
                    }
                }
                while (validNumber != true);
            }

            //Call Method
            AverageSequenceNumbers(arrNumbers);
        }
        else if (choice == "3") //Linear equation
        {
            double a;
            bool validNumber;

            do
            {
                Console.Write("Enter number of senior coefficient 'a' (different from 0): ");
                //Check for valid input (number).
                validNumber = double.TryParse(Console.ReadLine(), out a);

                if (!validNumber || a == 0)
                {
                    Console.WriteLine("Invalid number! Enter number again...");
                    Console.WriteLine();
                }
            }
            while (validNumber != true || a == 0);

            double b;

            Console.WriteLine();
            do
            {
                Console.Write("Enter number of available member 'b': ");
                //Check for valid input (number).
                validNumber = double.TryParse(Console.ReadLine(), out b);

                if (!validNumber)
                {
                    Console.WriteLine("Invalid number! Enter number again...");
                    Console.WriteLine();
                }
            }
            while (validNumber != true);

            LinearEquation(a, b);
        }
        else
        {
            Console.WriteLine("Invalid input data!");
        }
    }
}
