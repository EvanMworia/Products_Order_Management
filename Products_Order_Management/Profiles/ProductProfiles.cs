using AutoMapper;
using Products_Order_Management.Models;
using Products_Order_Management.Models.DTOs;

namespace Products_Order_Management.Profiles
{
    public class ProductProfiles:Profile
    {
        public ProductProfiles()
        {
            CreateMap<AddProductDTO, Products>(); //.ReverseMap Can Be Used 
                
        }
    }
}
