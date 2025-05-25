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
       
        public async Task<Order> addOrderAsync(Order order)
        {
                return await orderRepositroy.addOrderAsync(order);
        }
    }
}
