using Microsoft.EntityFrameworkCore;
using Products_Order_Management.Data;
using Products_Order_Management.Models;
using Products_Order_Management.Services.IServices;

namespace Products_Order_Management.Services
{    
    public class ProductService : IProduct
    {
        private readonly DataContext _context;
        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<string> AddProduct(Products newProduct)
        {
           await _context.Products.AddAsync(newProduct);
            return "Product added successfully";
            
        }

        public Task<bool> CheckAvailability(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Products>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<List<Orders>> GetOrdersMade(Guid ProductId)
        {
            return await _context.Orders.Where(x =>  x.ProductId == ProductId).ToListAsync();
        }

        public async Task<Products> GetProductById(Guid ProductId)
        {
            return await _context.Products.Where(x => x.ProductId == ProductId).FirstOrDefaultAsync();
        }
    }
}
