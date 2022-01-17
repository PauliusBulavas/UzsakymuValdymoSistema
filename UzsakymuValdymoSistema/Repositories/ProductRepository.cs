using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Repositories
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        //public ProductRepository()
        //{
        //    //productid -- product name -- product price
        //    products.Add(new Product(1, "Copper", 89.56));
        //    products.Add(new Product(2, "Iron",   99.99));
        //    products.Add(new Product(3, "Coal",   69.85));
        //    products.Add(new Product(4, "Tin",    52.20));
        //    products.Add(new Product(5, "Sulfur", 102.02));
        //}

        public List<Product> GetProducts() => products;

        public Product GetProductsById(int productId)
        {
            var acctualProduct = products.FirstOrDefault(x => x.ProductId == productId);

            return acctualProduct;
        }

        public void AddProduct(Product product)
        {
            product.ProductId = products.LastOrDefault().ProductId + 1;
            products.Add(product);
        }

        public bool RemoveProduct(int id)
        {
            return products.Remove(GetProductsById(id)); 
        }

        public ProductRepository()
        {
            string fileName = "C:\\Users\\pauli\\Documents\\GitHub\\UzsakymuValdymoSistema\\Data\\ProductRepository.csv";
            string[] linesInFile = File.ReadAllLines(fileName);
            linesInFile = linesInFile.Skip(1).ToArray();

            foreach (string line in linesInFile)
            {
                string[] rows = line.Split(',');

                var product = new Product();
                product.ProductId = Convert.ToInt32(rows[0]);
                product.ProductName = rows[1];
                IFormatProvider provider = NumberFormatInfo.InvariantInfo;
                product.Price = Convert.ToDouble(rows[2], provider);

                products.Add(product);
            }
        }
    }
}
