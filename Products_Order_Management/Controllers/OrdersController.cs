using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_Order_Management.Models;
using Products_Order_Management.Models.DTOs;
using Products_Order_Management.Services.IServices;

namespace Products_Order_Management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrders _orders;
        private readonly IMapper _mapper;
        public OrdersController(IOrders orders, IMapper mapper)
        {
            _orders = orders;
            _mapper = mapper;
            
        }

        [HttpPost]
        public async Task<ActionResult<string>> MakeAnOrder(AddOrderDTO newOrder)
        {
            var mappedOrder = _mapper.Map<Orders>(newOrder);
            var response = await _orders.MakeAnOrder(mappedOrder);
            return Created($" ", response);

        }
    }
}
