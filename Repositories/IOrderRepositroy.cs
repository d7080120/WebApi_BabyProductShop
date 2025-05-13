using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface IOrderRepositroy
    {
        Task<Order> addOrderAsync(Order order);
        Task<Order> getOrderByIdAsync(int id);
        Task<Order> updateAsync(Order orderToUpdate, int id);
        Task<List<Order>> getAllOrdersAsync();
    }
}