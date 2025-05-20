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

        ////GET: api/<Orders>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> Get()
        //{
        //    List<Order> orders = await orderService.getAllOrdersAsync();
        //    if (orders != null)
        //        return Ok(orders);
        //    else
        //        return StatusCode(400, "orders didnt find");
        //}

        //// GET api/<Orders>/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> Get(int id)
        //{
        //    Order order = await orderService.getOrderByIdAsync(id);
        //    if (order != null)
        //        return Ok(order);
        //    else
        //        return StatusCode(400, "order didnt find");
        //}

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

        //PUT api/<Orders>/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody]Order orderToUpdate)
        //{
        //    try
        //    {
        //        Order updetedOrder =await orderService.updateAsync(orderToUpdate, id);
        //        if (updetedOrder != null)
        //            return Ok(updetedOrder);
        //        else
        //            return BadRequest();
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}

        //// DELETE api/<Orders>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }

}
