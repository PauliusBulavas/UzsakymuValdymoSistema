using System;
using System.Collections.Generic;
using System.Text;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Options
{
    public class DisplayOrdersReport
    {
        public static void GetOrdersReport()
        {
            var clientRepository  = new ClientRepository();
            var ordersRepository  = new OrdersRepository();
            var productRepository = new ProductRepository();

            var allUncoveredOrdersReport = new AllUncoveredOrdersReport(clientRepository, ordersRepository, productRepository);

            List<ReportItemOrders> allOrders = allUncoveredOrdersReport.GetAllOrders();

            System.Console.WriteLine("All Orders report:");
            foreach (var item in allOrders)
            {
                Console.WriteLine($"Order {item.OrderId} of {item.ProductName} for Client {item.ClientCompany} for the ammount of {item.Ammount} tones, of {item.Price}.");
            }
        }
    }
}