using BabyProductShop;
using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class OrderServies : IOrderServies
    {
        private readonly IOrderRepositroy orderRepositroy;
        public OrderServies(IOrderRepositroy ur)
        {
            orderRepositroy = ur;
        }
        public async Task<Order> getOrderByIdAsync(int id)
        {
            return await orderRepositroy.getOrderByIdAsync(id);
        }


        public async Task<Order> updateAsync(Order orderToUpdate, int id)
        {
                return await orderRepositroy.updateAsync(orderToUpdate, id);
    
        }

        public async Task<Order> addOrderAsync(Order order)
        {
                return await orderRepositroy.addOrderAsync(order);
        }


        public async Task<List<Order>> getAllOrdersAsync()
        {
            return await orderRepositroy.getAllOrdersAsync();
        }

        //public Boolean deleteOrder()
        //{

        //}
    }
}
