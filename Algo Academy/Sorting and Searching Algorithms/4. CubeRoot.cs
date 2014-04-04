using System;
using System.Linq;
using System.Numerics;

class CubeRoot
{
    static void Main()
    {
        Console.WriteLine(FindCubeRootAnswer(BigInteger.Parse(Console.ReadLine()))); 
    }
  
    static BigInteger FindCubeRootAnswer(BigInteger number)
    {
        BigInteger min = 0, max = number, middle = 0;

        while (min <= max)
        {
            middle = (min + max) / 2;

            BigInteger cubeRoot = middle * middle * middle;

            if (cubeRoot == number)
            {
                break;
            }
            else if (cubeRoot > number)
            {
                max = middle - 1;
            }
            else
            {
                min = middle + 1;
            }
        }

        return middle;
    }
}