using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    public class Student : Person
    {
        private string program;
        private int year;
        private double fee;

        public Student(string name, string address, string program, int year, double fee)
            : base(name, address)
        {
            this.program = program;
            this.year = year;
            this.fee = fee;
        }

        public void SetProgram(string program)
        {
            this.program = program;
        }

        public string GetProgram()
        {
            return program;
        }

        public void SetYear(int year)
        {
            this.year = year;
        }

        public int GetYear()
        {
            return year;
        }

        public void SetFee(double fee)
        {
            this.fee = fee;
        }

        public double GetFee()
        {
            return fee;
        }

        public override string ToString()
        {
            return $"Student: {base.ToString()}, program={program}, year={year}, fee={fee}";
        }
    }
}
