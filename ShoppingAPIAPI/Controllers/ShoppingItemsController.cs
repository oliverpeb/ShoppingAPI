using Microsoft.AspNetCore.Mvc;
using ShoppingAPI;
using ShoppingAPIAPI.Repositories;

namespace ShoppingAPIAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class ShoppingItemsController : ControllerBase
    {
        private readonly ShoppingItemsRepository _repository;
        public ShoppingItemsController(ShoppingItemsRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<List<shoppingitem>> GetAll()
        {
            List<shoppingitem> result = _repository.GetAll();
            if (result.Count < 1)
            {
                return NoContent();
            }
            Response.Headers.Add("TotalAmount", "" + result.Count.ToString());
            return Ok(result);
        }
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<shoppingitem> Add(shoppingitem newshoppingitem)
        {


            shoppingitem createdshoppingitem = _repository.Add(newshoppingitem);
            return Created($"/shoppingitems/" + createdshoppingitem.Id, createdshoppingitem);

        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<shoppingitem?> GetById(int id)
        {
            shoppingitem shoppingitem = _repository.GetById(id);
            if (shoppingitem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(shoppingitem);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<shoppingitem?> Delete(int id)
        {
            var foundshoppingitem = _repository.Delete(id);
            if (foundshoppingitem == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundshoppingitem);
            }
        }

        [HttpGet("totalprice")]
        public ActionResult<shoppingitem> TotalPrice()
        {
            return _repository.TotalPrice();
        }

    }
}