using BabyProductShop;
using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class CategoryServies : ICategoryServies
    {
        private readonly ICategoryRepositroy categoryRepositroy;
        public CategoryServies(ICategoryRepositroy ur)
        {
            categoryRepositroy = ur;
        }
        public async Task<Category> getCategoryByIdAsync(int id)
        {
            return await categoryRepositroy.getCategoryByIdAsync(id);
        }


        public async Task<Category> updateAsync(Category categoryToUpdate, int id)
        {
            if (categoryToUpdate.Products == null || categoryToUpdate.Name == null)
            {
                return null;
            }
                return await categoryRepositroy.updateAsync(categoryToUpdate, id);
  
        }

        public async Task<Category> addCategoryAsync(Category category)
        {
            if (category.Name == null || category.Products == null)
            {
                return null;
            }
            return await categoryRepositroy.addCategoryAsync(category);
        }

        public async Task<List<Category>> getAllCategoriesAsync()
        {
            return await categoryRepositroy.getAllCategoriesAsync();
        }

        //public Boolean deleteCategory()
        //{

        //}
    }
}
