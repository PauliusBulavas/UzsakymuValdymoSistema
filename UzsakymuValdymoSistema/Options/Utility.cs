﻿using System;
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
        public Client GetNewClientFromInput()        //3 metodai kurie sukuira nauja object sarase id priskiriamas pagal esama didziausia id sarase pridejus 1
        { 
            Console.WriteLine("Input client name: ");
            string clientName    = Console.ReadLine();
            Console.WriteLine("Input client company name: ");
            string clientCompany = Console.ReadLine();

            var client = new Client();
            client.ClientName        = clientName;
            client.ClientCompanyName = clientCompany;

            return client;
        }

        public Order GetNewOrderFromInput() 
        {
            Console.WriteLine("Input Client Id: ");
            int clientId  = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Product Id: ");
            int productId = int.Parse(Console.ReadLine());
            Console.WriteLine("Input Ammount: ");
            int ammount   = int.Parse(Console.ReadLine());


            var order = new Order();
            order.ClientId  = clientId;
            order.ProductId = productId;
            order.Ammount   = ammount;

            return order;
        }

        public Product GetNewProductFromInput()
        {
            Console.WriteLine("Input product Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Input product price: ");

            IFormatProvider provider = NumberFormatInfo.InvariantInfo; // tam kad nereiketu butinai kablelio del lokalizacijos rasyti, tinka ir taskas = no crash

            double price = double.Parse(Console.ReadLine(), provider);

            var product = new Product();
            product.ProductName = name;
            product.Price       = price;

            return product;
        }

        public static int ParseId() //ghetto handles wrong inputs, ar taip korektiska daryti?!?!?!
        {
            Console.WriteLine("Input ID to remove or [ENTER] to go back");
            int value;
            bool idToRemove = int.TryParse(Console.ReadLine(), out value);

            return value;          
        }

        public void SaveToCsv<T>(List<T> reportData, string path) //pavogtas save to csv metodas 
        {
            var lines = new List<string>();
            IEnumerable<PropertyDescriptor> props = TypeDescriptor.GetProperties(typeof(T)).OfType<PropertyDescriptor>();
            var header = string.Join(",", props.ToList().Select(x => x.Name));
            lines.Add(header);
            var valueLines = reportData.Select(row => string.Join(",", header.Split(',').Select(a => row.GetType().GetProperty(a).GetValue(row, null))));
            lines.AddRange(valueLines);
            File.WriteAllLines(path, lines.ToArray());
        }



    }
}
