using DTOEntities;
using Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using System.Threading.Tasks;
//delete this comment - in all the files
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryServies categoryService;//_categoryService - change in all the files
        public CategoriesController(ICategoryServies iu)
        {
            categoryService = iu;
        }

        //GET: api/<Categories>//delete this comment - in all the files
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()//clean code - change function name to more descriptive, change in all the files
        {
            List<CategoryDTO> categories = await categoryService.getAllCategoriesAsync();
            if (categories != null)
                return Ok(categories);
            else
                return StatusCode(400, "categories didnt find");
            //use shorted syntax for returning Ok or NotFound
            //return categories != null ? Ok(categories) : NotFound("categories didn't find");
        }

      
    }

}
