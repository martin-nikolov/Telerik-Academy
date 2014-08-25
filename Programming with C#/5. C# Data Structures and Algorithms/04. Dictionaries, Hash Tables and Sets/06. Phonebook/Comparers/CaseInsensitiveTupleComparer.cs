namespace AbstractDataStructures.Comparers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CaseInsensitiveTupleComparer : IEqualityComparer<Tuple<string, string>>
    {
        public bool Equals(Tuple<string, string> x, Tuple<string, string> y)
        {
            return string.Equals(x.Item1, y.Item1, StringComparison.OrdinalIgnoreCase) &&
                   string.Equals(x.Item2, y.Item2, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode(Tuple<string, string> obj)
        {
            return obj.Item1.ToLowerInvariant().GetHashCode() + obj.Item2.ToLowerInvariant().GetHashCode();
        }
    }
}