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

        public OrderServies(IOrderRepositroy ur, IMapper mapper)
        {
            orderRepositroy = ur;
            this.mapper = mapper;
        }

        public async Task<OrderDTO> addOrderAsync(OrderDTO orderDTO)
        {
            Order order = mapper.Map<Order>(orderDTO);
            var o = await orderRepositroy.addOrderAsync(order);
            return mapper.Map<OrderDTO>(o);
        }
    }
}
