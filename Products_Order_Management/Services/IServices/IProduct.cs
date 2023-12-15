using Products_Order_Management.Models;
using Products_Order_Management.Models.DTOs;

namespace Products_Order_Management.Services.IServices
{
    public interface IProduct
    {
        Task<string> AddProduct(Products newProduct);
        Task<List<Products>> GetAllProducts();
        Task<Products> GetProductById(Guid ProductId);

        Task<List<Orders>> GetOrdersMade(Guid ProductId);

        //Task<bool> CheckAvailability(Guid ProductId);
    }
}
