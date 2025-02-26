using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class DegreeProgramUI
    {
        public static DegreeProgramBL GetProgramInput()
        {
            DegreeProgramBL program = new DegreeProgramBL();
            Console.Write("Enter Degree Name: ");
            program.Title = Console.ReadLine();
            Console.Write("Enter Duration: ");
            program.Duration = Console.ReadLine();
            Console.Write("Enter Seats: ");
            program.Seats = int.Parse(Console.ReadLine());

            Console.Write("How many subjects to add: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                program.Subjects.Add(SubjectUI.GetSubjectInput());
            }
            return program;
        }
    }
}
