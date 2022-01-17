using System.Collections.Generic;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Repositories;

namespace UzsakymuValdymoSistema.Report
{
    class AllUncoveredOrdersReport
    {
        private ClientRepository  _clientRepository;
        private OrdersRepository  _ordersRepository;
        private ProductRepository _productRepository;

        public AllUncoveredOrdersReport(ClientRepository clientRepository, OrdersRepository ordersRepository, ProductRepository productRepository)
        {
            _clientRepository  = clientRepository;
            _ordersRepository  = ordersRepository;
            _productRepository = productRepository;
        }

        public List<ReportItemOrders> GetAllOrders()
        {
            List<Order> orders = _ordersRepository.GetOrders();
            List<ReportItemOrders> orderList = new List<ReportItemOrders>();
            
            foreach (var order in orders)
            {
                var client = _clientRepository.GetClients(order.ClientId);
                if (client == null)
                {
                    continue;
                }
                var product = _productRepository.GetProducts(order.ProductId);
                if (product == null)
                {
                    continue;
                }
                
                ReportItemOrders report = new ReportItemOrders();
                report.OrderId       = order.OrderId;
                report.ClientName    = client.ClientName;
                report.ClientCompany = client.ClientCompanyName;
                report.ProductId     = order.ProductId;
                report.ProductName   = product.ProductName;
                report.Ammount       = order.Ammount;
                report.TotalPrice    = product.Price * order.Ammount;                                         

                orderList.Add(report);
            }

            return orderList;
        }
    }
}
