using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface ICategoryRepositroy
    {
        Task<Category> addCategoryAsync(Category category);
        Task<Category> getCategoryByIdAsync(int id);
        Task<Category> updateAsync(Category categoryToUpdate, int id);
        Task<List<Category>> getAllCategoriesAsync();
    }
}