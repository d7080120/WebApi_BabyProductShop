using System;
using BabyProductShop;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepositroy :ICategoryRepositroy
    {
        private readonly Prudoct_Kategory_webApi _prudoct_Kategory_webApi;

        public CategoryRepositroy(Prudoct_Kategory_webApi prudoct_Kategory_webApi)
        {
            _prudoct_Kategory_webApi = prudoct_Kategory_webApi;
        }

        public async Task<List<Category>> getAllCategoriesAsync()//GetAllCategoriesAsync - change all function names to PascalCase in all the files
        {
            return await _prudoct_Kategory_webApi.Categories.Include(c=>c.Products).ToListAsync();
        }
        
    }
}
