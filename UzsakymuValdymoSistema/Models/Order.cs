namespace UzsakymuValdymoSistema.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public decimal Amount { get; set; }
    }
}