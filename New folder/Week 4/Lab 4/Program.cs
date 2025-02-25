using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Book bk = new Book();
            Member member = new Member();
            int i = 1;
            string temp;
            bool isValid;
            bool isFound;
            bool isFound1;
            string title;
            string publisher;
            string memberName;
            string memberID;
            int memberShip_Fee = 0;
            int isbn;
            int Quantity = 0;
            int price;
            int index = 0;
            int index_member = 0;
            int stock;
            int option = Menu();
            while(option != 12)
            {
                switch(option)
                {
                    case 1:
                        Console.WriteLine("Enter Book Title:");
                        title = Console.ReadLine();
                        Console.WriteLine("Enter the Publisher Name:");
                        publisher = Console.ReadLine();
                        Console.WriteLine("Enter ISBN:");
                        isbn = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Price of Book");
                        price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter Stock of Book");
                        stock = int.Parse(Console.ReadLine());
                        bk = new Book(title, publisher, isbn, price, stock);
                        Book.AddBook(bk);
                        do
                        {
                            if (i == 5)
                            {
                                break;
                            }
                            Console.WriteLine($"Enter author {i}");
                            Book.authors[i-1] = Console.ReadLine();
                            Console.WriteLine("If you want to enter more(press y/Y)");
                            Console.WriteLine("If you do not want to enter more(press n/N)");
                            temp = Console.ReadLine();
                            i++;
                        }
                        while (temp == "y" || temp == "Y");
                        break;
                    case 2:
                        Console.WriteLine("Enter the Book Title");
                        title = Console.ReadLine();

                        bk.SearchBookByTitle(title);
                        break;
                    case 3:
                        Console.WriteLine("Enter the Book ISBN");
                        isbn = int.Parse(Console.ReadLine());

                        bk = new Book();
                        bk.SearchBookByISBN(isbn);
                        break;
                    case 4:
                        Console.WriteLine("Enter the Book ISBN Whose Stock you want to update");
                        isbn = int.Parse(Console.ReadLine());

                        bk.UpdateStock(isbn);
                        break;
                    case 5:
                        bk.ViewAll();
                        break;
                    case 6:
                        Console.WriteLine("Enter your Name: ");
                        memberName = Console.ReadLine();
                        do
                        {
                            Console.WriteLine("Enter your personel member ID (If you want to become a member otherwise enter 0): ");
                            memberID = Console.ReadLine();
                            isValid = member.isValid(memberID);
                        }
                        while (isValid);
                        memberShip_Fee += 10;

                        member = new Member(memberID,memberName);
                        Member.AddMember(member);
                        break;
                    case 7:
                        Console.WriteLine("Enter your Name: ");
                        memberName = Console.ReadLine();

                        member.searchMemberByName(memberName); 
                        break;
                    case 8:
                        Console.WriteLine("Enter your personel member ID: ");
                        memberID = Console.ReadLine();

                        member.searchMemberByID(memberID);
                        break;
                    case 9:
                        Console.WriteLine("Enter your Name: ");
                        memberName = Console.ReadLine();

                        member.updateMemberByName(memberName);
                        break;
                   // case 10:
                    //do
                    //{
                    //    Console.WriteLine("Enter your Name: ");
                    //    memberName = Console.ReadLine();
                    //    Console.WriteLine("Enter your personel member ID (Enter 0 if you are not a member): ");
                    //    memberID = Console.ReadLine();
                    //    isFound1 = member.isFound(memberName, memberID);
                    //    if (isFound1)
                    //    {
                    //        Console.WriteLine("Member Not Found");
                    //        Console.WriteLine();
                    //    }
                    //}
                    //while (isFound1);
                    //if(isFound1 == false)
                    //{
                    //    index_member = member.ReturnMember(memberName,memberID);
                    //}
                    //do
                    //{
                    //    Console.WriteLine("Enter the Book You want to Purchase: ");
                    //    title = Console.ReadLine();
                    //    isFound = bk.SearchBook(title);
                    //}
                    //while (isFound);
                    //if (isFound == false)
                    //{
                    //    index = bk.returnindex(title);
                    //}
                    //if (!(isFound))
                    //{
                    //    Console.WriteLine("Enter the quantity of book");
                    //    Quantity = int.Parse(Console.ReadLine());
                    //    Book.bookss[index].Stock -= Quantity;
                    //}
                    //if (memberID != "0")
                    //{
                    //    Member.member[index_member].No_of_Books_Bought = Quantity;
                    //    Member.member[index_member].Money_Spent = Quantity * (Book.bookss[index].Price - ((Book.bookss[index].Price * 5) / 100));
                    //    Console.WriteLine($"Total Price is: {Quantity * (Book.bookss[index].Price - ((Book.bookss[index].Price * 5) / 100))}");
                    //}
                    //else if (memberID == "0")
                    //{
                    //    Console.WriteLine($"Total Price is: {Book.bookss[index].Price * Quantity}");
                    //}
                    //    break;
                    case 10:
                        Console.WriteLine("Enter the ISBN of the book you want to purchase");
                        isbn = int.Parse(Console.ReadLine());
                        bk.purchasebook(isbn);
                        break;
                    case 11:
                        Console.WriteLine($"Total Numbers of members are: {Member.member.Count}");
                        Console.WriteLine($"Total Membership fee Collected is {memberShip_Fee}");
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
                Console.ReadKey();
                option = Menu();
            }
        }

        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1. ADD A BOOK");
            Console.WriteLine("2. Search Book By Title");
            Console.WriteLine("3. Search Book by ISBN");
            Console.WriteLine("4. Edit a Book Stock");
            Console.WriteLine("5. View All Books");
            Console.WriteLine("6. Add Member");
            Console.WriteLine("7. Search member by Name");
            Console.WriteLine("8. Search member by ID");
            Console.WriteLine("9. Update Member Info");
            Console.WriteLine("10. Purchase Book");
            Console.WriteLine("11. Stats");
            Console.WriteLine("12. Exit");
            int options = int.Parse(Console.ReadLine());

            return options;
        }


    }
}
