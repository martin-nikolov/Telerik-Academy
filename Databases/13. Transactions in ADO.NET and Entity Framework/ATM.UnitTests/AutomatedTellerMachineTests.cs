namespace ATM.UnitTests
{
    using System;
    using System.Linq;
    using ATM.Data;
    using ATM.Models.Mapping;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AutomatedTellerMachineTests
    {
        private static readonly AutomatedTellerMachineProxy automatedTellerMachine = new AutomatedTellerMachineProxy();
        private static readonly AutomatedTellerMachineContext automatedTellerMachineContext = new AutomatedTellerMachineContext();

        [TestMethod]
        public void TestOnExistingCardAccountAndValidAmountOfMoneyToRetrieve()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "0000",
                MoneyToRetrieve = 200
            };

            var oldTranHistoryCount = automatedTellerMachineContext.TransactionsHistories.Count();
            var oldCardCash = automatedTellerMachine.GetCardAccountCash(tranInfo.CardNumber);

            automatedTellerMachine.RetrieveMoney(tranInfo);

            var newTranHistoryCount = automatedTellerMachineContext.TransactionsHistories.Count();
            var newCardCash = automatedTellerMachine.GetCardAccountCash(tranInfo.CardNumber);

            Assert.AreEqual(oldTranHistoryCount + 1, newTranHistoryCount);
            Assert.AreEqual(oldCardCash - tranInfo.MoneyToRetrieve, newCardCash);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnExistingCardAccountAndInValidAmountOfMoneyToRetrieveShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "0000",
                MoneyToRetrieve = -200
            };
      
            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnTooLongCardNumberShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "CARD-NUMBER-TOO-LONG",
                CardPIN = "0000",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnTooShortCardNumberShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "SHORT",
                CardPIN = "0000",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnEmptyCardNumberShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = string.Empty,
                CardPIN = "0000",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnNullCardNumberShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = null,
                CardPIN = "0000",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnTooLongCardPinShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "0000000000000000",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnTooShortCardPinShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = "0",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnEmptyCardPinShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = string.Empty,
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestOnNullCardPinShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-111",
                CardPIN = null,
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidUnknownCardNumberShouldThrowArgumentException()
        {
            var tranInfo = new TransactionInfo()
            {
                CardNumber = "111-11-999",
                CardPIN = "0000",
                MoneyToRetrieve = 200
            };

            automatedTellerMachine.RetrieveMoney(tranInfo);
        }
    }
}