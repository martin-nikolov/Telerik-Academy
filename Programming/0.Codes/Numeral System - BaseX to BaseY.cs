using System;

class Program
{
    //Fifth Methid <- Fourth Method
    static char GetChar(int remainder)
    {
        //When we work with Integer, we compare with Integer value (BUT NOT WITH SYMBOLS)
        //Symbols starts with (Remainder >= 10)
        if (remainder >= 10)
            return (char)('A' + remainder - 10);
        else
            return (char)('0' + remainder);
    }

    //Fourth Method
    static string DecToBaseY(int dec, int baseY)
    {
        string decToY = string.Empty;

        while (dec != 0)
        {
            decToY = GetChar(dec % baseY) + decToY; //Fouth Method -> Fifth Method
            dec = dec / baseY;
        }

        return decToY;
    }

    //Third Method <- Second Method
    static int GetNumber(string num, int i)
    {
        //When we work with symbols, we work with their UNICODE
        if (num[i] >= 'A')
            return num[i] - 'A' + 10;
        else
            return num[i] - '0';
    }

    //Second Method
    static int BaseXtoDec(string num, int baseX)
    {
        int decNum = 0;

        for (int i = num.Length - 1, pow = 1; i >= 0; i--, pow *= baseX)
            decNum = decNum + GetNumber(num, i) * pow;   //Second Method -> Third Method     

        return decNum;
    }

    //First Method -> Second Method
    static string BaseXtoBaseY(string num, int baseX, int baseY)
    {
        return DecToBaseY(BaseXtoDec(num, baseX), baseY);
    }

    static void Main(string[] args)
    {
        //Example
        Console.WriteLine(BaseXtoBaseY("2273417", 8, 36)); //DAMN
    }
}
