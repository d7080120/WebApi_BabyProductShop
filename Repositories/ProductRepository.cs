using System;
using BabyProductShop;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class ProductRepositroy :IProductRepositroy
    {
        private readonly Prudoct_Kategory_webApi _prudoct_Kategory_webApi;

        public ProductRepositroy(Prudoct_Kategory_webApi prudoct_Kategory_webApi)
        {
            _prudoct_Kategory_webApi = prudoct_Kategory_webApi;
        }

        public async Task<Product> getProductByIdAsync(int id)
        {
            Product product = await _prudoct_Kategory_webApi.Products.FirstAsync((u) => u.Id == id);
            return product;
        }

        public async Task<List<Product>> getAllProductsAsync()
        {
            return await _prudoct_Kategory_webApi.Products.ToListAsync();
        }
        //public async Task<Boolean> deleteProduct(int id)
        //{

        //}
    }
}
