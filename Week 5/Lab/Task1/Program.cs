using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                ConsoleUtility.ShowMenu();

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        AddDegreeProgram();
                        break;
                    case "3":
                        GenerateMerit();
                        break;
                    case "4":
                        ViewRegisteredStudents();
                        break;
                    case "5":
                        ViewProgramStudents();
                        break;
                    case "6":
                        RegisterSubjects();
                        break;
                    case "7":
                        CalculateFees();
                        break;
                    case "8":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Option!");
                        ConsoleUtility.PressAnyKey();
                        break;
                }
            }
        }
        static void AddStudent()
        {
            Console.Clear();
            StudentBL student = StudentUI.GetStudentInput();
            Console.WriteLine("\nAvailable Degree Programs:");
            foreach (var program in DegreeProgramDL.Programs)
            {
                Console.WriteLine($"- {program.Title}");
            }

            Console.Write("\nEnter how many preferences to enter: ");
            int count;
            if (!int.TryParse(Console.ReadLine(), out count) || count < 1)
            {
                Console.WriteLine("Invalid input!");
                ConsoleUtility.PressAnyKey();
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter Preference {i + 1}: ");
                string programName = Console.ReadLine();
                DegreeProgramBL program = DegreeProgramDL.Programs.Find(p => p.Title == programName);
                if (program != null)
                {
                    student.Preferences.Add(program);
                }
                else
                {
                    Console.WriteLine($"Program '{programName}' not found.");
                    i--;
                }
            }

            StudentDL.Students.Add(student);
            Console.WriteLine("\nStudent added successfully!");
            ConsoleUtility.PressAnyKey();
        }

        static void AddDegreeProgram()
        {
            Console.Clear();
            DegreeProgramBL program = DegreeProgramUI.GetProgramInput();
            DegreeProgramDL.Programs.Add(program);
            Console.WriteLine("Degree program added successfully!");
            Console.ReadKey();
        }

        static void GenerateMerit()
        {
            Console.Clear();
            foreach (var student in StudentDL.Students)
            {
                student.CalculateMerit();
            }

            var sortedStudents = StudentDL.Students.OrderByDescending(s => s.Merit).ToList();

            foreach (var student in sortedStudents)
            {
                student.RegisteredProgram = null;
            }

            foreach (var student in sortedStudents)
            {
                foreach (var program in student.Preferences)
                {
                    if (program.Seats > 0)
                    {
                        student.RegisteredProgram = program;
                        program.Seats--;
                        break;
                    }
                }
            }

            Console.WriteLine("Admission Results:");
            foreach (var student in sortedStudents)
            {
                if (student.RegisteredProgram != null)
                {
                    Console.WriteLine($"{student.Name} got Admission in {student.RegisteredProgram.Title}");
                }
                else
                {
                    Console.WriteLine($"{student.Name} did not get Admission");
                }
            }

            ConsoleUtility.PressAnyKey();
        }


        static void ViewRegisteredStudents()
        {
            Console.Clear();
            Console.WriteLine("| Name     | FSC   | ECAT  | Age |");
            Console.WriteLine("|----------|-------|-------|-----|");
            foreach (var student in StudentDL.Students.Where(s => s.RegisteredProgram != null))
            {
                Console.WriteLine($"| {student.Name,-8} | {student.FSC,-5} | {student.ECAT,-5} | {student.Age,-3} |");
            }
            ConsoleUtility.PressAnyKey();
        }

        static void ViewProgramStudents()
        {
            Console.Clear();
            Console.Write("Enter Degree Name: ");
            string degreeName = Console.ReadLine();

            Console.WriteLine($"\nStudents in {degreeName}:");
            Console.WriteLine("| Name     | FSC   | ECAT  | Age |");
            Console.WriteLine("|----------|-------|-------|-----|");

            foreach (var student in StudentDL.Students.Where(s => s.RegisteredProgram?.Title == degreeName))
            {
                Console.WriteLine($"| {student.Name,-8} | {student.FSC,-5} | {student.ECAT,-5} | {student.Age,-3} |");
            }
            ConsoleUtility.PressAnyKey();
        }

        static void RegisterSubjects()
        {
            Console.Clear();
            Console.Write("Enter Student Name: ");
            string name = Console.ReadLine();

            StudentBL student = StudentDL.Students.Find(s => s.Name == name);
            if (student != null && student.RegisteredProgram != null)
            {
                Console.Write("Enter Subject Code: ");
                string code = Console.ReadLine();

                SubjectBL subject = student.RegisteredProgram.Subjects.Find(s => s.Code == code);
                if (subject != null)
                {
                    student.RegisteredSubjects.Add(subject);
                    Console.WriteLine("Subject registered successfully!");
                }
                else
                {
                    Console.WriteLine("Subject not found in registered program!");
                }
            }
            else
            {
                Console.WriteLine("Student not found or not registered in any program!");
            }
            Console.ReadKey();
        }

        static void CalculateFees()
        {
            Console.Clear();
            Console.WriteLine("Fees for Registered Students:");
            foreach (var student in StudentDL.Students)
            {
                if (student.RegisteredProgram != null)
                {
                    float totalFee = student.calculateFee();
                    Console.WriteLine($"{student.Name}: {totalFee} PKR");
                }
            }
            ConsoleUtility.PressAnyKey();
        }
    }
}




