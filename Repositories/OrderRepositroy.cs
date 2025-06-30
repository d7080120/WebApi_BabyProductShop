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

        public async Task<Order> addOrderAsync(Order order)//AdOrderAsync
        {
            await _prudoct_Kategory_webApi.Orders.AddAsync(order);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return order;
        }
    }
}
