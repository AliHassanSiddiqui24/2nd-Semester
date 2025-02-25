using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class Book
    {
        public string Title;
        public string Publisher;
        public int ISBN;
        public int Price;
        public int Stock;
        public static string[] authors = new string[4];
        public static List<Book> bookss = new List<Book>();
        public Book(string titles, string publishers, int isbns, int prices, int stocks)
        {
            Title = titles;


            Publisher = publishers;
            Stock = stocks;
            ISBN = isbns;
            Price = prices;
        }

        public Book()
        {

        }
        public static void AddBook(Book booked)
        {
            bookss.Add(booked);
        }
        public bool SearchBook(string title)
        {
            bool isFound = false;
            int index = 0;
            for (int i = 0; i < bookss.Count; i++)
            {
                if (!(bookss[i].Title == title))
                {
                    isFound = true;
                    index = i;
                    break;
                }
            }

            return isFound;
        }
        public void SearchBookByTitle(string title)
        {
            bool isFound = false;
            int index = 0;
            for (int i = 0; i < bookss.Count; i++)
            {
                if (bookss[i].Title == title)
                {
                    isFound = true;
                    index = i;
                    break;
                }
            }

            if (isFound == true)
            {
                Console.WriteLine("Book Found");
                Console.WriteLine($"Title: {bookss[index].Title}");
                Console.WriteLine($"Publisher: {bookss[index].Publisher}");
                Console.WriteLine($"ISBN: {bookss[index].ISBN}");
                Console.WriteLine($"Price: {bookss[index].Price}");
            }
            if (isFound == false)
            {
                Console.WriteLine("Not Found");
            }
        }
        public int ReturnBook(int isbn)
        {
            int index = -1;
            for (int i = 0; i < bookss.Count; i++)
            {
                if (bookss[i].ISBN == isbn)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
        public int returnindex(string title)
        {
            int index = 0;
            for (int i = 0; i < bookss.Count; i++)
            {
                if (bookss[i].Title == title)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }


        public void SearchBookByISBN(int isbn)
        {
            bool isFound = false;
            int index = 0;
            for (int i = 0; i < bookss.Count; i++)
            {
                if (bookss[i].ISBN == isbn)
                {
                    isFound = true;
                    index = i;
                    break;
                }
            }

            if (isFound == true)
            {
                Console.WriteLine("Book Found");
                Console.WriteLine($"Title: {bookss[index].Title}");
                Console.WriteLine($"Publisher: {bookss[index].Publisher}");
                Console.WriteLine($"ISBN: {bookss[index].ISBN}");
                Console.WriteLine($"Price: {bookss[index].Price}");
            }
            if (isFound == false)
            {
                Console.WriteLine("Not Found");
            }
        }

        public void UpdateStock(int isbn)
        {
            for (int i = 0; i < bookss.Count; i++)
            {
                if (bookss[i].ISBN == isbn)
                {
                    Console.WriteLine("Book Found");
                    Console.WriteLine("Enter Updated Stock");
                    bookss[i].Stock = Convert.ToInt32(Console.ReadLine());
                }
                else
                {
                    Console.WriteLine("Not Found");
                }
            }
        }

        public void ViewAll()
        {
            for (int i = 0; i < bookss.Count; i++)
            {
                Console.WriteLine();
                Console.WriteLine($"Title: {bookss[i].Title}");
                Console.WriteLine($"Publisher: {bookss[i].Publisher}");
                Console.WriteLine($"ISBN: {bookss[i].ISBN}");
                Console.WriteLine($"Price: {bookss[i].Price}");
                Console.WriteLine($"Stock: {bookss[i].Stock}");
            }
        }
        public void purchasebook(int isbn)
        {
 

            int index = ReturnBook(isbn);
            if (index == -1)
            {
                Console.WriteLine("Book not found");
                return;
            }
            Console.WriteLine("Enter the quantity of the book you want to purchase");
            int quantity = Convert.ToInt32(Console.ReadLine());
            if (bookss[index].Stock >= quantity)
            {
                Console.WriteLine("Total Price: " + bookss[index].Price * quantity);
                bookss[index].Stock = bookss[index].Stock - quantity;
            }
            else
            {
                Console.WriteLine("Required Quantity not available");
            }
        }
    }
}
