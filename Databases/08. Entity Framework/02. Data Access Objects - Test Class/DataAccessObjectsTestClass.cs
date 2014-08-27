namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;
    using Northwind.Models;

    public class DataAccessObjectsTestClass
    {
        public static void Main()
        {
            Console.Write("Loading...");

            TestInsertMethod();
            TestModifyMethod();
            TestDeleteMethod();
        }

        private static void TestInsertMethod()
        {
            var customer = new Customer()
            {
                CustomerID = "TEST",
                CompanyName = "UNKNOWN",
                ContactName = "UNNAMED",
                ContactTitle = "NO-TITLE"
            };

            var affectedRows = DataAccessObjectsClass.InsertCustomer(customer);

            Console.WriteLine("\rInsert -> ({0} affected row(s))", affectedRows);
        }

        private static void TestModifyMethod()
        {
            var affectedRows = DataAccessObjectsClass.ModifyCustomerCompanyName("TEST", "NEW-NAME");

            Console.WriteLine("Modify -> ({0} affected row(s))", affectedRows);
        }

        private static void TestDeleteMethod()
        {
            var affectedRows = DataAccessObjectsClass.DeleteCustomer("TEST");

            Console.WriteLine("Delete -> ({0} affected row(s))", affectedRows);
        }
    }
}