using BabyProductShop;
using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<Product> getProductByIdAsync(int id);
        Task<List<Product>> getAllProductsAsync();
    }
}