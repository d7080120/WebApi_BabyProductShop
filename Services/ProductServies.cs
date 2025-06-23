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
        private readonly IProductRepositroy _productRepositroy;
        private readonly IMapper _mapper;
        public ProductServies(IProductRepositroy ur,IMapper mapper)
        {
            _productRepositroy = ur;
            this._mapper = mapper;
            
        }

        //public async Task<List<ProductDTO>> getAllProductsAsync()
        //{
        //    List<Product> products = await productRepositroy.getAllProductsAsync();
        //    return mapper.Map<List<ProductDTO>>(products);
        //}

        public async Task<List<ProductDTO>> getAllProductsAsync(ProductQueryParameters parameters)
        {
            List<Product> products = await _productRepositroy.getAllProductsAsync(parameters);
            return _mapper.Map<List<ProductDTO>>(products);
        }

    }
}
