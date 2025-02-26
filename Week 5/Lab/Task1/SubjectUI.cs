using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class SubjectUI
    {
        public static SubjectBL GetSubjectInput()
        {
            SubjectBL sub = new SubjectBL();
            Console.Write("Enter Subject Code: ");
            sub.Code = Console.ReadLine();
            Console.Write("Enter Subject Type: ");
            sub.SubjectType = Console.ReadLine();
            Console.Write("Enter Credit Hours: ");
            sub.CreditHours = int.Parse(Console.ReadLine());
            Console.Write("Enter Subject Fee: ");
            sub.Fee = int.Parse(Console.ReadLine());
            return sub;
        }
    }
}
