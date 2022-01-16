using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Options;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema
{
    public class Controller
    {
        ClientRepository clientRepository;
        ProductRepository productRepository;
        OrdersRepository ordersRepository;
        
        public Controller()
        {
            this.clientRepository = new ClientRepository();
            this.productRepository = new ProductRepository();
            this.ordersRepository = new OrdersRepository();
        }

        public void ShowMenu()
        {
            OptionsMenu();
        }
        
        public void OptionsMenu()
        {           
            Console.WriteLine("Which report do you want to see?");
            Console.WriteLine("[1] - All Client's report");
            Console.WriteLine("[2] - All Order's report");
            Console.WriteLine("[3] - Add/Remove Client");
            Console.WriteLine("[4] - Add/Remove Order");
            Console.WriteLine("[5] - Exit");

            int option = int.Parse(Console.ReadLine()); //error handler reikia 

            switch (option)
            {
                case 1:
                    Console.Clear();
                    PrintClients(clientRepository.GetClients());
                    break;
                case 2:
                    Console.Clear();
                    DisplayOrdersReport displayOrdersReport = new DisplayOrdersReport();
                    displayOrdersReport.GetOrdersReport(clientRepository, productRepository, ordersRepository);
                    break;
                case 3:
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 4:
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }

        public static void PrintClients(List<Client> clients)
        {
            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.ClientId}, Name: {client.ClientName}, Company name: ''{client.ClientCompanyName}'' ");
            }
        }

        public void CreateClientsMenu()
        {
            Utility utility = new Utility();
            
            Console.WriteLine("Do you wish to add or remove a Client?");
            Console.WriteLine("[1] - Add a Client");
            Console.WriteLine("[2] - Remove a Client");
            Console.WriteLine("[3] - Go back");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var newClient = utility.GetNewClientFromInput();
                    clientRepository.AddClient(newClient);
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 2:
                    PrintClients(clientRepository.GetClients());
                    clientRepository.RemoveClient(Utility.ParseId());
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }
        public void CreateOrdersMenu()
        {
            Utility utility = new Utility();

            Console.WriteLine("Do you wish to add or remove an Order?");
            Console.WriteLine("[1] - Add an Order");
            Console.WriteLine("[2] - Remove an Order");
            Console.WriteLine("[3] - Go back");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    var newOrder = utility.GetNewOrderFromInput();
                    ordersRepository.AddOrder(newOrder);
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 2:
                    
                    break;
                default:
                    Console.Clear();
                    break;
            }
        }


    }
}
