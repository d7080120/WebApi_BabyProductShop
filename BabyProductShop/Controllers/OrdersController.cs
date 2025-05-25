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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServies orderService;
        public OrdersController(IOrderServies iu)
        {
            orderService = iu;
        }

        //POST api/<Orders>
        [HttpPost]
        public async Task<ActionResult<Order>> Register([FromBody] Order order)
        {
            try
            {
                Order newOrder = await orderService.addOrderAsync(order);
                if (newOrder != null)
                    return Ok(newOrder);
                else
                    return StatusCode(400, "fileds are empty");
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
    }

}
