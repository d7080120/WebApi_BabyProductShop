using BabyProductShop;
using DTOEntities;
using Entities;

namespace Services
{
    public interface IProductServies
    {
        Task<List<ProductDTO>> getAllProductsAsync(ProductQueryParameters parameters);
    }
}