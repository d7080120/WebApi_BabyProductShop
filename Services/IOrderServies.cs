using BabyProductShop;
using Entities;

namespace Services
{
    public interface IOrderServies
    {
        Task<Order> addOrderAsync(Order order);
        Task<Order> getOrderByIdAsync(int id);
        Task<Order> updateAsync(Order orderToUpdate, int id);
        Task<List<Order>> getAllOrdersAsync();
    }
}