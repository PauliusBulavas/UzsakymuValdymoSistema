using System;
using System.Collections.Generic;
using System.Text;

namespace UzsakymuValdymoSistema.Models
{
    public class Product
    {
        public int    ProductId   { get; set; }
        public string ProductName { get; set; }
        public double Price       { get; set; }

        public Product()
        {
        }

        public Product (int productId, string productName, double price)
        {
            ProductId   = productId;
            ProductName = productName;
            Price       = price;
        }
    }
}
