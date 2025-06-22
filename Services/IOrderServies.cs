using BabyProductShop;
using DTOEntities;
using Entities;

namespace Services
{
    public interface IOrderServies
    {
        Task<OrderBackDTO> addOrderAsync(OrderDTO order);
       
    }
}