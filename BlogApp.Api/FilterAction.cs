using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlogApp.Api
{
    public class FilterAction : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {

            var exp = context.Exception != null;
            if (exp)
                context.ExceptionHandled = true;
                var data = new { ErrorMessage = context.Exception.Message };
                context.Result = new NotFoundObjectResult(data);
        }
    }
}
