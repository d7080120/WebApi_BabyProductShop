using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BabyProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        UserServies userServices = new UserServies();

         // POST api/<PasswordsController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] string value)
        {
            int powerPassword = userServices.powerOfPassword(value);
            if (powerPassword != -1)
                return Ok(powerPassword);
            else
                return BadRequest();

        }

    }
}
