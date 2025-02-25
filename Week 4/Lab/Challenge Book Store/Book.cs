using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Book_Store
{
    public class Book
    {
        public string Title;
        public string[] Authors = new string[4];
        public string Publisher;
        public string ISBN;
        public double Price;
        public int Stock;
        public int Year;
        public int AuthorCount;

        // Constructors
        public Book() { }

        public Book(string title, string[] authors, string publisher,
                   string isbn, double price, int stock, int year)
        {
            Title = title;
            Authors = authors;
            Publisher = publisher;
            ISBN = isbn;
            Price = price;
            Stock = stock;
            Year = year;
            AuthorCount = authors.Length;
        }

        // Copy constructor
        public Book(Book b)
        {
            Title = b.Title;
            Authors = b.Authors;
            Publisher = b.Publisher;
            ISBN = b.ISBN;
            Price = b.Price;
            Stock = b.Stock;
            Year = b.Year;
            AuthorCount = b.AuthorCount;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"\nTitle: {Title}");
            Console.WriteLine($"Authors: {string.Join(", ", Authors)}");
            Console.WriteLine($"Publisher: {Publisher}");
            Console.WriteLine($"ISBN: {ISBN}");
            Console.WriteLine($"Price: {Price:C}");
            Console.WriteLine($"Stock: {Stock}");
            Console.WriteLine($"Year: {Year}");
        }
    }
}
