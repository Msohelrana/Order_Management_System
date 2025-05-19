using AutoMapper;
using Order_Management_System.DTOs;
using Order_Management_System.Models;

namespace Order_Management_System.Profiles
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductReadDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
