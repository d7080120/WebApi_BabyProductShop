using Xunit;
using Entities;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

public class CategoryRepositoryIntegrationTests : IClassFixture<DatabaseFixture>
{
    private readonly DatabaseFixture _fixture;
    private readonly CategoryRepositroy _categoryRepository;

    public CategoryRepositoryIntegrationTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
        _categoryRepository = new CategoryRepositroy(_fixture.DbContext);
    }

    [Fact]
    public async Task GetAllCategoriesAsync_ReturnsAllCategories()
    {
        // Arrange
        _fixture.ClearDatabase();
        var category1 = new Category { Id = 1, Name = "Toys", Products = new List<Product>() };
        var category2 = new Category { Id = 2, Name = "Strollers", Products = new List<Product>() };
        _fixture.DbContext.Categories.AddRange(category1, category2);
        await _fixture.DbContext.SaveChangesAsync();

        // Act
        var categories = await _categoryRepository.getAllCategoriesAsync();

        // Assert
        Assert.NotNull(categories);
        Assert.Equal(2, categories.Count);
        Assert.Contains(categories, c => c.Name == "Toys");
        Assert.Contains(categories, c => c.Name == "Strollers");
    }

    [Fact]
    public async Task GetAllCategoriesAsync_EmptyDb_ReturnsEmptyList()
    {
        // Arrange
        _fixture.ClearDatabase();

        // Act
        var categories = await _categoryRepository.getAllCategoriesAsync();

        // Assert
        Assert.NotNull(categories);
        Assert.Empty(categories);
    }
}