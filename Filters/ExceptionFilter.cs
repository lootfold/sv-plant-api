using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SVPlant.Core.Exceptions;

namespace SVPlant.Filters
{
    public class ExceptionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is IAppException ex)
            {
                context.Result = new ObjectResult(new { ex.Message })
                {
                    StatusCode = ex.StatusCode
                };

                context.ExceptionHandled = true;
            }
        }
    }
}
