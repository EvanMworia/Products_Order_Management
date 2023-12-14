using Microsoft.EntityFrameworkCore;
using Products_Order_Management.Models;

namespace Products_Order_Management.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Products> Products { get; set; }

    }
}
