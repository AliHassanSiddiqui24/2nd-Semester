using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class BankDL
    {
        public static List<BankBL> banklist = new List<BankBL>();
        public static void addAccount(BankBL account)
        {
            banklist.Add(account);
        }
        public static BankBL searchAccount(string accountNumber)
        {
            foreach (BankBL account in banklist)
            {
                if (account.getAccountNumber() == accountNumber)
                {
                    return account;
                }
            }
            return null;
        }


    }
}
