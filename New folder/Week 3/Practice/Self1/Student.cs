using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self1
{
    public class Student
    {
        public int Rollno;
        public string Name;
        public float Gpa;
        public bool IsHostelide;
        public string Department;
        
        public Student(int rollno,string name,float gpa, bool ishostelide, string department )
        {
            Rollno = rollno;
            Name = name;
            Gpa = gpa;
            IsHostelide = ishostelide;
            Department = department;
        }
        public void Display()
        {
            Console.WriteLine($"Roll no: {Rollno}, Name: {Name}, GPA: {Gpa}, Hostelide: {IsHostelide}, Department: {Department}");
        }
    }
}
