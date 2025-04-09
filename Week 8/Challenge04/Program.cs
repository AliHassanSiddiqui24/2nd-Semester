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
            Console.WriteLine("=== Student Account ===");
            StudentAccount student = new StudentAccount("Ali", "ST001", 1000);
            student.ShowInfo();
            student.StudentWithdraw(200000);
            student.Deposit(5000);
            student.ShowInfo();

            Console.WriteLine("\n=== Salary Account ===");
            SalaryAccount salary = new SalaryAccount("Sara", "SAL001", 5000);
            salary.ShowInfo();
            salary.Withdraw(1000);
            salary.Deposit(3000);
            salary.ShowInfo();

            Console.WriteLine("\n=== Saving Account ===");
            SavingAccount saving = new SavingAccount("Ahmed", "SAV001", 8000, 5);

            saving.ShowInfo();
            saving.Withdraw(9000);
            saving.Deposit(2000);
            saving.Withdraw(5000);
            saving.ShowInfo();
        }
    }
    
}
