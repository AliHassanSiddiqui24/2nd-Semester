using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankUI
    {
        public static void transferFunds(BankBL bankAccount)
        {
            Console.WriteLine("Enter the account number to transfer funds to:");
            string accountNumber = Console.ReadLine();
            BankDL.searchAccount(accountNumber);
            Console.WriteLine("Enter the amount to transfer:");
            double amount = Double.Parse(Console.ReadLine());
            if (amount > 0)
            {
                bankAccount.deposit(amount);
                Console.WriteLine("Funds transferred successfully.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        public static void bankMenu()
        {
            Console.WriteLine("Welcome to the Bank");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Transfer Funds");
            Console.WriteLine("5. Search Account");
            Console.WriteLine("6. Exit");
            Console.WriteLine("Enter your choice:");
        }
        public static void createAccount()
        {
            Console.WriteLine("Enter account number:");
            string accountNumber = Console.ReadLine();
            Console.WriteLine("Enter owner name:");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Enter initial balance:");
            double balance = Double.Parse(Console.ReadLine());
            BankBL account = new BankBL(accountNumber, ownerName, balance);
            BankDL.addAccount(account);
            Console.WriteLine("Account created successfully.");
        }
        public static void deposit(BankBL bankAccount)
        {
            Console.WriteLine("Enter the amount to deposit:");
            double amount = Double.Parse(Console.ReadLine());
            if (amount > 0)
            {
                bankAccount.deposit(amount);
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        public static void withdraw(BankBL bankAccount)
        {
            Console.WriteLine("Enter the amount to withdraw:");
            double amount = Double.Parse(Console.ReadLine());
            if (amount > 0 && amount <= bankAccount.getBalance())
            {
                bankAccount.setBalance(bankAccount.getBalance() - amount);
                Console.WriteLine("Withdrawal successful.");
            }
            else
            {
                Console.WriteLine("Invalid amount.");
            }
        }
        public static void searchAccount(BankBL bankAccount)
        {
            Console.WriteLine("Enter the account number to search:");
            string accountNumber = Console.ReadLine();
            if (bankAccount.getAccountNumber() == accountNumber)
            {
                Console.WriteLine("Account found: " + bankAccount.getOwnerName());
                Console.WriteLine("Balance: " + bankAccount.getBalance());
            }
            else
            {
                Console.WriteLine("Account not found.");
            }

        }
    }
}
