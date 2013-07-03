/*
* 6. Declare a boolean variable called isFemale and assign an
* appropriate value corresponding to your gender.
*/

using System;
 
class IsFemale
{
    static void Main()
    {
        Console.Write("Enter your gender (Male/Female): ");
        string gender = Console.ReadLine();

        switch (gender.ToLower())
        {
            case "female":
                Console.WriteLine("Yes, you are female!");
                break;
            case "male":
                Console.WriteLine("No, you are male!");
                break;
            default:
                Console.WriteLine("Incorrect input data!");
                break;
        }
    }
}