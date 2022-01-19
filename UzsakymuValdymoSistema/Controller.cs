using System;
using System.Collections.Generic;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Options;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema
{
    public class Controller
    {
        ClientRepository  _clientRepository;
        ProductRepository _productRepository;
        OrdersRepository  _ordersRepository;
        
        public Controller()                                                     //su controlleriu susikuriam repositorijas sitoje klaseje, tam kad matytusi atlikti pakeitimai 
        {
            this._clientRepository  = new ClientRepository();
            this._productRepository = new ProductRepository();
            this._ordersRepository  = new OrdersRepository();
        }

        public void ShowMenu()                                                  
        {
            OptionsMenu();
        }
        
        public void OptionsMenu()
        {
            Utility utility = new Utility();

            Console.WriteLine("\tORDER MANAGER 3000\n");
            Console.WriteLine("Which report/function do you want to see/do?\n");
            Console.WriteLine("[1] - All Clients report");
            Console.WriteLine("[2] - All Orders report");
            Console.WriteLine("[3] - All available Products");
            Console.WriteLine("[4] - Add/Remove Client");
            Console.WriteLine("[5] - Add/Remove Order");
            Console.WriteLine("[6] - Add/Remove Product");
            Console.WriteLine("[7] - Exit");


            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)                   //naudojame inline if statment
            {
                case 1:
                    Console.Clear();
                    PrintClients(_clientRepository.GetClients());
                    break;
                case 2:
                    Console.Clear();
                    DisplayOrdersReport displayOrdersReport = new DisplayOrdersReport();
                    displayOrdersReport.GetOrdersReport(_clientRepository, _productRepository, _ordersRepository);
                    break;
                case 3:
                    Console.Clear();
                    PrintProducts(_productRepository.GetProducts());
                    break;
                case 4:
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 5:
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 6:
                    Console.Clear();
                    CreateProductsMenu();
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }

        public void CreateClientsMenu()
        {
            Utility utility = new Utility();
            
            Console.WriteLine("Do you wish to add or remove a Client?\n");
            Console.WriteLine("[1] - Add a Client");
            Console.WriteLine("[2] - Remove a Client");
            Console.WriteLine("[3] - View and save client list");
            Console.WriteLine("[4] - Go back");

            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:                   
                    var newClient = utility.GetNewClientFromInput();
                    _clientRepository.AddClient(newClient);
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 2:
                    PrintClients(_clientRepository.GetClients());            
                    _clientRepository.RemoveClient(utility.ParseId());
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 3:
                    Console.Clear();
                    PrintClients(_clientRepository.GetClients());
                    utility.SaveToCsv<Client>(_clientRepository.GetClients(), utility.GetPathToResource("ClientRepository.txt"));
                    Console.ReadLine();
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 4:
                    Console.Clear();
                    OptionsMenu();
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }
        public void CreateOrdersMenu()
        {
            Utility utility = new Utility();
            DisplayOrdersReport displayOrdersReport = new DisplayOrdersReport();
            AllUncoveredOrdersReport allUncoveredOrdersReport = new AllUncoveredOrdersReport(_clientRepository, _ordersRepository, _productRepository);

            Console.WriteLine("Do you wish to add or remove an Order?\n");
            Console.WriteLine("[1] - Add an Order");
            Console.WriteLine("[2] - Remove an Order");
            Console.WriteLine("[3] - View and save order list");
            Console.WriteLine("[4] - Go back");

            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:
                    var newOrder = utility.GetNewOrderFromInput();            
                    _ordersRepository.AddOrder(newOrder);
                    utility.SaveToCsv<Order>(_ordersRepository.GetOrders(), utility.GetPathToResource("OrdersRepository.txt"));
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 2:
                    displayOrdersReport.GetOrdersReport(_clientRepository, _productRepository, _ordersRepository);
                    _ordersRepository.RemoveOrder(utility.ParseId());
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 3:
                    Console.Clear();
                    displayOrdersReport.GetOrdersReport(_clientRepository, _productRepository, _ordersRepository);
                    utility.SaveToCsv<ReportItemOrders>(allUncoveredOrdersReport.GetAllOrders(), utility.GetPathToResource("OrdersReport.txt"));
                    Console.ReadLine();
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 4:
                    Console.Clear();
                    OptionsMenu();
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }
        public void CreateProductsMenu()
        {
            Utility utility = new Utility();

            Console.WriteLine("Do you wish to add or remove an product?\n");
            Console.WriteLine("[1] - Add a product");
            Console.WriteLine("[2] - Remove a product");
            Console.WriteLine("[3] - View and save product list");
            Console.WriteLine("[4] - Go back");


            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:
                    PrintProducts(_productRepository.GetProducts());
                    var newProduct = utility.GetNewProductFromInput();
                    _productRepository.AddProduct(newProduct);
                    Console.Clear();
                    CreateProductsMenu();
                    break;
                case 2:
                    PrintProducts(_productRepository.GetProducts());
                    _productRepository.RemoveProduct(utility.ParseId());
                    Console.Clear();
                    CreateProductsMenu();
                    break;
                case 3:
                    Console.Clear();
                    PrintProducts(_productRepository.GetProducts());
                    utility.SaveToCsv<Product>(_productRepository.GetProducts(), utility.GetPathToResource("ProductRepository.txt"));
                    Console.ReadLine();
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 4:
                    Console.Clear();
                    OptionsMenu();
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }

        public static void PrintClients(List<Client> clients)
        {
            Console.WriteLine("All Current Clients:\n");
            foreach (var client in clients)
            {
                Console.WriteLine($"ID: {client.ClientId}, Name: {client.ClientName}, Company name: \"{client.ClientCompanyName}\" ");
            }
            Console.WriteLine();
        }
        public static void PrintProducts(List<Product> products)
        {
            Console.WriteLine("All Current products:\n");
            foreach (var product in products)
            {
                Console.WriteLine($"ID: {product.ProductId}, Name of product: {product.ProductName}, Price: {product.Price}$");
            }
            Console.WriteLine();
        }

    }
}
