using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserServies userService = new UserServies();

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
        public ActionResult<User> Post([FromBody]User user)
        {
            user = userService.addUser(user);
            if (user != null)
                return Ok(user);
            //return CreatedAtAction(nameof(Ok), new { id = user.UserId }, user);
            else
                return CreatedAtAction(nameof(BadRequest), null);

        }
        //// POST api/<Users>
        //[HttpPost]
        [Route("login")]
        public ActionResult<User> Post([FromBody] LoginUser loginUser)
        {
            User user = userService.login(loginUser);
            if (user != null)
            {
                return Ok(user);

            }
            return Unauthorized("username and password dont fit");

        }
        //PUT api/<Users>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User userToUpdate)
        {
            
            userToUpdate = userService.update(userToUpdate, id );
            if (userToUpdate != null)
                return Ok(userToUpdate);
            else
                return BadRequest();
        }

        //// DELETE api/<Users>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }

}
