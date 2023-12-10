using demo.Data;
using demo.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace demo.Filters.ExceptionFilters
{
    public class Shirt_HandleUpdateExceptionsFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ApplicationDbContext _db;

        public Shirt_HandleUpdateExceptionsFilterAttribute(ApplicationDbContext db)
        {
            _db = db;
        }
        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);

            var strShirtId = context.RouteData.Values["id"] as string;
            if(int.TryParse(strShirtId, out var shirtId))
            {
              
                if (_db.Shirts.FirstOrDefault(x=> x.Id == shirtId) == null)
                {
                    context.ModelState.AddModelError("id", "Shirt doesn't exists anymore.");
                    var problemDetails = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status404NotFound
                    };
                    context.Result = new NotFoundObjectResult(problemDetails);
                }
            }
        }
    }
}
