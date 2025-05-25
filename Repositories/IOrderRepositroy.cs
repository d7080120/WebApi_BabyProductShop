using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface IOrderRepositroy
    {
        Task<Order> addOrderAsync(Order order);
        
    }
}