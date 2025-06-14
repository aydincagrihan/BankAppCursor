using BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using BankApp.Core.CrossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.Handlers
{
    /// <summary>
    /// HTTP isteklerinde oluşan hataları yakalayıp işleyecek sınıf.
    /// </summary>
    public class HttpExceptionHandler : ExceptionHandler
    {
        private HttpResponse? _response;
        public HttpResponse Response
        {
            get => _response ?? throw new ArgumentNullException(nameof(_response));
            set => _response = value;
        }

        protected override Task HandleException(BusinessException businessException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = JsonSerializer.Serialize(new BusinessProblemDetails(businessException.Message));
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(ValidationException validationException)
        {
            Response.StatusCode = StatusCodes.Status400BadRequest;
            string details = JsonSerializer.Serialize(new ValidationProblemDetails(validationException.Errors));
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(AuthorizationException authorizationException)
        {
            Response.StatusCode = StatusCodes.Status401Unauthorized;
            string details = JsonSerializer.Serialize(new AuthorizationProblemDetails(authorizationException.Message));
            return Response.WriteAsync(details);
        }

        protected override Task HandleException(Exception exception)
        {
            Response.StatusCode = StatusCodes.Status500InternalServerError;
            string details = JsonSerializer.Serialize(new InternalServerErrorProblemDetails(exception.Message));
            return Response.WriteAsync(details);
        }
    }
} 