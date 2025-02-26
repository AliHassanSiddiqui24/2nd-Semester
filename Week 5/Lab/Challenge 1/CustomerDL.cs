using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public static class CustomerDL
    {
        private static List<Customer> customers = new List<Customer>();

        public static void AddCustomer(Customer c)
        {
            customers.Add(c);
        }

        public static Customer ValidateCustomer(string username, string password)
        {
            foreach (Customer c in customers)
            {
                if (c.Username == username && c.Password == password)
                    return c;
            }
            return null;
        }
    }
}
