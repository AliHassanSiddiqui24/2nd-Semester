using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Student
    {
        public string Name;
        public float MatricMarks;
        public float FscMarks;
        public float EcatMarks;
        public float Aggregate;
        public Student(string name, float matricMarks, float fscMarks, float ecatMarks)
        {
            Name = name;
            MatricMarks = matricMarks;
            FscMarks = fscMarks;
            EcatMarks = ecatMarks;
            CalculateAggregate();
        }
        public Student() { }    

        private void CalculateAggregate()
        {
            Aggregate = (MatricMarks * 0.1f) + (FscMarks * 0.4f) + (EcatMarks * 0.5f);
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Name: {Name}, Aggregate: {Aggregate:F2}");
        }
        public void AddStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Matric Marks: ");
            float matricMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter FSC Marks: ");
            float fscMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter ECAT Marks: ");
            float ecatMarks = float.Parse(Console.ReadLine());
            //Student s = new Student(name, matricMarks, fscMarks, ecatMarks);
            Program.students.Add(new Student(name, matricMarks, fscMarks, ecatMarks));
            Console.WriteLine("Student added successfully!");
        }
    }
}
