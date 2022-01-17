using System;
using System.Collections.Generic;
using System.Text;

namespace UzsakymuValdymoSistema.Models
{
    public class Order
    {
        public int    OrderId   { get; set; }
        public int    ClientId  { get; set; }
        public int    ProductId { get; set; }
        public double Ammount   { get; set; }

        public Order()
        {
        }

        public Order(int orderId, int clientId, int productId, double ammount)
        {
            OrderId   = orderId;
            ClientId  = clientId;
            ProductId = productId;
            Ammount   = ammount;
        }
    }
}
