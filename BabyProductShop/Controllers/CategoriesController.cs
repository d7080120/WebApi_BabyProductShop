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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServies categoryService;
        public CategoriesController(ICategoryServies iu)
        {
            categoryService = iu;
        }

        //GET: api/<Categories>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            List<Category> categories = await categoryService.getAllCategoriesAsync();
            if (categories != null)
                return Ok(categories);
            else
                return StatusCode(400, "categories didnt find");
        }

      
    }

}
