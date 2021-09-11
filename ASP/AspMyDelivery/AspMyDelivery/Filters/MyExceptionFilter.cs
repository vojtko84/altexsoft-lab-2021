using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace AspMyDelivery.API.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<MyExceptionFilter> _logger;
        private readonly IWebHostEnvironment _environment;

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger, IWebHostEnvironment environment)
        {
            _logger = logger;
            _environment = environment;
        }

        public void OnException(ExceptionContext context)
        {
            if (_environment.IsDevelopment())
            {
                System.Console.WriteLine("Development");
                _logger.LogWarning($"In {context.ActionDescriptor.DisplayName}: \n {context.Exception.Message} \n {context.Exception.StackTrace} ");
                context.ExceptionHandled = true;
            }

            if (_environment.IsEnvironment("QA"))
            {
                System.Console.WriteLine("QA");
                _logger.LogWarning($"In {context.ActionDescriptor.DisplayName}: \n {context.Exception.Message} \n {context.Exception.StackTrace} ");
                context.ExceptionHandled = true;
            }

            if (_environment.IsEnvironment("Prodaction"))
            {
                System.Console.WriteLine("QA");
                _logger.LogWarning($"In {context.ActionDescriptor.DisplayName}: \n {context.Exception.Message} ");
                context.ExceptionHandled = true;
            }
        }
    }
}