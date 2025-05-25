using BabyProductShop;
using Entities;

namespace Services
{
    public interface ICategoryServies
    {
        Task<List<Category>> getAllCategoriesAsync();
    }
}