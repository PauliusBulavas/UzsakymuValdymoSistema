
namespace UzsakymuValdymoSistema.Report
{
    class ReportItemOrders
    {
        public int    OrderId       { get; set; }
        public int    ClinetId      { get; set; }
        public string ClientName    { get; set; }
        public string ClientCompany { get; set; }
        public int    ProductId     { get; set; }
        public string ProductName   { get; set; }
        public double Ammount       { get; set; }
        public double TotalPrice    { get; set; }

    }
}