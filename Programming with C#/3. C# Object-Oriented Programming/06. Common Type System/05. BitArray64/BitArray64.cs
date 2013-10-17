using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class BitArray64 : IEnumerable<int>
{
    private ulong bitValue64 = 0;

    public BitArray64(ulong number = 0)
    {
        this.bitValue64 = number;
    }

    public ulong this[int index]
    {
        get
        {
            if (index < 0 || index >= 64)
                throw new IndexOutOfRangeException("Index must be in interval [0; 64)!");

            return ((this.bitValue64 >> index) & 1);
        }
        set
        {
            if (index < 0 || index >= 64)
                throw new IndexOutOfRangeException("Index must be in interval [0; 64)!");

            if (value < 0 || value > 1)
                throw new ArgumentException("Value can be only 0 or 1!");

            // Clear the bit at position index
            this.bitValue64 &= ~(ulong)(1 << index);

            // Set the bit at position index to value
            this.bitValue64 |= value << index;
        }
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 63; i >= 0; i--)
            yield return (int)(this.bitValue64 >> i) & 1;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override int GetHashCode()
    {
        int hashCode = 17;

        unchecked
        {
            foreach (int item in this)
                hashCode = hashCode * 23 + item.GetHashCode();
        }

        return hashCode;
    }

    public override bool Equals(object obj)
    {
        if (obj == null)
            return false;

        return this.bitValue64.Equals((obj as BitArray64).bitValue64);
    }

    public static bool operator ==(BitArray64 bitValue1, BitArray64 bitValue2)
    {
        return bitValue1.Equals(bitValue2);
    }

    public static bool operator !=(BitArray64 bitValue1, BitArray64 bitValue2)
    {
        return !bitValue1.Equals(bitValue2);
    }

    public override string ToString()
    {
        StringBuilder info = new StringBuilder();

        info.Append("Binary: ");

        for (int i = 63; i >= 0; i--)
        {
            info.Append((this.bitValue64 >> i) & 1);

            if (i % 4 == 0)
                info.AppendFormat(" ");
        }

        info.AppendLine("\nDecimal: " + this.bitValue64);

        return info.ToString();
    }
}