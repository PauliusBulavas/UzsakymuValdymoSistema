using System;
using System.Collections.Generic;
using UzsakymuValdymoSistema.Report;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Options
{
    public class DisplayOrdersReport
    {
        public void GetOrdersReport(ClientRepository clientRepository, ProductRepository productRepository, OrdersRepository ordersRepository)
        {
            var allUncoveredOrdersReport = new AllUncoveredOrdersReport(clientRepository, ordersRepository, productRepository);

            List<ReportItemOrders> allOrders = allUncoveredOrdersReport.GetAllOrders();

            Console.WriteLine("All Orders report:\n");
            foreach (var item in allOrders)
            {
                Console.WriteLine($"Order Id:{item.OrderId} -- Client \"{item.ClientCompany}\" for the ammount of {item.Ammount} tones of {item.ProductName} for total of: {item.TotalPrice}$.");
            }

            Console.WriteLine();
        }
    }
}