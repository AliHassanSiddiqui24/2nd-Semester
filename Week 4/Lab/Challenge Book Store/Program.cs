using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Book_Store
{
    internal class Program
    {
        static List<Book> books = new List<Book>();
        static List<Member> members = new List<Member>();
        static double totalSales;
        static int totalMembers;
        static double membershipFees;

        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Bookstore System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Search Book by Title");
                Console.WriteLine("3. Search Book by ISBN");
                Console.WriteLine("4. Update Stock");
                Console.WriteLine("5. Add Member");
                Console.WriteLine("6. Search Member");
                Console.WriteLine("7. Update Member");
                Console.WriteLine("8. Purchase Book");
                Console.WriteLine("9. Display Stats");
                Console.WriteLine("10. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddBook(); break;
                    case "2": SearchTitle(); break;
                    case "3": SearchISBN(); break;
                    case "4": UpdateStock(); break;
                    case "5": AddMember(); break;
                    case "6": SearchMember(); break;
                    case "7": UpdateMember(); break;
                    case "8": PurchaseBook(); break;
                    case "9": DisplayStats(); break;
                    case "10": return;
                    default: Console.WriteLine("Invalid option!"); break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void AddBook()
        {
            Console.Write("Title: ");
            string title = Console.ReadLine();

            string[] authors = new string[4];
            Console.Write("Number of authors (max 4): ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.Write($"Author {i + 1}: ");
                authors[i] = Console.ReadLine();
            }

            Console.Write("Publisher: ");
            string pub = Console.ReadLine();

            Console.Write("ISBN: ");
            string isbn = Console.ReadLine();

            Console.Write("Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Stock: ");
            int stock = Convert.ToInt32(Console.ReadLine());

            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());

            books.Add(new Book(title, authors, pub, isbn, price, stock, year));
            Console.WriteLine("Book added!");
        }

        static void SearchTitle()
        {
            Console.Write("Enter title: ");
            string title = Console.ReadLine();

            foreach (Book b in books)
            {
                if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    b.ShowInfo();
                    return;
                }
            }
            Console.WriteLine("Book not found!");
        }

        static void SearchISBN()
        {
            Console.Write("Enter ISBN: ");
            string isbn = Console.ReadLine();

            foreach (Book b in books)
            {
                if (b.ISBN == isbn)
                {
                    b.ShowInfo();
                    return;
                }
            }
            Console.WriteLine("Book not found!");
        }

        static void UpdateStock()
        {
            Console.Write("Enter title/ISBN: ");
            string input = Console.ReadLine();

            Book found = null;
            foreach (Book b in books)
            {
                if (b.Title == input || b.ISBN == input)
                {
                    found = b;
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            Console.Write("Increase(+) or decrease(-) stock? ");
            string op = Console.ReadLine();
            Console.Write("Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (op == "+") found.Stock += qty;
            else if (op == "-") found.Stock -= qty;
            Console.WriteLine("Stock updated!");
        }

        static void AddMember()
        {
            Console.Write("Member name: ");
            string name = Console.ReadLine();

            Console.Write("Member ID: ");
            int id = Convert.ToInt32(Console.ReadLine());

            members.Add(new Member(name, id));
            totalMembers++;
            membershipFees += 10;
            Console.WriteLine("Member added!");
        }

        static void SearchMember()
        {
            Console.Write("Search by (1) Name or (2) ID: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            if (choice == 1)
            {
                Console.Write("Enter name: ");
                string name = Console.ReadLine();
                foreach (Member m in members)
                {
                    if (m.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        m.ShowInfo();
                        return;
                    }
                }
            }
            else
            {
                Console.Write("Enter ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                foreach (Member m in members)
                {
                    if (m.ID == id)
                    {
                        m.ShowInfo();
                        return;
                    }
                }
            }
            Console.WriteLine("Member not found!");
        }

        static void UpdateMember()
        {
            Console.Write("Enter name/ID: ");
            string input = Console.ReadLine();

            Member found = null;
            foreach (Member m in members)
            {
                if (m.Name == input || m.ID.ToString() == input)
                {
                    found = m;
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine("Member not found!");
                return;
            }

            Console.Write("New name: ");
            found.Name = Console.ReadLine();

            Console.Write("New ID: ");
            found.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Member updated!");
        }

        static void PurchaseBook()
        {
            Console.Write("Member ID (0 for non-member): ");
            int id = Convert.ToInt32(Console.ReadLine());

            Member buyer = null;
            if (id != 0)
            {
                foreach (Member m in members)
                {
                    if (m.ID == id)
                    {
                        buyer = m;
                        break;
                    }
                }
                if (buyer == null)
                {
                    Console.WriteLine("Member not found!");
                    return;
                }
            }

            Console.Write("Book title to purchase: ");
            string title = Console.ReadLine();

            Book book = null;
            foreach (Book b in books)
            {
                if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    book = b;
                    break;
                }
            }

            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            Console.Write("Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (book.Stock < qty)
            {
                Console.WriteLine("Not enough stock!");
                return;
            }

            double total = book.Price * qty;

            // Apply discounts
            if (buyer != null)
            {
                total *= 0.95; // 5% discount
                buyer.BookCount += qty;

                // Every 11th book discount
                if (buyer.BookCount >= 11)
                {
                    double avg = buyer.TotalSpent / 10;
                    total -= avg;
                    buyer.BookCount = 0;
                    buyer.TotalSpent = 0;
                }
                buyer.TotalSpent += total;
                buyer.BooksBought.Add(title);
            }

            book.Stock -= qty;
            totalSales += total;
            Console.WriteLine($"Purchase complete! Total: {total:C}");
        }

        static void DisplayStats()
        {
            Console.WriteLine($"\nTotal Sales: {totalSales:C}");
            Console.WriteLine($"Total Members: {totalMembers}");
            Console.WriteLine($"Membership Fees Collected: {membershipFees:C}");
        }
    }
}

