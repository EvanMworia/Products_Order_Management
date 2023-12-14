namespace Products_Order_Management.Models.DTOs
{
    public class AddOrderDTO
    {
        public string? CustomerName { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
    }
}
