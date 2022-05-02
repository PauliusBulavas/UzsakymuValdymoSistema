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
            var report = new AllUncoveredOrdersReport(clientRepository, ordersRepository, productRepository);

            var allOrders = report.GetAllOrders();

            Console.WriteLine("All Orders report:\n");
            foreach (var item in allOrders)
            {
                // Console.WriteLine($"Id:{item.OrderId} -- \"{item.ClientCompany}\" Quantity -- {item.Amount}t of {item.ProductName} -- total Price: {item.TotalPrice}$.");
                var formated = string.Format("Id - {0, -5} Name - \"{1, -20}\" Qty in tones - {2,-5} Product - {3, -10} Total - {4, -5}$", item.OrderId, item.ClientCompany, item.Amount, item.ProductName, item.TotalPrice);
                Console.WriteLine(formated);
            }

            Console.WriteLine();
        }
    }
}