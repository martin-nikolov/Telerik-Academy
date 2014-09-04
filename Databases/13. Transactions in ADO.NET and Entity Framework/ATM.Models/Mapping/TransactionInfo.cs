namespace ATM.Models.Mapping
{
    using System;
    using System.Linq;

    public class TransactionInfo
    {
        public string CardNumber { get; set; }
 
        public string CardPIN { get; set; }

        public decimal MoneyToRetrieve { get; set; }
    }
}