using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Member
    {
        public string Member_ID;
        public string Member_Name;
        public int No_of_Books_Bought;
        public static List<string> Books_Bought  = new List<string>();
        public static List<Member> member = new List<Member>();
        public int Money_Spent;
    
    
        public Member(string memberID, string memberName, int noOfBooksBought = 0,int moneySpent = 0)
        {
            Member_ID = memberID;
            Member_Name = memberName;
            No_of_Books_Bought = noOfBooksBought;
            Money_Spent = moneySpent;
        }

        public Member()
        {

        }
        public static void AddMember(Member members)
        {
            member.Add(members);
        }

        public bool isValid(string memberID)
        {
            bool temp = false;
            for(int i = 0; i < memberID.Length; i++)
            {
                if (!(memberID[i] >= 48 && memberID[i] <= 57))
                {
                    temp = true;
                    break;
                }
            }

            return temp;
        }

        public void searchMemberByID(string memberID)
        {
            bool isFound = false;
            int index = 0;
            for(int i = 0;i < member.Count;i++)
            {
                if(memberID == member[i].Member_ID)
                {
                     isFound = true;
                     index = i; 
                     break;
                }
            }

            if(isFound == true)
            {
                Console.WriteLine($"Member Name: {member[index].Member_Name}");
                Console.WriteLine($"Member ID: {member[index].Member_ID}");
                Console.WriteLine($"Books Bought: {member[index].No_of_Books_Bought}");
                Console.WriteLine($"Money Spent: {member[index].Money_Spent}");
            }
            if (isFound == false)
            {
                Console.WriteLine("Member not found.");
            }
        }

        public void searchMemberByName(string memberName)
        {
            bool isFound = false;
            int index = 0;
            for (int i = 0; i < member.Count; i++)
            {
                if (memberName == member[i].Member_Name)
                {
                    isFound = true;
                    index = i;
                    break;
                }
            }

            if (isFound == true)
            {
                Console.WriteLine($"Member Name: {member[index].Member_Name}");
                Console.WriteLine($"Member ID: {member[index].Member_ID}");
                Console.WriteLine($"Books Bought: {member[index].No_of_Books_Bought}");
                Console.WriteLine($"Money Spent: {member[index].Money_Spent}");
            }
            if (isFound == false)
            {
                Console.WriteLine("Member not found.");
            }
        }

        public void updateMemberByName(string memberName)
        {
            bool isFound = false;
            int index = 0;
            for (int i = 0; i < member.Count; i++)
            {
                if (memberName == member[i].Member_Name)
                {
                    isFound = true;
                    index = i;
                    break;
                }
            }

            if (isFound == true)
            {
                Console.WriteLine($"Enter Updated Member Name:");
                member[index].Member_Name = Console.ReadLine();
                Console.WriteLine($"Enter Updated Member ID:");
                member[index].Member_ID = Console.ReadLine();
            }
            if (isFound == false)
            {
                Console.WriteLine("Member not found.");
            }
        }

        public bool isFound(string memberName,string memberID)
        {
            bool isFound = false;
            for(int i = 0; i < member.Count;i++)
            {
                if (!(memberName == member[i].Member_Name && memberID == member[i].Member_ID))
                {
                    isFound = true;
                    break;
                }
            }

            return isFound;
        }

        public int ReturnMember(string memberName,string memberID)
        {
            int index = 0;
            for (int i = 0; i < member.Count; i++)
            {
                if (member[i].Member_Name == memberName  && member[i].Member_ID == memberID)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
