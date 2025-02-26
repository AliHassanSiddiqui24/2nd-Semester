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
            student.Age = int.Parse(Console.ReadLine());
            Console.Write("Enter FSC Marks: ");
            student.FSC = float.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks: ");
            student.ECAT = float.Parse(Console.ReadLine());
            return student;
        }
    }
}
