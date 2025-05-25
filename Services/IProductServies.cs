using BabyProductShop;
using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<List<Product>> getAllProductsAsync();
    }
}