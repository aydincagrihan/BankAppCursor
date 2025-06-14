using System.Net;

namespace BankApp.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails
{
    /// <summary>
    /// Bulunamama hatalarında dönecek hata detayları.
    /// </summary>
    public class NotFoundProblemDetails : Microsoft.AspNetCore.Mvc.ProblemDetails
    {
        public NotFoundProblemDetails(string detail)
        {
            Title = "Not Found";
            Detail = detail;
            Status = StatusCodes.Status404NotFound;
            Type = "https://example.com/probs/not-found";
        }
    }
} 