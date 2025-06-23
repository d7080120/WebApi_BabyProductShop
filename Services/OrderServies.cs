using AutoMapper;
using BabyProductShop;
using DTOEntities;
using Entities;
using Microsoft.EntityFrameworkCore.Metadata;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class OrderServies : IOrderServies
    {
        private readonly IOrderRepositroy orderRepositroy;
        private readonly IMapper mapper;
        private readonly IProductRepositroy productRepositroy;
        public OrderServies(IOrderRepositroy ur, IMapper mapper, IProductRepositroy productRepositroy)
        {
            orderRepositroy = ur;
            this.mapper = mapper;
            this.productRepositroy = productRepositroy;
        }

        public async Task<OrderBackDTO> addOrderAsync(OrderDTO orderDTO)
        {
            Order order = mapper.Map<Order>(orderDTO);
            order.Sum =await SumOfOrderAsync(orderDTO);
            var o = await orderRepositroy.addOrderAsync(order);
            return mapper.Map<OrderBackDTO>(o);
        }

        public async Task<int> SumOfOrderAsync(OrderDTO order)
        {
            int sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product product=await productRepositroy.getProductByIdAsync(item.ProductId);
                if (product.Price == null || item.Quantity <= 0)
                {
                    throw new Exception("Invalid product price or quantity");
                }
                sum += (int)(product.Price * item.Quantity);
            }
            return sum;
        }
    }
}
