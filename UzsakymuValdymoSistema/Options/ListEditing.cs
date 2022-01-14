using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Options
{
    public class ListEditing
    {
        //reikia perdaryti kad pagal id ieskotu o ne indeksa ir ar gerai pasiemu duomenis is repo???
        public static void AddClient()
        {
            var clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();

            int index = 0;

            Console.WriteLine("Current available Clients:");
            foreach (var client in clients)
            {
                Console.WriteLine($"[{index}] - ID: {client.ClientId}, Name: {client.ClientName}, Company name: ''{client.ClientCompanyName}'' ");
                index++;
            }

            int clientID         = index + 1;
            Console.WriteLine("Input client name: ");
            string clientName    = Console.ReadLine();
            Console.WriteLine("Input client company name: ");
            string clientCompany = Console.ReadLine();

            clients.Add(new Client() {ClientId = clientID, ClientName = clientName,  ClientCompanyName = clientCompany });

            index = 0;

            Console.Clear();

            Console.WriteLine("Updated list:");
            foreach (var client in clients)
            {
                Console.WriteLine($"[{index}] - ID: {client.ClientId}, Name: {client.ClientName}, Company name: ''{client.ClientCompanyName}'' ");
                index++;
            }
            Console.WriteLine("Press [Enter] to continue..");
            Console.ReadLine();
        }
        public static void RemoveClient()
        {
            GetCurrentClientsWithIndex();
        }
        public static void AddOrder() //duomenys apjungti is dvieju listu, order repo turi tik producto id, tad reikia pasiimti ir product repo
        {
            GetCurrentOrdersWithIndex();
        }
        public static void RemoveOrder()
        {
            GetCurrentOrdersWithIndex();
        }
        
        public static void GetCurrentClientsWithIndex()
        {
            var clientRepository = new ClientRepository();
            List<Client> clients = clientRepository.GetClients();

            int index = 0;

            Console.WriteLine("Current available Clients:");
            foreach (var client in clients)
            {
                Console.WriteLine($"[{index}] - ID: {client.ClientId}, Name: {client.ClientName}, Company name: ''{client.ClientCompanyName}'' ");
                index++;
            }
        }
        public static void GetCurrentOrdersWithIndex()
        {
            var orderRepository = new OrdersRepository();
            var productRepository = new ProductRepository();
            var clientRepository = new ClientRepository();

            var allOrdersList = new AllUncoveredOrdersReport(clientRepository, orderRepository, productRepository);

            List<ReportItemOrders> allOrders = allOrdersList.GetAllOrders();

            int index = 0;

            Console.WriteLine("Current available Orders:");
            foreach (var item in allOrders)
            {
                Console.WriteLine($"[{index}] - Order Id: {item.OrderId}, Company Name: ''{item.ClientCompany}'', Product Name: {item.ProductName}, Ammount: {item.Ammount}Tones, Total Price: {item.TotalPrice}$ ");
                index++;
            }
        }

        public static void GetOrdersByID()
        {

        }
    }
}
