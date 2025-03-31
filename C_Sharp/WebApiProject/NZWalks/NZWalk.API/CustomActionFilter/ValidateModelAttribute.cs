using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NZWalk.API.CustomActionFilter
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            /* Validate Model State */
            if (!context.ModelState.IsValid)
            {
                /* Add a response */
                context.Result = new BadRequestResult();
            }
        }
    }
}
