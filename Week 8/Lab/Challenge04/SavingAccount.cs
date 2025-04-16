using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge04
{
    public class SavingAccount : Account
    {
        public double InterestRate { get; private set; }

        public SavingAccount(string title, string number, double balance, double interestRate) : base(title, number, balance)

        {
            InterestRate = interestRate;
        }


        public void AddInterest()
        {
            double interestAmount = Balance * (InterestRate / 100.0);
            Console.WriteLine($"Interest earned: {interestAmount:C}. Added to balance.");
            Deposit(interestAmount);
        }
        public override string ToString()
        {
            return base.ToString() + $", InterestRate: {InterestRate}%";
        }
    }
}
