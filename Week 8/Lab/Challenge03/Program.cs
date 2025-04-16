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
            List<Person> people = new List<Person>();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Person Management System ===");
                Console.WriteLine("1. Add a Person");
                Console.WriteLine("2. Add a Student");
                Console.WriteLine("3. Add a Staff");
                Console.WriteLine("4. Show All People");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddPerson(people);
                        break;
                    case 2:
                        AddStudent(people);
                        break;
                    case 3:
                        AddStaff(people);
                        break;
                    case 4:
                        ShowAllPeople(people);
                        break;
                    case 5:
                        Console.WriteLine("Thank you for using the Person Management System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
            }
        }

        static void AddPerson(List<Person> people)
        {
            Console.WriteLine("\nEnter details for Person:");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();

            Person person = new Person(name, address);
            people.Add(person);
            Console.WriteLine("Person added successfully!");
        }

        static void AddStudent(List<Person> people)
        {
            Console.WriteLine("\nEnter details for Student:");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter program: ");
            string program = Console.ReadLine();
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());
            Console.Write("Enter fee: ");
            double fee = double.Parse(Console.ReadLine());

            Student student = new Student(name, address, program, year, fee);
            people.Add(student);
            Console.WriteLine("Student added successfully!");
        }

        static void AddStaff(List<Person> people)
        {
            Console.WriteLine("\nEnter details for Staff:");
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            Console.Write("Enter address: ");
            string address = Console.ReadLine();
            Console.Write("Enter school: ");
            string school = Console.ReadLine();
            Console.Write("Enter pay: ");
            double pay = double.Parse(Console.ReadLine());

            Staff staff = new Staff(name, address, school, pay);
            people.Add(staff);
            Console.WriteLine("Staff added successfully!");
        }

        static void ShowAllPeople(List<Person> people)
        {
            if (people.Count == 0)
            {
                Console.WriteLine("No people available. Please add people first.");
                return;
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
    
}
