using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Options
{
    public class Utility
    {
        public Client GetNewClientFromInput()
        {
            Console.WriteLine("Input client name: ");
            string clientName = Console.ReadLine();
            Console.WriteLine("Input client company name: ");
            string clientCompany = Console.ReadLine();

            var client = new Client
            {
                Name = clientName,
                CompanyName = clientCompany
            };

            return client;
        }

        public Order GetNewOrderFromInput()
        {
            Console.WriteLine("Input Client Id: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Product Id: ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Ammount: ");
            int amount = int.Parse(Console.ReadLine());

            var order = new Order
            {
                ClientId = clientId,
                ProductId = productId,
                Amount = amount
            };

            return order;
        }

        public Product GetNewProductFromInput()
        {
            Console.WriteLine("Input product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input product price: ");

            IFormatProvider provider = NumberFormatInfo.InvariantInfo;

            var price = decimal.Parse(Console.ReadLine(), provider);

            var product = new Product
            {
                Name = name,
                Price = price
            };

            return product;
        }

        public int ParseId()
        {
            Console.WriteLine("Input ID to remove or [ENTER] to go back");

            int.TryParse(Console.ReadLine(), out int value);

            return value;
        }
    }
}