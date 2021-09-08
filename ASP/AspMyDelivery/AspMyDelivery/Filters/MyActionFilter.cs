using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspMyDelivery.API.Filters
{
    public class MyActionFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine(context.HttpContext.Request.Body);
        }
    }
}