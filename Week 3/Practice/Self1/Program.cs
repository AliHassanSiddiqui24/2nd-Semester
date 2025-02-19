using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self1
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            StudentManagement sm= new StudentManagement();
            while (true)
            {
                Console.Clear();

                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Show Students");
                Console.WriteLine("3. Top Students");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        sm.AddStudent();
                        break;
                    case 2:
                        sm.ShowStudent();
                        break;
                    case 3:
                        sm.TopStudents();
                        break;
                    case 4:
                        Console.WriteLine("Exiting program...");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice...");
                        break;

                }
            }
            
        }
    }
}
