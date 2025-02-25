using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Book_Store
{
    public class Member
    {
        public string Name;
        public int ID;
        public List<string> BooksBought = new List<string>();
        public int BookCount;
        public double TotalSpent;

        // Constructors
        public Member() { }

        public Member(string name, int id)
        {
            Name = name;
            ID = id;
            BooksBought = new List<string>();
            BookCount = 0;
            TotalSpent = 0;
        }

        // Copy constructor
        public Member(Member m)
        {
            Name = m.Name;
            ID = m.ID;
            BooksBought = new List<string>(m.BooksBought);
            BookCount = m.BookCount;
            TotalSpent = m.TotalSpent;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Member ID: {ID}");
            Console.WriteLine($"Books Bought: {BookCount}");
            Console.WriteLine($"Total Spent: {TotalSpent:C}");
        }
    }
}
