using System;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Options;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema
{
    public class Controller
    {
        private readonly ClientRepository _clients;
        private readonly ProductRepository _products;
        private readonly OrdersRepository _orders;
        private readonly FileReaderService _fileService;
        private readonly DisplayOrdersReport _ordersReport;
        private readonly Utility _utility;

        public Controller()
        {
            _clients = new ClientRepository();
            _products = new ProductRepository();
            _orders = new OrdersRepository();
            _fileService = new FileReaderService();
            _ordersReport = new DisplayOrdersReport();
            _utility = new Utility();
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

            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:
                    Console.Clear();
                    _clients.PrintClients();
                    break;

                case 2:
                    Console.Clear();
                    _ordersReport.GetOrdersReport(_clients, _products, _orders);
                    break;

                case 3:
                    Console.Clear();
                    _products.PrintProducts();
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
            Console.WriteLine("Do you wish to add or remove a Client?\n");
            Console.WriteLine("[1] - Add a Client");
            Console.WriteLine("[2] - Remove a Client");
            Console.WriteLine("[3] - View and save client list");
            Console.WriteLine("[4] - Go back");

            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:
                    var newClient = _utility.GetNewClientFromInput();
                    _clients.AddClient(newClient);
                    Console.Clear();
                    CreateClientsMenu();
                    break;

                case 2:
                    //utility.PrintClients(_clients.GetClients());
                    _clients.PrintClients();
                    _clients.RemoveClient(_utility.ParseId());
                    Console.Clear();
                    CreateClientsMenu();
                    break;

                case 3:
                    Console.Clear();
                    //utility.PrintClients(_clients.GetClients());
                    _clients.PrintClients();
                    _fileService.SaveToCsv<Client>(_clients.GetClients(), FileReaderService.GetPathToResource("ClientRepository.txt"));
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
            var allOrdersReport = new AllUncoveredOrdersReport(_clients, _orders, _products);

            Console.WriteLine("Do you wish to add or remove an Order?\n");
            Console.WriteLine("[1] - Add an Order");
            Console.WriteLine("[2] - Remove an Order");
            Console.WriteLine("[3] - View and save order list");
            Console.WriteLine("[4] - Go back");

            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:
                    _clients.PrintClients();
                    _products.PrintProducts();
                    var newOrder = _utility.GetNewOrderFromInput();
                    _orders.AddOrder(newOrder);
                    _fileService.SaveToCsv<Order>(_orders.GetOrders(), FileReaderService.GetPathToResource("OrdersRepository.txt"));
                    Console.Clear();
                    CreateOrdersMenu();
                    break;

                case 2:
                    _ordersReport.GetOrdersReport(_clients, _products, _orders);
                    _orders.RemoveOrder(_utility.ParseId());
                    Console.Clear();
                    CreateOrdersMenu();
                    break;

                case 3:
                    Console.Clear();
                    _ordersReport.GetOrdersReport(_clients, _products, _orders);
                    _fileService.SaveToCsv<ReportItemOrders>(allOrdersReport.GetAllOrders(), FileReaderService.GetPathToResource("OrdersReport.txt"));
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
            Console.WriteLine("Do you wish to add or remove an product?\n");
            Console.WriteLine("[1] - Add a product");
            Console.WriteLine("[2] - Remove a product");
            Console.WriteLine("[3] - View and save product list");
            Console.WriteLine("[4] - Go back");

            switch (int.TryParse(Console.ReadLine(), out int value) ? value : 0)
            {
                case 1:
                    _products.PrintProducts();
                    var newProduct = _utility.GetNewProductFromInput();
                    _products.AddProduct(newProduct);
                    Console.Clear();
                    CreateProductsMenu();
                    break;

                case 2:
                    _products.PrintProducts();
                    _products.RemoveProduct(_utility.ParseId());
                    Console.Clear();
                    CreateProductsMenu();
                    break;

                case 3:
                    Console.Clear();
                    _products.PrintProducts();
                    _fileService.SaveToCsv<Product>(_products.GetProducts(), FileReaderService.GetPathToResource("ProductRepository.txt"));
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
    }
}