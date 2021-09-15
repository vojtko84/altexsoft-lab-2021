using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspMyDelivery.API.Filters
{
    public class MyActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            ActionExecutedContext rContext = null;
            string stringContent = string.Empty;

            context.HttpContext.Request.EnableBuffering();
            context.HttpContext.Request.Body.Position = 0;

            using (var reader = new StreamReader(context.HttpContext.Request.Body))
            {
                stringContent = await reader.ReadToEndAsync();

                context.HttpContext.Request.Body.Position = 0;
            }

            rContext = await next();

            Console.WriteLine(stringContent);
        }
    }
}