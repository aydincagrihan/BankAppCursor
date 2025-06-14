using System.Net;
using FluentValidation.Results;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    /// <summary>
    /// Validation hatalarında dönecek hata detayları.
    /// </summary>
    public class ValidationProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public IEnumerable<ValidationFailure> Errors { get; init; }

        public ValidationProblemDetails(IEnumerable<ValidationFailure> errors)
        {
            Title = "Validation Error";
            Detail = "One or more validation errors occurred.";
            Status = StatusCodes.Status400BadRequest;
            Type = "https://example.com/probs/validation";
            Errors = errors;
        }
    }
} 