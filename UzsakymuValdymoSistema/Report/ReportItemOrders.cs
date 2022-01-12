using System;
using System.Collections.Generic;
using System.Text;

namespace UzsakymuValdymoSistema.Report
{
    class ReportItemOrders
    {
        public int      OrderId     { get; set; }
        public int      ClientId    { get; set; }
        public string   Products    { get; set; }
        public double   Ammount     { get; set; }
        public double   Price       { get; set; }

    }
}
