using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServies productService;
        public ProductsController(IProductServies iu)
        {
            productService = iu;
        }

        //GET: api/<Products>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            List<Product> products = await productService.getAllProductsAsync();
            if (products != null)
                return Ok(products);
            else
                return StatusCode(400, "products didnt find");
        }

        // GET api/<Products>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            Product product = await productService.getProductByIdAsync(id);
            if (product != null)
                return Ok(product);
            else
                return StatusCode(400, "product didnt find");
        }

       

    }

}
