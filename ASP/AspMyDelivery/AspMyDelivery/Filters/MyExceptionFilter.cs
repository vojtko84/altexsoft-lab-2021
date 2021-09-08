using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace AspMyDelivery.API.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<MyExceptionFilter> _logger;

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogWarning($"In {context.ActionDescriptor.DisplayName}: \n {context.Exception.Message} \n {context.Exception.StackTrace} ");
            context.ExceptionHandled = true;
        }
    }
}