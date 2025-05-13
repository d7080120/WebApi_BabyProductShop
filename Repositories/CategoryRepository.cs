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

        public async Task<Category> getCategoryByIdAsync(int id)
        {
            Category category = await _prudoct_Kategory_webApi.Categories.FirstAsync((u) => u.Id == id);
            return category;
        }

        public async Task<Category> updateAsync(Category categoryToUpdate, int id)
        {
            _prudoct_Kategory_webApi.Categories.Update(categoryToUpdate);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return await Task.FromResult(categoryToUpdate);
        }

        public async Task<Category> addCategoryAsync(Category category)
        {
            await _prudoct_Kategory_webApi.Categories.AddAsync(category);
            await _prudoct_Kategory_webApi.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> getAllCategoriesAsync()
        {
            return await _prudoct_Kategory_webApi.Categories.ToListAsync();
        }
        //public async Task<Boolean> deleteCategory(int id)
        //{

        //}
    }
}
