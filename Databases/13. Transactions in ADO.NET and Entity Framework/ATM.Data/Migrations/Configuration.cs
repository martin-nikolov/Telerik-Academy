namespace ATM.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ATM.Models;

    public sealed class Configuration : DbMigrationsConfiguration<AutomatedTellerMachineContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(AutomatedTellerMachineContext context)
        {
            if (context.CardAccounts.Any())
            {
                return;
            }

            context.CardAccounts.Add(new CardAccount()
            {
                CardNumber = "111-11-111",
                CardPIN = "0000",
                CardCash = 10000.00m
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardNumber = "111-11-222",
                CardPIN = "1111",
                CardCash = 1000.00m
            });

            context.CardAccounts.Add(new CardAccount()
            {
                CardNumber = "111-11-333",
                CardPIN = "2222",
                CardCash = 500.00m
            });
        }
    }
}