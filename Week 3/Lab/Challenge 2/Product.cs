using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2
{
    public class Product
    {
        public string Name;
        public string Category;
        public double Price;
        public int StockQuantity;
        public int MinimumStockQuantity;

        // 1. Default constructor
        public Product()
        {
            Name = "Unknown";
            Category = "Groceries";
            Price = 0.0;
            StockQuantity = 0;
            MinimumStockQuantity = 10;
        }

        // 2. Parameterized constructor
        public Product(string name, string category, double price, int stock, int minStock)
        {
            Name = name;
            Category = category;
            Price = price;
            StockQuantity = stock;
            MinimumStockQuantity = minStock;
        }

        // 3. Copy constructor
        public Product(Product p)
        {
            Name = p.Name;
            Category = p.Category;
            Price = p.Price;
            StockQuantity = p.StockQuantity;
            MinimumStockQuantity = p.MinimumStockQuantity;
        }

        public double CalculateTax()
        {
            if (Category == "Groceries") return Price * 0.10;
            if (Category == "Fresh Fruit") return Price * 0.05;
            return Price * 0.15;
        }
    }
}
