using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860//

namespace BabyProductShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        IUserServies userServices;//_userServices 
        public PasswordsController(IUserServies iu)
        {
            userServices = iu;
        }
     
         // POST api/<PasswordsController>//
        [HttpPost]
        public ActionResult<int> Post([FromBody] string value)
        {
            int powerPassword = userServices.powerOfPassword(value);
            //use shorted syntax for returning Ok or NotFound
            if (powerPassword != -1)
                return Ok(powerPassword);
            else
                return BadRequest();
                

        }

    }
}
