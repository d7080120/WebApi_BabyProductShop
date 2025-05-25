using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface IProductRepositroy
    {
        Task<List<Product>> getAllProductsAsync();
    }
}