using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public class Customer
    {
        public string Username;
        public string Password;
        public string Email;
        public string Address;
        public string Contact;
        public List<Product> Purchases = new List<Product>();
    }
}
