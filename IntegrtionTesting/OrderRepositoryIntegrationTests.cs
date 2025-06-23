using Xunit;
using Entities;
using Repositories;
using System.Threading.Tasks;

public class OrderRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly OrderRepositroy _orderRepository;

    public OrderRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _orderRepository = new OrderRepositroy(_fixture.DbContext);
    }

    [Fact]
    public async Task AddOrderAsync_AddsOrder()
    {
        // Arrange
        _fixture.ClearDatabase();
        var order = new Order { Id = 1, UserId = 2, Sum = 99 };

        // Act
        var result = await _orderRepository.addOrderAsync(order);
        var ordersInDb = _fixture.DbContext.Orders.ToList();

        // Assert
        Assert.NotNull(result);
        Assert.Equal(order.Id, result.Id);
        Assert.Single(ordersInDb);
        Assert.Equal(order.Sum, ordersInDb[0].Sum);
    }
}