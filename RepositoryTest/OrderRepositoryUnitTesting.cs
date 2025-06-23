using Xunit;
using Moq;
using Entities;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabyProductShop;
using Moq.EntityFrameworkCore;
using System.Threading;

namespace RepositoryTest
{
    public class OrderRepositoryUnitTesting
    {
        [Fact]
        public async Task AddOrderAsync_AddsOrder()
        {
            // Arrange
            var orders = new List<Order>();
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Orders).ReturnsDbSet(orders);
            mockContext.Setup(x => x.Orders.AddAsync(It.IsAny<Order>(), default))
                .Callback<Order, CancellationToken>((order, ct) => orders.Add(order));
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);

            var repository = new OrderRepositroy(mockContext.Object);
            var newOrder = new Order { Id = 1, Sum = 100 };

            // Act
            var result = await repository.addOrderAsync(newOrder);

            // Assert
            Assert.Equal(newOrder, result);
            Assert.Contains(newOrder, orders);
        }
    }
}