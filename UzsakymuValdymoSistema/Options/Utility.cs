using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Options
{
    public class Utility
    {
        public Client GetNewClientFromInput()
        { 
            Console.WriteLine("Input client name: ");
            string clientName    = Console.ReadLine();
            Console.WriteLine("Input client company name: ");
            string clientCompany = Console.ReadLine();

            var client = new Client();
            client.ClientName = clientName;
            client.ClientCompanyName = clientCompany;

            return client;
        }

        public static int ParseId()
        {
            Console.WriteLine("Input ID to remove");
            int idToRemove = int.Parse(Console.ReadLine());

            return idToRemove;
        }

        public Order GetNewOrderFromInput() 
        {
            Console.WriteLine("Input Client Id: ");
            int clientId = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Product Id: ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Ammount: ");
            int ammount = int.Parse(Console.ReadLine());


            var order = new Order();
            order.ClientId = clientId;
            order.ProductId = productId;
            order.Ammount = ammount;

            return order;
        }

        public Product GetNewProductFromInput()
        {
            Console.WriteLine("Input product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input product price: ");

            IFormatProvider provider = NumberFormatInfo.InvariantInfo; // tam kad nereiketu butinai kablelio del lokalizacijos rasyti

            double price = double.Parse(Console.ReadLine(), provider);

            var product = new Product();
            product.ProductName = name;
            product.Price = price;

            return product;
        }

        
        
    }
}
