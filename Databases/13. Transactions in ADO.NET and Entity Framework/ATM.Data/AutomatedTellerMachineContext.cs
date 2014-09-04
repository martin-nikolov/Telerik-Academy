namespace ATM.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using ATM.Data.Migrations;
    using ATM.Models;

    public class AutomatedTellerMachineContext : DbContext
    {
        public AutomatedTellerMachineContext()
            : base(ConnectionStrings.Default.MSQLConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AutomatedTellerMachineContext, Configuration>());
        }

        public IDbSet<CardAccount> CardAccounts { get; set; }

        public IDbSet<TransactionsHistory> TransactionsHistories { get; set; }
    }
}