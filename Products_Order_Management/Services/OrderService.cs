using Microsoft.EntityFrameworkCore;
using Products_Order_Management.Data;
using Products_Order_Management.Models;
using Products_Order_Management.Services.IServices;

namespace Products_Order_Management.Services
{
    public class OrderService : IOrders
    {
        private readonly DataContext _dataContext;
        public OrderService(DataContext context)
        {
            _dataContext = context;
            
        }
        public async Task<List<Orders>> GetAllOrders()
        {
            var orderList = await _dataContext.Orders.ToListAsync();
            
            return orderList;
        }

        public async Task<Orders> GetOrderById(Guid OrderId)
        {
            //Remeber to do a check while implementing in controllers for when it returns a possibly null value
            return await _dataContext.Orders.FirstOrDefaultAsync(x => x.OrderId == OrderId);
        }

        public async Task<string> MakeAnOrder(Orders newOrder)
        {
            await _dataContext.Orders.AddAsync(newOrder);
            await _dataContext.SaveChangesAsync();
            return "Order placed successfully";
        }

       
    }
}
