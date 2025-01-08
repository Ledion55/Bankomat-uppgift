using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Bankomat_uppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BankAccount> accounts = LoadAccounts();

            bool running = true;

            while (running)
            {
                Console.WriteLine("1: Gör en insättning på ett konto");
                Console.WriteLine("2: Gör ett uttag på ett konto");
                Console.WriteLine("3: Visa saldot på ditt konto");
                Console.WriteLine("4: Skriv ut en lista på alla kontonr och saldon");
                Console.WriteLine("5: Visa alla transaktioner");
                Console.WriteLine("6: Avsluta programmet");

                int val = Convert.ToInt32(Console.ReadLine());

                switch (val)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Välj konto för att sätta in pengar (0-9):");
                        int accountIndex = Convert.ToInt32(Console.ReadLine());

                        if (accountIndex >= 0 && accountIndex < accounts.Count)
                        {
                            Console.WriteLine("Ange belopp att sätta in:");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            if (amount < 0)
                            {
                                Console.WriteLine("Felaktigt belopp, försök igen");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            accounts[accountIndex].Deposit(amount);
                            Console.WriteLine($"Du har satt in {amount}kr på {accounts[accountIndex].AccountNumber}. Nytt saldo: {accounts[accountIndex].Balance}");

                            SaveTransaction(new Transaction(accounts[accountIndex].AccountNumber, "Deposit", amount));
                            SaveAccounts(accounts);

                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt kontonummer.");
                        }
                        break;

                    case 2:
                        Console.Clear();
                        Console.WriteLine("Välj konto för att göra ett uttag (0-9):");
                        accountIndex = Convert.ToInt32(Console.ReadLine());

                        if (accountIndex >= 0 && accountIndex < accounts.Count)
                        {
                            Console.WriteLine("Ange belopp att ta ut:");
                            double amount = Convert.ToDouble(Console.ReadLine());

                            if (amount > accounts[accountIndex].Balance)
                            {
                                Console.WriteLine("Du har inte tillräckligt med pengar på kontot.");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }

                            accounts[accountIndex].Withdraw(amount);
                            Console.WriteLine($"Du har tagit ut {amount}kr från {accounts[accountIndex].AccountNumber}. Nytt saldo: {accounts[accountIndex].Balance}");

                            SaveTransaction(new Transaction(accounts[accountIndex].AccountNumber, "Withdraw", amount));
                            SaveAccounts(accounts);

                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt kontonummer.");
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("Välj konto för att visa saldo (0-9):");
                        accountIndex = Convert.ToInt32(Console.ReadLine());

                        if (accountIndex >= 0 && accountIndex < accounts.Count)
                        {
                            Console.Clear();
                            Console.WriteLine($"Saldo för {accounts[accountIndex].AccountNumber}: {accounts[accountIndex].Balance}kr");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Ogiltigt kontonummer.");
                        }
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("Lista på alla kontonr och saldon:");
                        for (int i = 0; i < accounts.Count; i++)
                        {
                            Console.WriteLine($"{accounts[i].AccountNumber}: {accounts[i].Balance}kr");
                        }
                        break;

                    case 5:
                        Console.Clear();
                        List<Transaction> transactions = LoadTransactions();
                        Console.WriteLine("Lista på alla transaktioner:");
                        foreach (var transaction in transactions)
                        {
                            Console.WriteLine($"Kontonummer: {transaction.AccountNumber}, Typ: {transaction.Type}, Belopp: {transaction.Amount}, Datum: {transaction.Date}");
                        }
                        Console.ReadKey();
                        Console.Clear();
                        break;

                    case 6:
                        Console.Clear();
                        running = false;
                        Console.WriteLine("Programmet avslutas.");
                        break;

                    default:
                        Console.WriteLine("Ogiltigt val. Försök igen.");
                        break;
                }
            }
        }

        public static void SaveTransaction(Transaction transaction)
        {
            string filename = "transactions.json";
            List<Transaction> transactions = new List<Transaction>();

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                transactions = JsonSerializer.Deserialize<List<Transaction>>(json);
            }

            transactions ??= new List<Transaction>();
            transactions.Add(transaction);

            string newJson = JsonSerializer.Serialize(transactions);
            File.WriteAllText(filename, newJson);
        }

        public static List<Transaction> LoadTransactions()
        {
            string filename = "transactions.json";
            List<Transaction> transactions = new List<Transaction>();

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                transactions = JsonSerializer.Deserialize<List<Transaction>>(json);
            }

            return transactions ?? new List<Transaction>();
        }

        public static void SaveAccounts(List<BankAccount> accounts)
        {
            string filename = "accounts.json";
            string json = JsonSerializer.Serialize(accounts);
            File.WriteAllText(filename, json);
        }

        public static List<BankAccount> LoadAccounts()
        {
            string filename = "accounts.json";
            List<BankAccount> accounts = new List<BankAccount>();

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(filename);
                accounts = JsonSerializer.Deserialize<List<BankAccount>>(json);
            }

            if (accounts == null || accounts.Count == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    accounts.Add(new BankAccount("Account" + i));
                }
            }

            return accounts;
        }
    }
}