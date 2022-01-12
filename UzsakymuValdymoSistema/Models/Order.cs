using System;
using System.Collections.Generic;
using System.Text;

namespace UzsakymuValdymoSistema.Models
{
    public class Order
    {
        public int      OrderId     { get; set; }
        public int      ClientId    { get; set; }
        public string   Products    { get; set; }
        public double   Ammount     { get; set; }
        public double   Price       { get; set; }

        public Order()
        {
        }

        public Order(int orderId, int clientId, string products, int ammount, double price)
        {
            OrderId     = orderId;
            ClientId    = clientId;
            Products    = products;
            Ammount     = ammount;
            Price       = price;
        }
    }
}
