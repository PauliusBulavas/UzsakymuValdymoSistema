using System;
using System.Collections.Generic;
using System.Linq;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Options;

namespace UzsakymuValdymoSistema.Repositories
{
    public class ProductRepository
    {
        private readonly List<Product> products = new List<Product>();

        public ProductRepository()
        {
            string fileName = FileReaderService.GetPathToResource("ProductRepository.txt");
            products = new FileReaderService().Import<Product>(fileName);
        }

        public List<Product> GetProducts() => products;

        public Product GetProductsById(int productId)
        {
            var acctualProduct = products.FirstOrDefault(x => x.Id == productId);

            return acctualProduct;
        }

        public void AddProduct(Product product)
        {
            product.Id = products.LastOrDefault().Id + 1;
            products.Add(product);
        }

        public bool RemoveProduct(int id)
        {
            return products.Remove(GetProductsById(id));
        }

        public void PrintProducts()
        {
            Console.WriteLine("All Current products:\n");
            foreach (var product in products)
            {
                //Console.WriteLine($"ID: {product.Id}, Name of product: {product.Name}, Price: {product.Price}$");
                var formated = string.Format("Id - {0, -3} Name - {1, -10} Price - {2,-5}$", product.Id, product.Name, product.Price);
                Console.WriteLine(formated);
            }
            Console.WriteLine();
        }
    }
}