/*
* 7. Using delegates write a class Timer that has
* can execute certain method at each t seconds.
*/

using System;
using System.Linq;
using System.Threading;

class Program
{
    static void Main()
    {
        Ticker ticker = new Ticker(Timer.Action); // delegate -> action

        while (true)
        {
            Thread.Sleep(1000);
            ticker();
        }
    }
}