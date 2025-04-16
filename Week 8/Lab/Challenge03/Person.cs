using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge03
{
    public class Person
    {
        private string name;
        private string address;

        public Person(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetAddress(string address)
        {
            this.address = address;
        }

        public string GetAddress()
        {
            return address;
        }

        public override string ToString()
        {
            return $"Person[name={name}, address={address}]";
        }
    }
}
