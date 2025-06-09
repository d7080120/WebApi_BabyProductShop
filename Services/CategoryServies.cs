using AutoMapper;
using BabyProductShop;
using DTOEntities;
using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class CategoryServies : ICategoryServies
    {
        private readonly ICategoryRepositroy categoryRepositroy;
        private readonly IMapper mapper;
        public CategoryServies(ICategoryRepositroy ur,IMapper mapper)
        {
            categoryRepositroy = ur;
            this.mapper = mapper;
        }

        public async Task<List<CategoryDTO>> getAllCategoriesAsync()
        {
            List<Category> categories = await categoryRepositroy.getAllCategoriesAsync();
            return mapper.Map<List<CategoryDTO>>(categories);
        }

    }
}
