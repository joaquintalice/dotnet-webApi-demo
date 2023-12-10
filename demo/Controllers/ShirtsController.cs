using demo.Data;
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
        private readonly ApplicationDbContext _db;

        public ShirtsController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public  IActionResult GetShirts()
        {
            return Ok(_db.Shirts.ToList());
        }
 
        [HttpGet("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult GetShirtsById(int id)
        {
            var shirt = HttpContext.Items["shirt"];

            return Ok(shirt);
        }

        [HttpPost]
        [TypeFilter(typeof(Shirt_ValdiateCreateShirtFilterAttribute))]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            _db.Shirts.Add(shirt);
            _db.SaveChanges();

            return CreatedAtAction(nameof(GetShirtsById),
                new { id = shirt.Id }, shirt);
        }


        [HttpPatch("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateShirtFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
                ShirtRepository.UpdateShirt(shirt);
            return NoContent();
        }


        [HttpDelete("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult DeleteShirt(int id) {
            var shirt = ShirtRepository.GetShirtById(id);
            ShirtRepository.DeleteShirt(id);


            return Ok(shirt);
        }

    }
}