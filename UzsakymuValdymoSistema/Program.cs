using System.Collections.Generic;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;
using System;

namespace UzsakymuValdymoSistema
{
    class Program
    {
        static void Main(string[] args)
        {
            var clientRepository  = new ClientRepository();
            var ordersRepository  = new OrdersRepository();
            var productRepository = new ProductRepository();

            var allClientsReport         = new AllClientsReport(clientRepository, ordersRepository);
            var allUncoveredOrdersReport = new AllUncoveredOrdersReport(clientRepository, ordersRepository, productRepository);

            List<ReportItemClients> allClients = allClientsReport.GetAllClients();
            List<ReportItemOrders> allOrders   = allUncoveredOrdersReport.GetAllOrders();

            Console.WriteLine("All Clients report:");
            foreach (var item in allClients)
            {
                Console.WriteLine($"Client Id:{item.ClientId} -- Client {item.ClientName} from company ''{item.ClientCompanyName}''.");
            }

            System.Console.WriteLine("All Orders report:");
            foreach (var item in allOrders)
            {
                Console.WriteLine($"Order {item.OrderId} of {item.ProductName} for Client {item.ClientName} for the ammount of {item.Ammount} tones, of {item.Price}.");
            }
        }
    }
}
