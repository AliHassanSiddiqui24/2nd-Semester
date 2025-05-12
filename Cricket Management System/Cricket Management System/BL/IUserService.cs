using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cricket_Management_System.BL
{
    public interface IUserService
    {
        bool Login(string username, string password, out string role);
        bool Register(string username, string password, string role);
    }
}
