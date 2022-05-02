using System.Collections.Generic;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Report
{
    internal class AllUncoveredOrdersReport
    {
        private readonly ClientRepository _clientRepository;
        private readonly OrdersRepository _ordersRepository;
        private readonly ProductRepository _productRepository;

        public AllUncoveredOrdersReport(ClientRepository clientRepository, OrdersRepository ordersRepository, ProductRepository productRepository)
        {
            _clientRepository = clientRepository;
            _ordersRepository = ordersRepository;
            _productRepository = productRepository;
        }

        public List<ReportItemOrders> GetAllOrders()
        {
            var orders = _ordersRepository.GetOrders();
            var orderList = new List<ReportItemOrders>();

            foreach (var order in orders)
            {
                var client = _clientRepository.GetClientsById(order.ClientId);
                if (client == null)
                {
                    continue;
                }
                var product = _productRepository.GetProductsById(order.ProductId);
                if (product == null)
                {
                    continue;
                }

                ReportItemOrders report = new ReportItemOrders
                {
                    OrderId = order.Id,
                    ClinetId = client.Id,
                    ClientName = client.Name,
                    ClientCompany = client.CompanyName,
                    ProductId = order.ProductId,
                    ProductName = product.Name,
                    Amount = order.Amount,
                    TotalPrice = product.Price * order.Amount
                };

                orderList.Add(report);
            }

            return orderList;
        }
    }
}