using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public static class CustomerBL
    {
        public static void AddCustomer(Customer c)
        {
            CustomerDL.AddCustomer(c);
        }

        public static Customer ValidateCustomer(string username, string password)
        {
            return CustomerDL.ValidateCustomer(username, password);
        }
    }
}
