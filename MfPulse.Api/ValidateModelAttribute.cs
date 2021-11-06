using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MfPulse.Api
{
    public class ValidateModelAttribute : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext context) 
        {
            if (!context.ModelState.IsValid) 
            {
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
            }
        }
    }
}