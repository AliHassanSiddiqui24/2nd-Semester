using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to the Bank System ===");
                Console.WriteLine("1. Student Account");
                Console.WriteLine("2. Saving Account");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        ManageStudentAccount();
                        break;
                    case 2:
                        ManageSavingAccount();
                        break;
                    case 3:
                        Console.WriteLine("Thank you for using the system. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void ManageStudentAccount()
        {
            Console.WriteLine("\n=== Student Account ===");

            Console.Write("Enter account title: ");
            string title = Console.ReadLine();
            Console.Write("Enter account number: ");
            string number = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            double balance = double.Parse(Console.ReadLine());

            StudentAccount studentAccount = new StudentAccount(title, number, balance);
            studentAccount.ShowInfo();

            PerformAccountOperations(studentAccount);
        }

        static void ManageSavingAccount()
        {
            Console.WriteLine("\n=== Saving Account ===");

            Console.Write("Enter account title: ");
            string title = Console.ReadLine();
            Console.Write("Enter account number: ");
            string number = Console.ReadLine();
            Console.Write("Enter initial balance: ");
            double balance = double.Parse(Console.ReadLine());
            Console.Write("Enter interest rate: ");
            double interestRate = double.Parse(Console.ReadLine());

            SavingAccount savingAccount = new SavingAccount(title, number, balance, interestRate);
            savingAccount.ShowInfo();

            PerformAccountOperations(savingAccount);
        }

        static void PerformAccountOperations(Account account)
        {
            bool continueOperations = true;

            while (continueOperations)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Show Account Info");
                Console.WriteLine("4. Add Interest (Only for Saving Account)");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("Choose an option: ");
                int operationChoice = int.Parse(Console.ReadLine());

                switch (operationChoice)
                {
                    case 1:
                        Console.Write("Enter deposit amount: ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        account.Deposit(depositAmount);
                        break;
                    case 2:
                        Console.Write("Enter withdrawal amount: ");
                        double withdrawalAmount = double.Parse(Console.ReadLine());
                        account.Withdraw(withdrawalAmount);
                        break;
                    case 3:
                        account.ShowInfo();
                        break;
                    case 4:
                        if (account is SavingAccount savingAccount)
                        {
                            savingAccount.AddInterest();
                        }
                        else
                        {
                            Console.WriteLine("Interest can only be added to Saving Accounts.");
                        }
                        break;
                    case 5:
                        continueOperations = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

    

