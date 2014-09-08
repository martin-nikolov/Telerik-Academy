namespace Company.DatabaseSeeder.Contracts
{
    using System;
    using System.Linq;

    public interface ISeeder
    {
        void SeedDatabaseWithRandomData();
    }
}