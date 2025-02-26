using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public static class ProductDL
    {
        private static List<Product> products = new List<Product>();

        public static void AddProduct(Product p)
        {
            products.Add(p);
        }

        public static List<Product> GetAllProducts()
        {
            return products;
        }

        public static Product GetHighestPriceProduct()
        {
            Product highest = null;
            foreach (Product p in products)
            {
                if (highest == null || p.Price > highest.Price)
                    highest = p;
            }
            return highest;
        }

        public static List<Product> GetLowStockProducts()
        {
            List<Product> lowStock = new List<Product>();
            foreach (Product p in products)
            {
                if (p.Stock < p.MinStock)
                    lowStock.Add(p);
            }
            return lowStock;
        }
    }
}
