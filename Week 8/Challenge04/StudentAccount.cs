using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge04
{
    public class StudentAccount : Account
    {
       private double CreditLimit = 500000;

        public StudentAccount(string title, string number, double balance) : base(title, number, balance)

        {
        }

        public void StudentWithdraw(double amount)
        {
            if (amount <= Balance + CreditLimit)
            {
                Balance = amount;
                Console.WriteLine($"Withdrawn: {amount}. New balance: {Balance}");
            }
            else
            {
                Console.WriteLine("Exceeded student credit limit.");
            }
        }
    }
}
