using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    public class Student : Person
    {
        public string Program { get; set; }
        public int Year { get; set; }
        public double Fee { get; set; }

        public Student(string name, string address, string program, int year, double fee) : base(name, address)

        {
            Program = program;
            Year = year;
            Fee = fee;
        }

        public override string ToString()
        {
            return $"Student: {base.ToString()}, program={Program}, year={Year}, fee={Fee}";
        }
    }
}
