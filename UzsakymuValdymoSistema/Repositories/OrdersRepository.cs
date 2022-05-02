using System.Collections.Generic;
using System.Linq;
using UzsakymuValdymoSistema.Models;
using UzsakymuValdymoSistema.Options;

namespace UzsakymuValdymoSistema.Repositories
{
    public class OrdersRepository
    {
        private readonly List<Order> orders = new List<Order>();

        public OrdersRepository()
        {
            string fileName = FileReaderService.GetPathToResource("OrdersRepository.txt");
            orders = new FileReaderService().Import<Order>(fileName);
        }

        public List<Order> GetOrders() => orders;

        public Order GetOrdersById(int orderId)
        {
            var actualOrder = orders.FirstOrDefault(x => x.Id == orderId);

            return actualOrder;
        }

        public void AddOrder(Order order)
        {
            order.Id = orders.LastOrDefault().Id + 1;
            orders.Add(order);
        }

        public bool RemoveOrder(int id)
        {
            return orders.Remove(GetOrdersById(id));
        }
    }
}