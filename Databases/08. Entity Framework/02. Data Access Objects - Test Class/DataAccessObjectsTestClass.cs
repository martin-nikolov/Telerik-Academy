namespace EntityFramework.ConsoleClient
{
    using System;
    using System.Linq;

    class DataAccessObjectsTestClass
    {
        static void Main()
        {
            TestInsertMethod();
            TestModifyMethod();
            TestDeleteMethod();
        }

        static void TestInsertMethod()
        {
            var affectedRows = DataAccessObjectsClass.InsertCustomer("TEST", "UNKNOWN", "UNNAMED", "NO-TITLE");

            Console.WriteLine("Insert -> ({0} affected row(s))", affectedRows);
        }

        static void TestModifyMethod()
        {
            var affectedRows = DataAccessObjectsClass.ModifyCustomerCompanyName("TEST", "NEW-NAME");

            Console.WriteLine("Modify -> ({0} affected row(s))", affectedRows);
        }

        static void TestDeleteMethod()
        {
            var affectedRows = DataAccessObjectsClass.DeleteCustomer("TEST");

            Console.WriteLine("Delete -> ({0} affected row(s))", affectedRows);
        }
    }
}