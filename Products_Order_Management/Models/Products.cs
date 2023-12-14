using System.ComponentModel.DataAnnotations;

namespace Products_Order_Management.Models
{
    public class Products
    {
        [Key]
        public Guid ProductId { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }

        //To check if stock of product is available, if not no orders should be accepted
        public int AvailableUnits { get; set; }

        public List<Orders> OrderList { get; set; }= new List<Orders>();

    }
}
