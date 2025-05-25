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

        public async Task<List<Category>> getAllCategoriesAsync()
        {
            return await categoryRepositroy.getAllCategoriesAsync();
        }

    }
}
