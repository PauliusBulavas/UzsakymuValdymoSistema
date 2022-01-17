﻿using System.Collections.Generic;
using System.Linq;
using UzsakymuValdymoSistema.Models;

namespace UzsakymuValdymoSistema.Repositories
{
    public class OrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public OrdersRepository()
        {
            // orderid - clinetid - productId - ammount
            orders.Add(new Order(1,  1, 1, 20));
            orders.Add(new Order(2,  2, 3, 15));
            orders.Add(new Order(3,  1, 2, 10));
            orders.Add(new Order(4,  1, 3, 35));
            orders.Add(new Order(5,  3, 2, 30));
            orders.Add(new Order(6,  4, 3, 80));
            orders.Add(new Order(7,  1, 4, 40));
            orders.Add(new Order(8,  2, 5, 24));
            orders.Add(new Order(9,  1, 3, 32));
            orders.Add(new Order(10, 3, 1, 27));
        }
        public List<Order> GetOrders() => orders;

        public Order GetOrdersById(int orderId)
        {
            var actualOrder = orders.FirstOrDefault(x => x.OrderId == orderId);

            return actualOrder;
        }

        public void AddOrder(Order order)
        {
            order.OrderId = orders.LastOrDefault().OrderId + 1;
            orders.Add(order);
        }

        public bool RemoveOrder(int id)
        {
            return orders.Remove(GetOrdersById(id));
        }
        
    }
}
