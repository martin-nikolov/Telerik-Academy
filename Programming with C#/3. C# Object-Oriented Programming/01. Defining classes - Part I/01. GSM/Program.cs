/*
* 1. Define a class that holds information about a mobile phone
* device: model, manufacturer, price, owner, battery characteristics
* (model, hours idle and hours talk) and display characteristics
* (size and number of colors). Define 3 separate classes (class GSM 
* holding instances of the classes Battery and Display).
* 
* 2. Define several constructors for the defined classes that take
* different sets of arguments (the full information for the class or
* part of it). Assume that model and manufacturer are mandatory 
* (the others are optional). All unknown data fill with null.
* 
* 3. Add an enumeration BatteryType (Li-Ion, NiMH, NiCd, …) and use
* it as a new field for the batteries.
* 
* 4. Add a method in the GSM class for displaying all information about it.
* Try to override ToString().
* 
* 5. Use properties to encapsulate the data fields inside the GSM, Battery
* and Display classes. Ensure all fields hold correct data at any given time.
* 
* 6. Add a static field and a property IPhone4S in the GSM class to 
* hold the information about iPhone 4S.
*/

using System;
using System.Linq;
using MobilePhone.Test;

class Program
{
    static void Main()
    {
        GSM_Test.TestRunner();
        Console.WriteLine(new string('-', 80) + "\n");
        CallHistory_Test.TestRunner();
    }
}