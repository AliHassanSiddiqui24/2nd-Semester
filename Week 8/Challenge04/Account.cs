using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge04
{
    public class Account
    {
        public string AccountTitle;
        public string AccountNumber;
        public double Balance;

        public Account(string title, string number, double balance)
        {
            AccountTitle = title;
            AccountNumber = number;
            Balance = balance;
        }

        public void Deposit(double amount)
        {
            Balance = Balance + amount;
            Console.WriteLine($"Deposited: {amount}. New balance: {Balance}");
        }

        public void Withdraw(double amount)
        {
            if (amount <= Balance)
            {
                Balance = Balance - amount;
                Console.WriteLine($"Withdrawn: {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Insufficient balance.");
            }
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Account: {AccountTitle}, Number: {AccountNumber}, Balance: {Balance}");
        }
    }
}
