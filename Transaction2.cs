using System;

namespace Bankomat_uppgift
{
    public class Transaction
    {
        public string AccountNumber { get; set; }
        public string Type { get; set; } 
        public double Amount { get; set; }
        public DateTime Date { get; set; }

        public Transaction(string accountNumber, string type, double amount)
        {
            AccountNumber = accountNumber;
            Type = type;
            Amount = amount;
            Date = DateTime.Now;
        }
    }
}