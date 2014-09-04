namespace ATM.Data
{
    using System;
    using System.Data;
    using System.Linq;
    using ATM.Models;
    using ATM.Models.Mapping;

    public class AutomatedTellerMachineProxy
    {
        private static AutomatedTellerMachineContext automatedTellerMachineContext;
        private static ValidationController validationController;

        public AutomatedTellerMachineProxy()
        {
            automatedTellerMachineContext = new AutomatedTellerMachineContext();
            validationController = new ValidationController();
        }


        public void RetrieveMoney(TransactionInfo tranInfo)
        {
            using (var transaction = automatedTellerMachineContext.Database.BeginTransaction(IsolationLevel.RepeatableRead))
            {
                try
                {
                    if (!validationController.IsValidCardNumber(tranInfo.CardNumber))
                    {
                        throw new ArgumentException("Invalid card number. Current transaction is aborted!");
                    }

                    if (!validationController.IsValidCardPin(tranInfo.CardPIN))
                    {
                        throw new ArgumentException("Invalid Card PIN Code. Current transaction is aborted!");
                    }

                    var cardAccount = automatedTellerMachineContext.CardAccounts
                                                                   .FirstOrDefault(c => c.CardNumber == tranInfo.CardNumber);

                    if (cardAccount == null)
                    {
                        throw new ArgumentException("There is no Card account with the given Card number. Current transaction is aborted!");
                    }

                    if (!validationController.IsPinCodeMatches(tranInfo.CardPIN, cardAccount.CardPIN))
                    {
                        throw new ArgumentException("Chosen Card PIN Code does not matches the actual PIN Code of the card account. Current transaction is aborted!");
                    }

                    if (!validationController.IsPermittedWithdrawalAmount(tranInfo.MoneyToRetrieve, cardAccount.CardCash))
                    {
                        throw new ArgumentException("Invalid withdrawal money amount to retrieve. Current transaction is aborted!");
                    }

                    cardAccount.CardCash -= tranInfo.MoneyToRetrieve;

                    this.CreateTransactionHistoryReport(tranInfo, cardAccount);

                    transaction.Commit();
                    automatedTellerMachineContext.SaveChanges();
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw e;
                }
            }
        }
 
        public decimal GetCardAccountCash(string cardNumber)
        {
            var cardCash = automatedTellerMachineContext.CardAccounts.First(a => a.CardNumber == cardNumber).CardCash;
            return cardCash;            
        }

        private void CreateTransactionHistoryReport(TransactionInfo tranInfo, CardAccount cardAccount)
        {
            automatedTellerMachineContext.TransactionsHistories.Add(new TransactionsHistory()
            {
                Ammount = tranInfo.MoneyToRetrieve,
                TransactionDate = DateTime.Now,
                CardAccount = cardAccount
            });
        }
    }
}