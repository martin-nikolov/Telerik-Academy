/*
* 3. A company has name, address, phone number, fax number, web site and manager.
* The manager has first name, last name, age and a phone number.
* Write a program that reads the information about a company and
* its manager and prints them on the console.
*/

using System;
using System.Linq;

class CompanyInformation
{
    static void Main()
    {
        Company Telerik = new Company()
        {
            Name = "Telerik",
            Address = "Sofia",
            PhoneNumber = "052/123456",
            FaxNumber = "0700/123456",
            WebSite = "htpp://telerik.com"
        };

        Telerik.Manager = new Company.CManager
        {
            FirstName = "Svetlin",
            LastName = "Nakov",
            Age = 34,
            PhoneNumber = "0888 123 456"
        };

        // Print information
        Telerik.PrintInformation();
        Telerik.Manager.PrintInformation();

        // NEW COMPANY ->
        Company userCompany = new Company(); // Declaration
        userCompany.InputData(); // Initialization

        userCompany.Manager = new Company.CManager(); // Declaration
        userCompany.Manager.InputData(); // Initialization

        // Print information
        userCompany.PrintInformation();
        userCompany.Manager.PrintInformation();
    }
}