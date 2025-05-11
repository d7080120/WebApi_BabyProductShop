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
    public class UsersController : ControllerBase
    {
        private readonly IUserServies userService;
        public UsersController(IUserServies iu)
        {
            userService = iu;
        }
        //= new UserServies();

        // GET: api/<Users>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<Users>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<Users>
        [HttpPost]
        public async Task<ActionResult<User>> Register([FromBody]User user)
        {
            try
            {
                User newUser = await userService.registerAsync(user);
                if (newUser != null)
                    return Ok(newUser);
                else
                    return StatusCode(400,"fileds are empty");
            }
            catch (Exception ex)
            {
                    return StatusCode(400, ex.Message);
            }
        }
        //// POST api/<Users>
        //[HttpPost]
        [Route("login")]
        public async Task<ActionResult<Task<User>>> Post([FromBody] LoginUser loginUser)
        {
            User user =await userService.loginAsync(loginUser);
            if (user != null)
            {
                return Ok(user);

            }
            return Unauthorized("username and password dont fit");

        }
        //PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]User userToUpdate)
        {
            try
            {
                User updetedUser =await userService.updateAsync(userToUpdate, id);
                if (updetedUser != null)
                    return Ok(updetedUser);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //// DELETE api/<Users>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }

}
