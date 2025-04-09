using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    public class Staff : Person
    {

        public string School { get; set; }
        public double Pay { get; set; }

        public Staff(string name, string address, string school, double pay) : base(name, address)

        {
            School = school;
            Pay = pay;
        }
        public override string ToString()
        {
            return $"Staff: {base.ToString()}, school={School}, pay={Pay}";
        }
    }
}
