using BabyProductShop;
using Entities;

namespace Services
{
    public interface ICategoryServies
    {
        Task<Category> addCategoryAsync(Category category);
        Task<Category> getCategoryByIdAsync(int id);
        Task<Category> updateAsync(Category categoryToUpdate, int id);
        Task<List<Category>> getAllCategoriesAsync();
    }
}