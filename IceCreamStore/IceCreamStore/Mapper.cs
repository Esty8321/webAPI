using AutoMapper;
using DTOs;
using Entities;

namespace Services
{
    public class Mapper:Profile 
    {
        public Mapper()
        {
            CreateMap<User,UserDTO>().ReverseMap();
            //CreateMap<Product, ProductDTO>().ForMember(dest=>dest.CategoryName,opt=>opt.MapFrom(src=>src.Category.CategoryName)).ReverseMap();
            CreateMap<Product, ProductDTO>().ForCtorParam("CategoryName", opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
