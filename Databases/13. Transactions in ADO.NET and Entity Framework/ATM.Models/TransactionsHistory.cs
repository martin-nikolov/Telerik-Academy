namespace ATM.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class TransactionsHistory
    {
        private CardAccount cardAccount;

        [Key]
        public int TransactionsHistoryId { get; set; }

        [Required]
        public DateTime TransactionDate { get; set; }

        [Required]
        public decimal Ammount { get; set; }

        public int CardAccountId { get; set; }

        public virtual CardAccount CardAccount
        {
            get
            {
                return this.cardAccount;
            }
            set
            {
                this.cardAccount = value;
            }
        }
    }
}