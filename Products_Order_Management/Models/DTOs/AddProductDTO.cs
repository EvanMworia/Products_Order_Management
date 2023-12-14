namespace Products_Order_Management.Models.DTOs
{
    public class AddProductDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        public int AvailableUnits { get; set; }
    }
}
