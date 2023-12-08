using demo.Filters;
using demo.Filters.ExceptionFilters;
using demo.Models;
using demo.Models.Repositories;
using demo.Models.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShirtsController : ControllerBase
    {



        [HttpGet]
        public  IActionResult GetShirts()
        {
            return Ok(ShirtRepository.getShirts());
        }
 
        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtsById(int id)
        {
            if(id <= 0)
                return BadRequest();
            var shirt = ShirtRepository.GetShirtById(id);
            if (shirt == null)
                return NotFound();

            return Ok(shirt);
        }

        [HttpPost]
        [Shirt_ValdiateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);

            return CreatedAtAction(nameof(GetShirtsById),
                new { id = shirt.Id }, shirt);
        }


        [HttpPatch("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
                ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult DeleteShirt(int id) {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);


            return Ok(shirt);
        }

    }
}