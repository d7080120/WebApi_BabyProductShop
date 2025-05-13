using BabyProductShop;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class OrderRepositroy : IOrderRepositroy
    {
        private readonly Prudoct_Kategory_webApi _prudoct_Kategory_webApi;

        public OrderRepositroy(Prudoct_Kategory_webApi prudoct_Kategory_webApi)
        {
            _prudoct_Kategory_webApi = prudoct_Kategory_webApi;
        }

        public async Task<Order> getOrderByIdAsync(int id)
        {
            Order order =await _prudoct_Kategory_webApi.Orders.FirstAsync((u) =>  u.Id == id);
            return order;
        }

        public async Task<Order> updateAsync(Order orderToUpdate, int id)
        {
            _prudoct_Kategory_webApi.Orders.Update(orderToUpdate);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return await Task.FromResult(orderToUpdate);
        }

        public async Task<Order> addOrderAsync(Order order)
        {
            await _prudoct_Kategory_webApi.Orders.AddAsync(order);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return order;
        }

        public async Task<List<Order>>getAllOrdersAsync()
        {
            return await _prudoct_Kategory_webApi.Orders.ToListAsync();
        }
        //public async Task<Boolean> deleteOrder(int id)
        //{
           
        //}
    }
}
