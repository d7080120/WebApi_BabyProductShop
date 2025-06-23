using BabyProductShop;
using DTOEntities;
using Entities;

namespace Services
{
    public interface ICategoryServies
    {
        Task<List<CategoryDTO>> getAllCategoriesAsync();
    }
}