using BabyProductShop;
using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class ProductServies : IProductServies
    {
        private readonly IProductRepositroy productRepositroy;
        public ProductServies(IProductRepositroy ur)
        {
            productRepositroy = ur;
        }
      
        public async Task<List<Product>> getAllProductsAsync()
        {
            return await productRepositroy.getAllProductsAsync();
        }

    }
}
