namespace ATM.ConsoleClient
{
    using System;
    using System.Linq;
    using ATM.Data;
    using ATM.Models.Mapping;

    public class AtmConsoleClient
    {
        private static readonly AutomatedTellerMachineProxy automatedTellerMachine = new AutomatedTellerMachineProxy();

        public static void Main()
        {
            // IMPORTANT: Change your connection string -> ATM.Data.ConnectionStrings

            Console.Write("Loading...");

            // Valid transaction
            PerformTransaction(new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "0000",
                MoneyToRetrieve = 200
            });

            // Aborted transaction - invalid card number
            PerformTransaction(new TransactionInfo()
            {
                CardNumber = "111-11-11",
                CardPIN = "0000",
                MoneyToRetrieve = 200
            });

            // Aborted transaction - invalid card pin
            PerformTransaction(new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "00002",
                MoneyToRetrieve = 200
            });

            // Aborted transaction - invalid money to draw
            PerformTransaction(new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "0000",
                MoneyToRetrieve = -200
            });

            // Other scenarios -> see UnitTests
        }

        private static void PerformTransaction(TransactionInfo tranInfo)
        {
            try
            {
                automatedTellerMachine.RetrieveMoney(tranInfo);
                Console.WriteLine("\rSuccessful transaction!");
            }
            catch (Exception e)
            {
                Console.WriteLine("\r" + e.Message);
            }
        }
    }
}