using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Ali", "Pak Colony");
            Console.WriteLine(person);

            Student student = new Student("Hassan", "Uet Road", "Computer Science", 2, 20000.50);
            Console.WriteLine(student);

            Staff staff = new Staff("Siddiqui", "Khalid Hall", "High School", 3500.75);
            Console.WriteLine(staff);

            student.SetProgram("Data Science");
            student.SetYear(3);
            Console.WriteLine("Updated Student: " + student);

            staff.SetPay(4000.00);
            Console.WriteLine("Updated Staff: " + staff);
        }
    }
}
    
