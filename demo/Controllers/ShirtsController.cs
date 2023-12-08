using demo.Filters;
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
        public string UpdateShirt(int id)
        {
            return $"Updating shirt with ID: {id}";
        }


        [HttpDelete("{id}")]
        public string DeleteShirt(int id) {
            return $"Deleting shirt with ID: {id}";
        }

    }
}