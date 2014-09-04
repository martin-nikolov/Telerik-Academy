namespace ATM.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public class CardAccount
    {
        private const int CardNumberLength = 10;
        private const int CardPinLength = 4;

        private ICollection<TransactionsHistory> transactionHistory;

        public CardAccount()
        {
            this.transactionHistory = new HashSet<TransactionsHistory>();
        }

        [Key]
        public int CardAccountId { get; set; }

        [Required]
        [StringLength(CardNumberLength)]
        [Index(IsUnique = true)]
        public string CardNumber { get; set; }

        [Required]
        [StringLength(CardPinLength)]
        public string CardPIN { get; set; }

        public decimal CardCash { get; set; }

        public virtual ICollection<TransactionsHistory> TransactionHistory
        {
            get
            {
                return this.transactionHistory;
            }
            set
            {
                this.transactionHistory = value;
            }
        }

        public override string ToString()
        {
            return string.Format("CardAccountId: {0}, CardNumber: {1}, CardPIN: {2}, CardCash: {3}",
                this.CardAccountId, this.CardNumber, this.CardPIN, this.CardCash);
        }
    }
}