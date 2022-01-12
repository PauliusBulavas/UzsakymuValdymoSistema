using System.Collections.Generic;
using System.Linq;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Repositories
{
    class OrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public OrdersRepository()
        {
            // orderid - clinetid - products - ammount - price
            orders.Add(new Order(1, 1, "Copper", 2, 300.99));
            orders.Add(new Order(2, 2, "Coal", 3, 200.99));
            orders.Add(new Order(3, 1, "Iron", 1, 400.99));
            orders.Add(new Order(4, 1, "Coal", 2, 200.99));
            orders.Add(new Order(5, 3, "Iron", 5, 400.99));
            orders.Add(new Order(6, 4, "Coal", 2, 200.99));
            orders.Add(new Order(7, 1, "Iron", 3, 400.99));
            orders.Add(new Order(8, 2, "Copper", 2, 300.99));
            orders.Add(new Order(9, 1, "Coal", 1, 200.99));
            orders.Add(new Order(10, 3, "Iron", 2, 400.99));
        }
        public List<Order> GetOrders() => orders;

        public Order GetClients(int orderId)
        {
            var actualClient = orders.FirstOrDefault(x => x.OrderId == orderId);

            return actualClient;
        }
    }
}
