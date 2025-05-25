using BabyProductShop;
using Entities;

namespace Services
{
    public interface IOrderServies
    {
        Task<Order> addOrderAsync(Order order);
       
    }
}