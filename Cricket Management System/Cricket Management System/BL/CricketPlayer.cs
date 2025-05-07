using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    // Abstract class for Cricket Player - demonstrates Abstraction
    public abstract class CricketPlayer
    {
        // Protected fields - accessible to derived classes only
        protected string name;
        protected int age;
        protected string role;

        // Public properties
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        // Constructor
        public CricketPlayer(string name, int age, string role)
        {
            this.name = name;
            this.age = age;
            this.role = role;
        }

        // Abstract method - must be implemented by derived classes
        public abstract double CalculatePerformanceIndex();

        // Virtual method - can be overridden by derived classes
        public virtual string GetPlayerInfo()
        {
            return $"Name: {name}, Age: {age}, Role: {role}";
        }
    }
}
