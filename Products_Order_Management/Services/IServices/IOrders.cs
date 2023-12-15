using Products_Order_Management.Models;

namespace Products_Order_Management.Services.IServices
{
    public interface IOrders
    {
        Task<string> MakeAnOrder(Orders newOrder);

        Task<List<Orders>> GetAllOrders();

        Task<Orders> GetOrderById(Guid OrderId);
    }
}
