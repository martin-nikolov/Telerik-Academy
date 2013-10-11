using System;
using System.Linq;

interface IDeposit<T>
{
    T Deposit(decimal money);
}