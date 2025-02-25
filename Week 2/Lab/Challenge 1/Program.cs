using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    internal class Program
    {
        public static List<Student> students = new List<Student>();

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n1. Add Student\n2. Show Students\n3. Calculate Aggregate\n4. Top Students\n5. Exit");
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Student s = new Student();
                        s.AddStudent();
                        break;
                    case 2:
                        ShowStudents();
                        break;
                    case 3:
                        ShowAggregate();
                        break;
                    case 4:
                        ShowTopStudents();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Try again.");
                        break;
                }
            }
        }
       
        static void ShowStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("\nStudent List:");
            foreach (var s in students)
            {
                s.DisplayInfo();
            }
        }
        static void ShowAggregate()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }

            Console.WriteLine("\nAggregates:");
            foreach (var s in students)
            {
                Console.WriteLine($"{s.Name}: {s.Aggregate:F2}");
            }
        }
        static void ShowTopStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }
           List<Student> sortedStudents = students.OrderByDescending(s => s.Aggregate).ToList();

            Console.WriteLine("\nTop 3 Students:");
            foreach (Student s in sortedStudents.Take(3))
            {
                s.DisplayInfo();
            }
        }
    }
}
