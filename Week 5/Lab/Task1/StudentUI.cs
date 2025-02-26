using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class StudentUI
    {
        public static StudentBL GetStudentInput()
        {
            StudentBL student = new StudentBL();

            Console.Write("Enter Student Name: ");
            student.Name = Console.ReadLine();

            Console.Write("Enter Age: ");
            while (!int.TryParse(Console.ReadLine(), out student.Age))
            {
                Console.Write("Invalid input. Enter Age: ");
            }

            Console.Write("Enter FSC Marks: ");
            while (!float.TryParse(Console.ReadLine(), out student.FSC))
            {
                Console.Write("Invalid input. Enter FSC Marks: ");
            }

            Console.Write("Enter ECAT Marks: ");
            while (!float.TryParse(Console.ReadLine(), out student.ECAT))
            {
                Console.Write("Invalid input. Enter ECAT Marks: ");
            }

            return student;
        }
    }
}
