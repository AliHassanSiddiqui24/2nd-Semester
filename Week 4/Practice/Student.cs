using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class Student
    {
        public double EcatMarks;
        public string Name;
        public double merit;
        public int age;
        public double fscMarks;
        public List<DegreeProgram> preferences;
        public List<Subject> regSubjects;
        public DegreeProgram regDegree;
        public Student(string name, int age, double fscMarks,double ecatMarks, List<DegreeProgram> preferences)
        {
            Name = name;
            this.age = age;
            this.fscMarks = fscMarks;
            EcatMarks = ecatMarks;
            this.preferences = preferences;
            regSubjects = new List<Subject>();

        }
        public void CalculateMerit()
        {
            this.merit = (((fscMarks/1100)*0.45F) + ((EcatMarks/400)* 0.55F))*100;
        }
        public int GetCreditHours()
        {
            int count = 0;
            foreach (Subject sub in regSubjects)
            {
                count = count + sub.creditHours;
            }
            return count;
        }
        public bool RegStudentSubject(Subject s)
        {
            int stCh = GetCreditHours();
            if(regDegree!= null && regDegree.IsSubjectExists(s) && stCh + s.creditHours <= 9)
            {
                regSubjects.Add(s);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
