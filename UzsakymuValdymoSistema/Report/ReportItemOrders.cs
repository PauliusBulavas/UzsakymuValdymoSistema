namespace UzsakymuValdymoSistema.Report
{
    internal class ReportItemOrders
    {
        public int OrderId { get; set; }
        public int ClinetId { get; set; }
        public string ClientName { get; set; }
        public string ClientCompany { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalPrice { get; set; }
    }
}