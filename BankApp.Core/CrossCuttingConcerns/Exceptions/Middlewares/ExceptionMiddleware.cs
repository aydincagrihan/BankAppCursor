using BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Middlewares
{
    /// <summary>
    /// Global hata yakalama middleware'i.
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(context, exception);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            HttpExceptionHandler exceptionHandler = new() { Response = context.Response };
            return exceptionHandler.HandleExceptionAsync(exception);
        }
    }
} 