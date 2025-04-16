using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                BankUI.bankMenu();
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        BankUI.createAccount();
                        break;
                    case "2":
                        Console.WriteLine("Enter account number:");
                        string accountNumber = Console.ReadLine();
                        BankBL account = BankDL.searchAccount(accountNumber);
                        if (account != null)
                        {
                            BankUI.deposit(account);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter account number:");
                        string accountNumberWithdraw = Console.ReadLine();
                        BankBL accountWithdraw = BankDL.searchAccount(accountNumberWithdraw);
                        if (accountWithdraw != null)
                        {
                            BankUI.withdraw(accountWithdraw);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case "4":
                        Console.WriteLine("Enter account number:");
                        string accountNumberTransfer = Console.ReadLine();
                        BankBL accountTransfer = BankDL.searchAccount(accountNumberTransfer);
                        if (accountTransfer != null)
                        {
                            BankUI.transferFunds(accountTransfer);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Enter account number:");
                        string searchAccountNumber = Console.ReadLine();
                        BankBL foundAccount = BankDL.searchAccount(searchAccountNumber);
                        if (foundAccount != null)
                        {
                            BankUI.searchAccount(foundAccount);
                        }
                        else
                        {
                            Console.WriteLine("Account not found.");
                        }
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
