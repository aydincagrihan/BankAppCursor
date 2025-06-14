using System.Net;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    /// <summary>
    /// Sunucu hatalarında dönecek hata detayları.
    /// </summary>
    public class InternalServerErrorProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public InternalServerErrorProblemDetails(string detail)
        {
            Title = "Internal Server Error";
            Detail = detail;
            Status = StatusCodes.Status500InternalServerError;
            Type = "https://example.com/probs/internal";
        }
    }
} 