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

        public async Task<List<Product>> getAllProductsAsync()
        {
            return await _prudoct_Kategory_webApi.Products.Include(c=>c.Category).ToListAsync();
        }
       
    }
}
