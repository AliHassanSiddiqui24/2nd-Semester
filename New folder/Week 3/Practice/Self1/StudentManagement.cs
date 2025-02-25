using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Self1
{
    public class StudentManagement
    {
        private List<Student> stu = new List<Student>();
        public void AddStudent()
        {
            Console.Write("Enter Rollno: ");
            int rollNo = int.Parse(Console.ReadLine());
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter GPA: ");
            float gpa = float.Parse(Console.ReadLine());
            Console.Write("Is the student a hostelite? (true/false)");
            bool isHostelite = bool.Parse(Console.ReadLine());
            Console.Write("Enter Department: ");
            string department = Console.ReadLine();

            stu.Add(new Student(rollNo, name, gpa, isHostelite, department));
            Console.WriteLine("Student Added Successfully");
        }
        public void ShowStudent()
        {
            if (stu.Count == 0)
            {
                Console.WriteLine("No students Available.\n");
                return;
            }
            Console.WriteLine("List of Students is as Follows");
            foreach (Student s in stu)
            {
                s.Display();
            }
            Console.ReadKey();
        }
        public void TopStudents()
        {
            if (stu.Count == 0)
            {
                Console.WriteLine("No students available.\n");
                return;
            }
            for(int i = 0; i<stu.Count -1; i++)
            {
                for(int j =0; j< stu.Count -1; j++)
                {
                    if(stu[j].Gpa< stu[j+1].Gpa)
                    {
                        Student temp = stu[j];
                        stu[j] = stu[j+1];
                        stu[j+1] = temp;
                    }
                }
            }
            for(int i=0;i<3;i++)
            {
                Console.WriteLine($"{stu[i].Name},{stu[i].Gpa}");
            }

        }
    }
}
