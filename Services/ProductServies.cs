using AutoMapper;
using BabyProductShop;
using DTOEntities;
using Entities;
using Repositories;
using System.Text.Json;

namespace Services
{
    public class ProductServies : IProductServies
    {
        private readonly IProductRepositroy productRepositroy;
        private readonly IMapper mapper;
        public ProductServies(IProductRepositroy ur,IMapper mapper)
        {
            productRepositroy = ur;
            this.mapper = mapper;
            
        }
      
        public async Task<List<ProductDTO>> getAllProductsAsync()
        {
            List<Product> products = await productRepositroy.getAllProductsAsync();
            return mapper.Map<List<ProductDTO>>(products);
        }

    }
}
