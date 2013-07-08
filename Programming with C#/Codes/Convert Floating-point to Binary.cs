using System;

class ConvertFloatingPointToBinary
{
    public static string DoubleToBinaryString(double d)
    {
        return Convert.ToString(BitConverter.DoubleToInt64Bits(d), 2);
    }

    public static double BinaryStringToDouble(string s)
    {
        return BitConverter.Int64BitsToDouble(Convert.ToInt64(s, 2));
    }

    public static string SingleToBinaryString(float f)
    {
        byte[] b = BitConverter.GetBytes(f);
        int i = BitConverter.ToInt32(b, 0);
        return Convert.ToString(i, 2);
    }

    public static float BinaryStringToSingle(string s)
    {
        int i = Convert.ToInt32(s, 2);
        byte[] b = BitConverter.GetBytes(i);
        return BitConverter.ToSingle(b, 0);
    }

    static void Main()
    {
        double d1 = 1234.5678;
        string ds = DoubleToBinaryString(d1);
        double d2 = BinaryStringToDouble(ds);

        float f1 = 654.321f;
        string fs = SingleToBinaryString(f1);
        float f2 = BinaryStringToSingle(fs);
    }
}