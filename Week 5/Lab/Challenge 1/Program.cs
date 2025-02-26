using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Sign In");
                Console.WriteLine("2. Sign Up");
                Console.WriteLine("3. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1": SignIn(); break;
                    case "2": SignUp(); break;
                    case "3": return;
                }
            }
        }

        static void SignIn()
        {
            Console.Write("Username: ");
            string user = Console.ReadLine();
            Console.Write("Password: ");
            string pass = Console.ReadLine();

            Admin admin = AdminBL.ValidateAdmin(user, pass);
            if (admin != null)
            {
                AdminMenu();
                return;
            }

            Customer customer = CustomerBL.ValidateCustomer(user, pass);
            if (customer != null)
            {
                CustomerMenu(customer);
                return;
            }

            Console.WriteLine("Invalid credentials!");
            Console.ReadKey();
        }

        static void SignUp()
        {
            Customer c = new Customer();
            Console.Write("Username: ");
            c.Username = Console.ReadLine();
            Console.Write("Password: ");
            c.Password = Console.ReadLine();
            Console.Write("Email: ");
            c.Email = Console.ReadLine();
            Console.Write("Address: ");
            c.Address = Console.ReadLine();
            Console.Write("Contact: ");
            c.Contact = Console.ReadLine();

            CustomerBL.AddCustomer(c);
            Console.WriteLine("Account created!");
            Console.ReadKey();
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("ADMIN MENU");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Find Highest Price Product");
                Console.WriteLine("4. View Sales Tax");
                Console.WriteLine("5. Products to Order");
                Console.WriteLine("6. View Profile");
                Console.WriteLine("7. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddProduct(); break;
                    case "2": ViewProducts(); break;
                    case "3": ShowHighestPrice(); break;
                    case "4": ShowTax(); break;
                    case "5": ShowLowStock(); break;
                    case "6": Console.WriteLine("Username: admin\nPassword: ****"); break;
                    case "7": return;
                }
                Console.ReadKey();
            }
        }

        static void CustomerMenu(Customer customer)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("CUSTOMER MENU");
                Console.WriteLine("1. View Products");
                Console.WriteLine("2. Buy Products");
                Console.WriteLine("3. Generate Invoice");
                Console.WriteLine("4. View Profile");
                Console.WriteLine("5. Exit");
                Console.Write("Choose option: ");

                switch (Console.ReadLine())
                {
                    case "1": ViewProducts(); break;
                    case "2": BuyProducts(customer); break;
                    case "3": GenerateInvoice(customer); break;
                    case "4": ShowProfile(customer); break;
                    case "5": return;
                }
                Console.ReadKey();
            }
        }

        static void AddProduct()
        {
            Product p = new Product();
            Console.Write("Product Name: ");
            p.Name = Console.ReadLine();
            Console.Write("Category: ");
            p.Category = Console.ReadLine();
            Console.Write("Price: ");
            p.Price = Convert.ToDouble(Console.ReadLine());
            Console.Write("Stock: ");
            p.Stock = Convert.ToInt32(Console.ReadLine());
            Console.Write("Min Stock: ");
            p.MinStock = Convert.ToInt32(Console.ReadLine());

            ProductBL.AddProduct(p);
            Console.WriteLine("Product added!");
        }

        static void ViewProducts()
        {
            foreach (Product p in ProductBL.GetAllProducts())
            {
                Console.WriteLine($"{p.Name} - {p.Price:C} ({p.Stock} in stock)");
            }
        }

        static void ShowHighestPrice()
        {
            Product p = ProductBL.GetHighestPriceProduct();
            Console.WriteLine($"Highest Price: {p.Name} - {p.Price:C}");
        }

        static void ShowTax()
        {
            foreach (Product p in ProductBL.GetAllProducts())
            {
                Console.WriteLine($"{p.Name}: Tax = {ProductBL.CalculateTax(p):C}");
            }
        }

        static void ShowLowStock()
        {
            foreach (Product p in ProductBL.GetLowStockProducts())
            {
                Console.WriteLine($"{p.Name} (Current: {p.Stock}, Min: {p.MinStock})");
            }
        }

        static void BuyProducts(Customer customer)
        {
            ViewProducts();
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();

            Product found = null;
            foreach (Product p in ProductBL.GetAllProducts())
            {
                if (p.Name == name)
                {
                    found = p;
                    break;
                }
            }

            if (found == null)
            {
                Console.WriteLine("Product not found!");
                return;
            }

            Console.Write("Quantity: ");
            int qty = Convert.ToInt32(Console.ReadLine());

            if (found.Stock < qty)
            {
                Console.WriteLine("Not enough stock!");
                return;
            }

            found.Stock -= qty;
            customer.Purchases.Add(found);
            Console.WriteLine("Purchase complete!");
        }

        static void GenerateInvoice(Customer customer)
        {
            double total = 0;
            foreach (Product p in customer.Purchases)
            {
                double price = p.Price + ProductBL.CalculateTax(p);
                Console.WriteLine($"{p.Name}: {price:C}");
                total += price;
            }
            Console.WriteLine($"Total: {total:C}");
        }

        static void ShowProfile(Customer customer)
        {
            Console.WriteLine($"Username: {customer.Username}");
            Console.WriteLine($"Email: {customer.Email}");
            Console.WriteLine($"Address: {customer.Address}");
            Console.WriteLine($"Contact: {customer.Contact}");
        }
    }
}
    