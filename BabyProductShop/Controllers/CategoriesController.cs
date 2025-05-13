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
        //[HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            List<Category> categories = await categoryService.getAllCategoriesAsync();
            if (categories != null)
                return Ok(categories);
            else
                return StatusCode(400, "categories didnt find");
        }

        // GET api/<Categories>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            Category category = await categoryService.getCategoryByIdAsync(id);
            if (category != null)
                return Ok(category);
            else
                return StatusCode(400, "category didnt find");
        }

        // POST api/<Categories>
        [HttpPost]
        public async Task<ActionResult<Category>> Register([FromBody]Category category)
        {
            try
            {
                Category newCategory = await categoryService.addCategoryAsync(category);
                if (newCategory != null)
                    return Ok(newCategory);
                else
                    return StatusCode(400,"fileds are empty");
            }
            catch (Exception ex)
            {
                    return StatusCode(400, ex.Message);
            }
        }

        //PUT api/<Categories>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]Category categoryToUpdate)
        {
            try
            {
                Category updetedCategory =await categoryService.updateAsync(categoryToUpdate, id);
                if (updetedCategory != null)
                    return Ok(updetedCategory);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// DELETE api/<Categories>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }

}
