using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Repositories
{
    public class ProductRepository
    {
        private List<Product> products = new List<Product>();

        public ProductRepository()
        {
            //productid -- product name -- product price
            products.Add(new Product(1, "Copper", 89.56));
            products.Add(new Product(2, "Iron",   99.99));
            products.Add(new Product(3, "Coal",   69.85));
            products.Add(new Product(4, "Tin",    52.20));
            products.Add(new Product(5, "Sulfur", 102.02));
        }

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

    }
}
