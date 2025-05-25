using Xunit;
using Moq;
using Entities;
using Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using BabyProductShop;
using Moq.EntityFrameworkCore;

namespace RepositoryTest
{
    public class CategoryRepositoryUnitTesting
    {
        [Fact]
        public async Task GetAllCategoriesAsync_ReturnsAllCategories()
        {
            // Arrange
            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Toys" },
                new Category { Id = 2, Name = "Clothes" }
            };
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Categories).ReturnsDbSet(categories);

            var repository = new CategoryRepositroy(mockContext.Object);

            // Act
            var result = await repository.getAllCategoriesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, c => c.Name == "Toys");
            Assert.Contains(result, c => c.Name == "Clothes");
        }
    }
}