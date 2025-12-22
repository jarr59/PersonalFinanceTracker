using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceTracker.Domain.Transaction
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }
    }
}
