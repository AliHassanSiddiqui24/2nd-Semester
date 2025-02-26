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
                Console.WriteLine("***************************************************************");
                Console.WriteLine("                        UAMS                                   ");
                Console.WriteLine("***************************************************************");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Degree Program");
                Console.WriteLine("3. Generate Merit");
                Console.WriteLine("4. View Registered Students");
                Console.WriteLine("5. View Students of a Specific Program");
                Console.WriteLine("6. Register Subjects for a Specific Student");
                Console.WriteLine("7. Calculate Fees for all Registered Students");
                Console.WriteLine("8. Exit");
                Console.Write("Enter Option: ");

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
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region Menu Handlers
        static void AddStudent()
        {
            Console.Clear();
            StudentBL student = StudentUI.GetStudentInput();

            Console.Write("Enter how many preferences to enter: ");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter Preference {i + 1}: ");
                string programName = Console.ReadLine();
                DegreeProgramBL program = DegreeProgramDL.Programs.Find(p => p.Title == programName);
                if (program != null)
                {
                    student.Preferences.Add(program);
                }
            }

            StudentDL.Students.Add(student);
            Console.WriteLine("Student added successfully!");
            Console.ReadKey();
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
            // Calculate merit for all students
            foreach (StudentBL student in StudentDL.Students)
            {
                student.CalculateMerit();
            }

            // Sort students by merit
            StudentDL.Students.Sort((x, y) => y.Merit.CompareTo(x.Merit));

            // Allocate programs
            foreach (StudentBL student in StudentDL.Students)
            {
                foreach (DegreeProgramBL program in student.Preferences)
                {
                    if (program.Seats > 0 && student.RegisteredProgram == null)
                    {
                        student.RegisteredProgram = program;
                        program.Seats--;
                        break;
                    }
                }
            }

            Console.WriteLine("Merit list generated successfully!");
            Console.ReadKey();
        }

        static void ViewRegisteredStudents()
        {
            Console.Clear();
            Console.WriteLine("Name\tFSC\tECAT\tAge");
            foreach (StudentBL student in StudentDL.Students)
            {
                if (student.RegisteredProgram != null)
                {
                    Console.WriteLine($"{student.Name}\t{student.FSC}\t{student.ECAT}\t{student.Age}");
                }
            }
            Console.ReadKey();
        }

        static void ViewProgramStudents()
        {
            Console.Clear();
            Console.Write("Enter Degree Name: ");
            string degreeName = Console.ReadLine();

            Console.WriteLine($"Students in {degreeName}:");
            Console.WriteLine("Name\tFSC\tECAT\tAge");

            foreach (StudentBL student in StudentDL.Students)
            {
                if (student.RegisteredProgram != null && student.RegisteredProgram.Title == degreeName)
                {
                    Console.WriteLine($"{student.Name}\t{student.FSC}\t{student.ECAT}\t{student.Age}");
                }
            }
            Console.ReadKey();
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
            foreach (StudentBL student in StudentDL.Students)
            {
                if (student.RegisteredProgram != null)
                {
                    float total = 0;
                    foreach (SubjectBL subject in student.RegisteredSubjects)
                    {
                        total += subject.Fee;
                    }
                    Console.WriteLine($"{student.Name} Fee: {total}");
                }
            }
            Console.ReadKey();
        }
        #endregion
    }
}




