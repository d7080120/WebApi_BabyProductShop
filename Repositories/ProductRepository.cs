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

        //public async Task<List<Product>> getAllProductsAsync()//delete
        //{
        //    return await _prudoct_Kategory_webApi.Products.Include(c=>c.Category).ToListAsync();
        //}

        public async Task<List<Product>> getAllProductsAsync(ProductQueryParameters parameters)//GetAllProductsAsync
        {
            var query = _prudoct_Kategory_webApi.Products
                .Include(p => p.Category)
                .AsQueryable();

            if (parameters.MinPrice.HasValue)
                query = query.Where(p => p.Price >= parameters.MinPrice.Value);
            if (parameters.MaxPrice.HasValue)
                query = query.Where(p => p.Price <= parameters.MaxPrice.Value);
            if (!string.IsNullOrEmpty(parameters.Name))
                query = query.Where(p => p.Name.Contains(parameters.Name));
            if (parameters.CategoryId.HasValue)
                query = query.Where(p => p.CategoryId == parameters.CategoryId);
            if (parameters.SortBy.ToLower() == "price")
            {
                query = parameters.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescending(p => p.Price)
                    : query.OrderBy(p => p.Price);
            }
            else 
            {
                query = parameters.SortDirection.ToLower() == "desc"
                    ? query.OrderByDescending(p => p.Name)
                    : query.OrderBy(p => p.Name);
            }

            query = query
                .Skip((parameters.Page - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return await query.ToListAsync();
        }
        public async Task<Product> getProductByIdAsync(int productId)//GetProductByIdAsync
        {
            return await _prudoct_Kategory_webApi.Products
                .Include(c => c.Category)
                .FirstOrDefaultAsync(p => p.Id == productId);
        }
    }
}
