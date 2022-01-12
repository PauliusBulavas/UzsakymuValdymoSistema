using System.Collections.Generic;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Report
{
    class AllUncoveredOrdersReport
    {
        private ClientRepository _clientRepository;
        private OrdersRepository _ordersRepository;

        public AllUncoveredOrdersReport(ClientRepository clientRepository, OrdersRepository ordersRepository)
        {
            _clientRepository = clientRepository;
            _ordersRepository = ordersRepository;
        }

        public List<ReportItemOrders> GetAllOrders()
        {
            List<Order> orders = _ordersRepository.GetOrders();
            List<ReportItemOrders> orderList = new List<ReportItemOrders>();

            foreach (var order in orders)
            {
                var report = new ReportItemOrders();
                report.OrderId = order.OrderId;
                report.ClientId = order.ClientId;
                report.Products = order.Products;
                report.Ammount = order.Ammount;
                report.Price = order.Price;

                orderList.Add(report);
            }

            return orderList;
        }
    }
}
