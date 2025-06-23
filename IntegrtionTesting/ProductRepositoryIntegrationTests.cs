using Xunit;
using Entities;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class ProductRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly ProductRepositroy _productRepository;

    public ProductRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _productRepository = new ProductRepositroy(_fixture.DbContext);
    }

    [Fact]
    public async Task GetAllProductsAsync_ReturnsFilteredAndSortedProducts()
    {
        // Arrange
        _fixture.ClearDatabase();
        var cat = new Category { Id = 1, Name = "Toys" };
        var p1 = new Product { Id = 1, Name = "Alpha", Price = 10, CategoryId = 1, Category = cat };
        var p2 = new Product { Id = 2, Name = "Beta", Price = 20, CategoryId = 1, Category = cat };
        _fixture.DbContext.Categories.Add(cat);
        _fixture.DbContext.Products.AddRange(p1, p2);
        await _fixture.DbContext.SaveChangesAsync();

        var parameters = new ProductQueryParameters
        {
            MinPrice = 15,
            SortBy = "price",
            SortDirection = "desc",
            Page = 1,
            PageSize = 10
        };

        // Act
        var products = await _productRepository.getAllProductsAsync(parameters);

        // Assert
        Assert.Single(products);
        Assert.Equal(2, products[0].Id); // Should return only Beta
    }

    [Fact]
    public async Task GetProductByIdAsync_ReturnsProductWithCategory()
    {
        // Arrange
        _fixture.ClearDatabase();
        var cat = new Category { Id = 2, Name = "Strollers" };
        var prod = new Product { Id = 5, Name = "Big Stroller", Price = 99, CategoryId = 2, Category = cat };
        _fixture.DbContext.Categories.Add(cat);
        _fixture.DbContext.Products.Add(prod);
        await _fixture.DbContext.SaveChangesAsync();

        // Act
        var result = await _productRepository.getProductByIdAsync(5);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Big Stroller", result.Name);
        Assert.NotNull(result.Category);
        Assert.Equal("Strollers", result.Category.Name);
    }
}