using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Lily's age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter the price of the washing machine: ");
            double washingMachinePrice = double.Parse(Console.ReadLine());

            Console.Write("Enter the price of each toy: ");
            int toyPrice = int.Parse(Console.ReadLine());

            int toyCount = 0;
            double totalMoneySaved = 0;
            double birthdayMoney = 10;

            for (int birthday = 1; birthday <= age; birthday++)
            {
                if (birthday % 2 == 0)
                {
                    totalMoneySaved = totalMoneySaved + birthdayMoney;
                    birthdayMoney = birthdayMoney + 10;
                    totalMoneySaved = totalMoneySaved - 1;
                }
                else
                {
                    toyCount++;
                }
            }

            double toyMoney = toyCount * toyPrice;
            totalMoneySaved = totalMoneySaved + toyMoney;
            double greater = totalMoneySaved - washingMachinePrice;
            double lesser = washingMachinePrice - totalMoneySaved;
            if (totalMoneySaved >= washingMachinePrice)
            {
                Console.WriteLine("Yes! " + greater);
            }
            else
            {
                Console.WriteLine("No! " + lesser);
            }
        }
    }
}
