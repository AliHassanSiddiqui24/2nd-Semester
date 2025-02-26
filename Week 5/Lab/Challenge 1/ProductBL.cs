using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_1
{
    public static class ProductBL
    {
        public static void AddProduct(Product p)
        {
            ProductDL.AddProduct(p);
        }

        public static List<Product> GetAllProducts()
        {
            return ProductDL.GetAllProducts();
        }

        public static Product GetHighestPriceProduct()
        {
            return ProductDL.GetHighestPriceProduct();
        }

        public static double CalculateTax(Product p)
        {
            return p.Category == "Groceries" ? p.Price * 0.10 :
                   p.Category == "Fresh Fruit" ? p.Price * 0.05 :
                   p.Price * 0.15;
        }

        public static List<Product> GetLowStockProducts()
        {
            return ProductDL.GetLowStockProducts();
        }
    }
}
