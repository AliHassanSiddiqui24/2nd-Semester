﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public static class AdminBL
    {
        public static void AddAdmin(Admin a)
        {
            AdminDL.AddAdmin(a);
        }

        public static Admin ValidateAdmin(string username, string password)
        {
            return AdminDL.ValidateAdmin(username, password);
        }
    }
}
