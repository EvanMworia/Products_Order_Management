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

        public Task<bool> AddProduct(Products newProduct)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckAvailability(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Products>> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Task<List<Orders>> GetOrdersMade(Guid ProductId)
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProductById(Guid ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
