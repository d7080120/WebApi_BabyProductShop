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
        public async Task<Product> getProductByIdAsync(int id)
        {
            return await productRepositroy.getProductByIdAsync(id);
        }


        public async Task<List<Product>> getAllProductsAsync()
        {
            return await productRepositroy.getAllProductsAsync();
        }

        //public Boolean deleteProduct()
        //{

        //}
    }
}
