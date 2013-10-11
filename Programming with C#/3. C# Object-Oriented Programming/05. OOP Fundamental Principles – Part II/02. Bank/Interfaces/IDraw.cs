using System;
using System.Linq;

interface IDraw<T>
{
    T WithDraw(decimal money);
}