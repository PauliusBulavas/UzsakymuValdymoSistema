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
            Console.WriteLine("\tORDER MANAGER 3000\n");
            Console.WriteLine("Which report/function do you want to see/do?\n");
            Console.WriteLine("[1] - All Clients report");
            Console.WriteLine("[2] - All Orders report");
            Console.WriteLine("[3] - All available Products");
            Console.WriteLine("[4] - Add/Remove Client");
            Console.WriteLine("[5] - Add/Remove Order");
            Console.WriteLine("[6] - Add/Remove Product");
            Console.WriteLine("[7] - Exit");


            //int option = int.Parse(Console.ReadLine()); //error handler reikia 

            int option = TryParseOption();         //ghetto handles wrong inputs semi works

            switch (option)
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
            Console.WriteLine("[3] - Go back");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:                   
                    var newClient = utility.GetNewClientFromInput();
                    _clientRepository.AddClient(newClient);
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                case 2:
                    PrintClients(_clientRepository.GetClients());            //istrynus klienta dingsta ir order susije su jo id fault or feature??!?!
                    _clientRepository.RemoveClient(Utility.ParseId());
                    Console.Clear();
                    CreateClientsMenu();
                    break;
                default:
                    Console.WriteLine("wrong input!");
                    break;
            }
        }
        public void CreateOrdersMenu()
        {
            Utility utility = new Utility();

            Console.WriteLine("Do you wish to add or remove an Order?\n");
            Console.WriteLine("[1] - Add an Order");
            Console.WriteLine("[2] - Remove an Order");
            Console.WriteLine("[3] - Go back");

            int option = TryParseOption();

            switch (option)
            {
                case 1:
                    var newOrder = utility.GetNewOrderFromInput();  //jei naudojamas neegzistuojantis klienatas ir/ar productas orderis nesusikura, taciau apie tai nepranesa!!
                    _ordersRepository.AddOrder(newOrder);
                    Console.Clear();
                    CreateOrdersMenu();
                    break;
                case 2:
                    DisplayOrdersReport displayOrdersReport = new DisplayOrdersReport();
                    displayOrdersReport.GetOrdersReport(_clientRepository, _productRepository, _ordersRepository);
                    _ordersRepository.RemoveOrder(Utility.ParseId());
                    Console.Clear();
                    CreateOrdersMenu();
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
            Console.WriteLine("[3] - Go back");

            int option = TryParseOption();

            switch (option)
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
                    _productRepository.RemoveProduct(Utility.ParseId());
                    Console.Clear();
                    CreateProductsMenu();
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

        public int TryParseOption() //Ghetto ass error handler again
        {
            int value;
            bool succsess = int.TryParse(Console.ReadLine(), out value);

            return value;
        }
    }
}
