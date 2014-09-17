namespace StudentSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using StudentSystem.Data;

    public class ConsoleClient
    {
        private static readonly StudentSystemData studentSystemData = new StudentSystemData();
        private static readonly DatabaseSeeder databaseSeeder = new DatabaseSeeder(studentSystemData);

        public static void Main()
        {
            //
            // IMPORTANT: Change connection string in "StudentSystem.Common/ConnectionStrings"
            //

            Console.Write("Seeding data in database...");
            databaseSeeder.SeedDataToDatabase();
            Console.WriteLine("\rData were seeded successfully!");
        }
    }
}