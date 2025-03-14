﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class DegreeProgram
    {
        public string degreeName;
        public float degreeDuration;
        public List<Subject> subjects;
        public int seats;
        public DegreeProgram(string degreeName, float degreeDuration, int seats)
        {
            this.degreeName = degreeName;
            this.degreeDuration = degreeDuration;
            this.seats = seats;
            subjects = new List<Subject>();
        }
        public int CalculateCreditHours()
        {
            int count = 0;
            for (int i = 0; i < subjects.Count; i++)
            {
                count = count + subjects[i].creditHours;
            }
            return count;
        }
        public bool AddSubject(Subject s)
        {
            int creditHours = calculateCreditHours();
            if (creditHours + s.creditHours <= 20)
            {
                subjects.Add(s);
                return true;
            }
            else return false;
        }
        public bool IsSubjectExists(Subject sub)
        {
            foreach (Subject s in subjects)
            {
                if (s.code == sub.code)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
