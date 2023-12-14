using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products_Order_Management.Models
{
    public class Orders
    {
        [Key]
        public Guid OrderId { get; set; }

        public string? CustomerName { get; set; }

        public int Units { get; set; }

        [ForeignKey("ProductId")]
        public Products prods { get; set; } = default!;

        public Guid ProductId { get; set; }
        public string? ProductName { get; set; }

    }
}
