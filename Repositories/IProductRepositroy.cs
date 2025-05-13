using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface IProductRepositroy
    {
        Task<Product> getProductByIdAsync(int id);
        Task<List<Product>> getAllProductsAsync();
    }
}