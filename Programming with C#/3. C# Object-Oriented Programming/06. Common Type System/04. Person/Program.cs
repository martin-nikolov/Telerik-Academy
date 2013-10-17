/*
* 4. Create a class Person with two fields – name and age. Age
* can be left unspecified (may contain null value). 
* 
* Override ToString() to display the information of a person 
* and if age is not specified – to say so. 
* 
* Write a program to test this functionality.
*/

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        var person1 = new Person("Ivan", null);

        Console.WriteLine(person1);

        var person2 = new Person("Peter", 25);

        Console.WriteLine(person2);
    }
}