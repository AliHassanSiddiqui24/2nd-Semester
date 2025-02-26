using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class StudentBL
    {
        public string Name;
        public int Age;
        public float FSC;
        public float ECAT;
        public float Merit;
        public DegreeProgramBL RegisteredProgram;
        public List<SubjectBL> RegisteredSubjects = new List<SubjectBL>();
        public List<DegreeProgramBL> Preferences = new List<DegreeProgramBL>();


        public void CalculateMerit()
        {
            Merit = (FSC / 1100 * 0.6f) + (ECAT / 400 * 0.4f);
        }
    }
}
