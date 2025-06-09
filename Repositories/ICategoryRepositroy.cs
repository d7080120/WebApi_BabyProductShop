using BabyProductShop;
using Entities;

namespace Repositories
{
    public interface ICategoryRepositroy
    {
        Task<List<Category>> getAllCategoriesAsync();
    }
}