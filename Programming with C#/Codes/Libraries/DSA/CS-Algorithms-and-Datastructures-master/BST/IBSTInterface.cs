using System;

namespace CodingPractice.BST
{
    public interface IBstInterface
    {
        int NumberOfNodes();
        void Insert(IComparable item);
        bool IsThere(IComparable item);
        IComparable Retrive(IComparable item);
    }
}