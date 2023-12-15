using AutoMapper;
using Products_Order_Management.Models.DTOs;
using Products_Order_Management.Models;

namespace Products_Order_Management.Profiles
{
    public class OrderProfiles:Profile
    {
        public OrderProfiles()
        {
            CreateMap<AddOrderDTO, Orders>();
        }
    }
}
