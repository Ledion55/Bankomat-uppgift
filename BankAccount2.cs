using System;

namespace Bankomat_uppgift
{
    public class BankAccount
    {
        public string AccountNumber { get; set; }
        public double Balance { get; set; }

        public BankAccount(string accountNumber)
        {
            AccountNumber = accountNumber;
            Balance = 0;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
            else
            {
                Console.WriteLine("Felaktigt belopp, försök igen.");
            }
        }

        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
            }
            else
            {
                Console.WriteLine("Felaktigt belopp, försök igen.");
            }
        }
    }
}