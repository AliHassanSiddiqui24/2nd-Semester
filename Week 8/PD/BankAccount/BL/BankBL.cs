using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankBL
    {
        private string accountNumber;
        private string ownername;
        private double balance;

        public BankBL()
            { }
        public BankBL(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }
        public BankBL(string accountNumber, string ownername, double balance)
        {
            this.accountNumber = accountNumber;
            this.ownername = ownername;
            this.balance = balance;
        }
        public string getAccountNumber()
        {
            return accountNumber;
        }
        public void setAccountNumber(string accountNumber)
        {
            this.accountNumber = accountNumber;
        }
        public string getOwnerName ()
        {
            return ownername;
        }
        public void setOwnerName(string ownername)
        {
            if (string.IsNullOrEmpty(ownername))
            {
                Console.WriteLine("Owner name cannot be null or empty");
                Console.ReadKey();
            }
            this.ownername = ownername;

        }
        public double getBalance()
        {
            return balance;
        }
        public void setBalance(double balance)
        {
            if (balance < 0)
            {
                Console.WriteLine("Balance cannot be negative");
                Console.ReadKey();
            }
            this.balance = balance;
        }
        public void deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive");
                Console.ReadKey();
            }
            balance = balance + amount;
        }
        public void withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdraw amount must be positive");
                Console.ReadKey();
            }
            if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance");
                Console.ReadKey();
            }
            balance = balance - amount;
        }
    }
}
