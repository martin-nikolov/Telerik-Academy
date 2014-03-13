namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    public interface ISorter<T> where T : IComparable<T>
    {
        void Sort(IList<T> collection);
    }
}