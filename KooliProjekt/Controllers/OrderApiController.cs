using KooliProjekt.Data;
using KooliProjekt.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KooliProjekt.Controllers
{
    [Route("api/Order")]
    [ApiController]
    public class OrderApiController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderApiController(IOrderService service)
        {
            _service = service;
        }

        // GET: api/<OrdersApiController>
        [HttpGet]
        public async Task<IEnumerable<Order>> Get()
        {
            var result = await _service.List(1, 10000, null);
            return result.Results;
        }

        // GET api/<TodoListsApiController>/5
        [HttpGet("{id}")]
        public async Task<object> Get(int id)
        {
            var list = await _service.Get(id);
            if (list == null)
            {
                return NotFound();
            }

            return list;
        }

        // POST api/<TodoListsApiController>
        [HttpPost]
        public async Task<object> Post([FromBody] Order list)
        {
            await _service.Save(list);

            return Ok(list);
        }

        // PUT api/<TodoListsApiController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Order list)
        {
            if (id != list.Id)
            {
                return BadRequest();
            }

            await _service.Save(list);

            return Ok();
        }

        // DELETE api/<TodoListsApiController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var list = await _service.Get(id);
            if (list == null)
            {
                return NotFound();
            }

            await _service.Delete(id);

            return Ok();
        }
    }
}