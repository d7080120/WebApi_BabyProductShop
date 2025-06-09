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
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
