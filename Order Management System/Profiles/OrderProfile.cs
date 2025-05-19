using AutoMapper;
using Order_Management_System.DTOs;
using Order_Management_System.Models;

namespace Order_Management_System.Profiles
{
    public class OrderProfile:Profile
    {
        public OrderProfile()
        {
            CreateMap<Order,OrderReadDto>();
            CreateMap<OrderCreateDto, Order>();
            CreateMap<OrderUpdateDto, Order>();
        }
    }
}
