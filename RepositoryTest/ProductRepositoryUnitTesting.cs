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
    public class ProductRepositoryUnitTesting
    {
        [Fact]
        public async Task GetAllProductsAsync_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Toy Car", Description = "Red car", Price = 10 },
                new Product { Id = 2, Name = "Baby Shirt", Description = "Blue shirt", Price = 15 }
            };
            var mockContext = new Mock<Prudoct_Kategory_webApi>();
            mockContext.Setup(x => x.Products).ReturnsDbSet(products);

            var repository = new ProductRepositroy(mockContext.Object);

            // Act
            ProductQueryParameters p=new ProductQueryParameters();
            var result = await repository.getAllProductsAsync(p);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, p => p.Name == "Toy Car");
            Assert.Contains(result, p => p.Name == "Baby Shirt");
        }
    }
}



