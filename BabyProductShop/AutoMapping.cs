using AutoMapper;
using DTOEntities;
using Entities;

namespace BabyProductShop
{
    public class AutoMapping:Profile
    {
        public AutoMapping()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<OrderItem, OrderItemDTO>().ReverseMap();
            CreateMap<Product, ProductDTO>().ReverseMap();
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<User, LoginUserDTO>().ReverseMap();
            CreateMap<User,UserDTO>().ReverseMap();
            CreateMap<Order, OrderBackDTO>().ReverseMap();
        }
    }
}
