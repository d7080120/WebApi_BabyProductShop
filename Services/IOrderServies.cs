using BabyProductShop;
using DTOEntities;
using Entities;

namespace Services
{
    public interface IOrderServies
    {
        Task<OrderDTO> addOrderAsync(OrderDTO order);
       
    }
}